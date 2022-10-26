using Domain.Entities;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<Vaccin> _sortHelper;
        public LookupRepository(ApplicationDbContext context, ISortHelper<Vaccin> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }

        public async Task<Vaccin> CreateNewVaccinCommand(Vaccin vaccin)
        {
            _context.Vaccin.Add(vaccin);
            await _context.SaveChangesAsync();
            return vaccin;
        }

        public async Task<Vaccin> DeleteVaccinByIdCommand(Vaccin vaccin)
        {
            vaccin.IsDeleted = true;
            await _context.SaveChangesAsync();
            return vaccin;
        }

        public async Task<PagedList<Vaccin>> GetAllVaccinsQuery(QueryStringParameters queryParams)
        {
            var query = _context.Vaccin.Where(a=>a.IsDeleted==false).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy,queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<Vaccin>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }

        public async Task<Vaccin> GetVaccinByIdQuery(Guid? id)
        {
            var vaccin = await _context.Vaccin.Where(a=>a.IsDeleted==false &&a.Id==id).FirstOrDefaultAsync();
            return vaccin;
        }

        public async Task<Vaccin> UpdateVaccinByIdCommand(Vaccin existingVaccin)
        {
            await _context.SaveChangesAsync();
            return existingVaccin;
        }
    }
}
