using AutoMapper;
using Domain.Entities;
using Service.Dto;
using Service.PatientFeatures.Commands;
using System.Linq;

namespace Service.Mapper
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientVaccin, VaccinModel>()
               .ForMember(from => from.Name, to => to.MapFrom(value => value.Vaccin.Name));
            CreateMap<Patient, PatientDto>()
                   .ForMember(from => from.Vaccin, to => to.MapFrom(value => value.PatientVaccin))
                   .ForMember(from => from.IsVaccinated, to => to.MapFrom(value => value.PatientVaccin.Count() >= value.PatientVaccin.FirstOrDefault().Vaccin.TotalNumOfDose))
                   ;
            //CreateMap<PatientVaccin, VaccinDto>()
            //    .ForMember(from => from.Name, to => to.MapFrom(value => value.Vaccin.Name));
            CreateMap<Patient, CreateNewPatientCommand>().ReverseMap();

        }
    }
}
 