using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientVaccin> PatientVaccin { get; set; }
        public DbSet<Vaccin> Vaccin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
       
    }
}
