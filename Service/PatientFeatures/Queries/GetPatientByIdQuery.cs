using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientFeatures.Queries
{
    public class GetPatientByIdQuery : IRequest<Response<PatientDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Response<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository  _PatientRepository;
        public GetPatientByIdQueryHandler(IMapper mapper, IPatientRepository   patientRepository)
        {
            _mapper = mapper;
            _PatientRepository = patientRepository;
        }
        public async Task<Response<PatientDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _PatientRepository.GetPatientByIdQuery(request.Id);

            if (patient == null)
            {
                return new Response<PatientDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new Response<PatientDto>
            {
                Data = _mapper.Map<PatientDto>(patient),
                StatusCode = 200,
                Message = "Data found"
            };
        }
    }

}

