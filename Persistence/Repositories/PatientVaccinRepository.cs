using Domain.Entities;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PatientVaccinRepository : IPatientVaccinRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientVaccinRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PatientVaccin> CreateNewPatientVaccinCommand(PatientVaccin patientVaccin)
        {
            _context.PatientVaccin.Add(patientVaccin);
            await _context.SaveChangesAsync();
            return patientVaccin;
        }

        public async Task<List<PatientVaccin>> GetAllPatientVaccinQuery()
        {
            var query = await _context.PatientVaccin.ToListAsync();

            return query;
        }
    }
}
