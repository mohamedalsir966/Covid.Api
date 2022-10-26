﻿using Domain.Entities;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("Covid")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
      
        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped<IPatientRepository, PatientRepository>();
            serviceCollection.AddScoped<ILookupRepository, LookupRepository>();
            serviceCollection.AddScoped<IPatientVaccinRepository, PatientVaccinRepository>();
            serviceCollection.AddScoped<ISortHelper<Patient>, SortHelper<Patient>>();
            serviceCollection.AddScoped<ISortHelper<Vaccin>, SortHelper<Vaccin>>();

        }
    }
}
