using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enum;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientFeatures.Commands
{
    public class CreateNewPatientCommand : IRequest<Response<PatientDto>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public Gender Gender { get; set; }

    }

    public class CreateNewPatientCommandHandler : IRequestHandler<CreateNewPatientCommand, Response<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _PatientRepository;
        public CreateNewPatientCommandHandler(IMapper mapper, IPatientRepository  patientRepository)
        {
            _mapper = mapper;
            _PatientRepository = patientRepository;
        }
        public async Task<Response<PatientDto>> Handle(CreateNewPatientCommand command, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(command);
             await _PatientRepository.CreateNewPatientCommand(patient);
            return new Response<PatientDto>
            {
                Data = _mapper.Map<PatientDto>(patient),
                StatusCode = 200,
                Message = "Data has been added"
            };
        }
    }


}
