using AutoMapper;
using Domain.Helpers;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.PatientFeatures.Queries
{
    public class GetAllPatientQuery : IRequest<PagedResponse<List<PatientDto>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, PagedResponse<List<PatientDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository  _PatientRepository;
        public GetAllPatientQueryHandler(IMapper mapper, IPatientRepository  patientRepository)
        {
            _mapper = mapper;
            _PatientRepository = patientRepository;

        }
        public async Task<PagedResponse<List<PatientDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var patients = await _PatientRepository.GetAllPatientsQuery(queryParams);

            if (patients == null)
            {
                return new PagedResponse<List<PatientDto>>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
        
            return new PagedResponse<List<PatientDto>>
            {
                Data = _mapper.Map<List<PatientDto>>(patients),
                StatusCode = 200,
                CurrentPage = patients.CurrentPage,
                TotalPages = patients.TotalPages,
                PageSize = patients.PageSize,
                TotalCount = patients.TotalCount,
                HasPrevious = patients.HasPrevious,
                HasNext = patients.HasNext,
                Message = "Data found"
            };
        }
      
    }
}

