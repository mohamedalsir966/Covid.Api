using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using Service.Mapper;
using AutoMapper;
using Service.PipelineBehaviours;

namespace Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                 .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<PatientProfile>();
                c.AddProfile<LookupProfile>();
                c.AddProfile<PatientVaccinProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());


        }
    }
}
