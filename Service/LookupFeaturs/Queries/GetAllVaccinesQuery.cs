using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
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

namespace Service.LookupFeaturs.Queries
{
    public class GetAllVaccinesQuery : IRequest<PagedResponse<List<VaccinDto>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllVaccinationQueryHandler : IRequestHandler<GetAllVaccinesQuery, PagedResponse<List<VaccinDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILookupRepository _lookupRepository;
        public GetAllVaccinationQueryHandler(IApplicationDbContext context, IMapper mapper, ILookupRepository lookupRepository)
        {
           _context = context;
           _mapper = mapper;
            _lookupRepository = lookupRepository;   
        }
        public async Task<PagedResponse<List<VaccinDto>>> Handle(GetAllVaccinesQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var vaccination = await _lookupRepository.GetAllVaccinsQuery(queryParams);
            if (vaccination == null)
            {
                return new PagedResponse<List<VaccinDto>>
                {
                   Data = null,
                   StatusCode = 404,
                   Message = "No data found"
                };
            }

           
            return new PagedResponse<List<VaccinDto>>
            {
                Data = _mapper.Map<List<VaccinDto>>(vaccination),
                StatusCode = 200,
                CurrentPage = vaccination.CurrentPage,
                TotalPages = vaccination.TotalPages,
                PageSize = vaccination.PageSize,
                TotalCount = vaccination.TotalCount,
                HasPrevious = vaccination.HasPrevious,
                HasNext = vaccination.HasNext,
                Message = "Data found"
            };
        }
    }

    
}
