using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

namespace Service.PatientVaccinFeatures.Queries
{
    public class GetAllPatientVaccinQuery : IRequest<Response<List<PatientVaccinDto>>>
    {
        public class GetAllPatientVaccinQueryHandler : IRequestHandler<GetAllPatientVaccinQuery,Response<List<PatientVaccinDto>>>
        {
            private readonly IPatientVaccinRepository _PatientVaccinRepository;
            private readonly IMapper _mapper;
            
            public GetAllPatientVaccinQueryHandler(IPatientVaccinRepository patientVaccinRepository, IMapper mapper)
            {
                _PatientVaccinRepository = patientVaccinRepository;
                _mapper = mapper;

            }
            public async Task<Response<List<PatientVaccinDto>>> Handle(GetAllPatientVaccinQuery request, CancellationToken cancellationToken)
            {
                var PatientVaccin = await _PatientVaccinRepository.GetAllPatientVaccinQuery();
                if (PatientVaccin == null)
                {
                    return new PagedResponse<List<PatientVaccinDto>>
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new Response<List<PatientVaccinDto>>
                {
                    Data = _mapper.Map<List<PatientVaccinDto>>(PatientVaccin),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }
    }
}
