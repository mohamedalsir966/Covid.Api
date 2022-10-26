using Domain.Entities;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<Patient> _sortHelper;
        public PatientRepository(ApplicationDbContext context, ISortHelper<Patient> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }

        public async Task<Patient> CreateNewPatientCommand(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> DeletePatientByIdCommand(Patient patient)
        {
            patient.IsDeleted = true;
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<PagedList<Patient>> GetAllPatientsQuery(QueryStringParameters queryParams)
        {
            var query = _context.Patient.Where(a=>a.IsDeleted==false).Include(a => a.PatientVaccin).ThenInclude(a=>a.Vaccin).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy,queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<Patient>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }

        public async Task<Patient> GetPatientByIdQuery(Guid? id)
        {
            var patient = await _context.Patient.Where(a=>a.IsDeleted==false&&a.Id==id).Include(a => a.PatientVaccin).ThenInclude(a=>a.Vaccin).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatientByIdCommand(Patient existingPatien)
        {
            await _context.SaveChangesAsync();
            return existingPatien;
        }
    }
}
