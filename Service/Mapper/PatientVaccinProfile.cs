using AutoMapper;
using Domain.Entities;
using Service.Dto;
using Service.PatientVaccinFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class PatientVaccinProfile : Profile
    {
        public PatientVaccinProfile()
        {
            CreateMap<PatientVaccin, PatientVaccinDto>();
            CreateMap<PatientVaccin, CreatePatientVaccinCommand>();
        }
    }
}
