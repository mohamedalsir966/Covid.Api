using AutoMapper;
using Domain.Entities.Enum;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientFeatures.Commands
{
    public class UpdatePatientCommand : IRequest<Response<PatientDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public Gender Gender { get; set; }

    }
    public class UpdatePatientCommandHanelar : IRequestHandler<UpdatePatientCommand, Response<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository  _PatientRepository;
        public UpdatePatientCommandHanelar(IMapper mapper, IPatientRepository  patientRepository )
        {
            _mapper = mapper;
            _PatientRepository = patientRepository;

        }
        public async Task<Response<PatientDto>> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var existingPatient = await _PatientRepository.GetPatientByIdQuery(command.Id);

            if (existingPatient.Id != Guid.Empty)
            {
                existingPatient.Name = command.Name;
                existingPatient.Address = command.Address;
                existingPatient.MobileNumber = command.MobileNumber;
                existingPatient.Gender = command.Gender;
                existingPatient.ModifiedOn = DateTime.UtcNow;

                var updatedPatient = await _PatientRepository.UpdatePatientByIdCommand(existingPatient);

                return new Response<PatientDto>
                {
                    Data = _mapper.Map<PatientDto>(updatedPatient),
                    StatusCode = 200,
                    Message = "Data has been Updated"
                };
            }
            else
            {
                return new Response<PatientDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
        }
    }
}
