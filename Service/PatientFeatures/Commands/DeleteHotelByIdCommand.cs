using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientFeatures.Commands
{
    public class DeletePatientByIdCommand : IRequest<Response<PatientDto>>
    {
        public Guid Id { get; set; }
    }

    public class DeletePatientByIdCommandHandler : IRequestHandler<DeletePatientByIdCommand, Response<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _PatientRepository;
        public DeletePatientByIdCommandHandler(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _PatientRepository = patientRepository;
        }
        public async Task<Response<PatientDto>> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
        {
            var patien = await _PatientRepository.GetPatientByIdQuery(request.Id);
            if (patien.Id != Guid.Empty)
            {
                var deletedPatien = await _PatientRepository.DeletePatientByIdCommand(patien);

                return new Response<PatientDto>
                {
                    Data = _mapper.Map<PatientDto>(deletedPatien),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
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
