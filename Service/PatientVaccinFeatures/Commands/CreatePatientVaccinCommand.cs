using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientVaccinFeatures.Commands
{
    public class CreatePatientVaccinCommand : IRequest<Response<PatientVaccinDto>>
    {
        public Guid PatientId { get; set; }
        public Guid VaccinId { get; set; }
        public int DoseNum { get; set; }
        public class CreatePatientVaccinCommandHandler : IRequestHandler<CreatePatientVaccinCommand, Response<PatientVaccinDto>>
        {
            private readonly IPatientVaccinRepository _PatientVaccinRepository;
            private readonly IPatientRepository _PatientRepository;
            private readonly ILookupRepository  _LookupRepository;
            private readonly IMapper _mapper;
            public CreatePatientVaccinCommandHandler(IPatientVaccinRepository patientVaccinRepository, IPatientRepository patientRepository, ILookupRepository lookupRepository, IMapper mapper)
            {
                _PatientVaccinRepository = patientVaccinRepository;
                _PatientRepository = patientRepository;
                _LookupRepository = lookupRepository;
                _mapper = mapper;
            }
            public async Task<Response<PatientVaccinDto>> Handle(CreatePatientVaccinCommand command, CancellationToken cancellationToken)
            {
                
                var patient = await _PatientRepository.GetPatientByIdQuery(command.PatientId);
                var vaccin = await _LookupRepository.GetVaccinByIdQuery(command.VaccinId);

                
                if (patient!=null && vaccin!= null )
                {
                    var patientVaccin = new PatientVaccin();
                    patientVaccin.Id = new Guid();
                    patientVaccin.PatientId = command.PatientId;
                    patientVaccin.VaccinId = vaccin.Id;
                    patientVaccin.DoseNum = command.DoseNum;
                    await _PatientVaccinRepository.CreateNewPatientVaccinCommand(patientVaccin);

                    return new Response<PatientVaccinDto>
                    {
                        Data = _mapper.Map<PatientVaccinDto>(patientVaccin),
                        StatusCode = 200,
                        Message = "Data has been added"
                    };

                }
                else
                {

                    return new Response<PatientVaccinDto>
                    {
                        Data = null,
                        StatusCode = 200,
                        Message = "Data found"
                    };

                }

             
            }

           
        }
    }
}

