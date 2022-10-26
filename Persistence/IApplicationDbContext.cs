using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientVaccin> PatientVaccin { get; set; }
        public DbSet<Vaccin> Vaccin { get; set; }
        Task<int> SaveChangesAsync();
    }
}
