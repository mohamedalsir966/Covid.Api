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

namespace Service.LookupFeaturs.Queries
{
    public class GetVaccinByIdQuery : IRequest<Response<VaccinDto>>
    {
        public Guid VaccinId { get; set; }

        public class GetVaccinationByIdQueryHandler : IRequestHandler<GetVaccinByIdQuery, Response<VaccinDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILookupRepository _lookupRepository;
            public GetVaccinationByIdQueryHandler(IApplicationDbContext context, IMapper mapper , ILookupRepository lookupRepository)
            {
                _context = context;
                _mapper = mapper;
                _lookupRepository = lookupRepository;   
            }
            public async Task<Response<VaccinDto>> Handle(GetVaccinByIdQuery request, CancellationToken cancellationToken)
            {
                var vaccination = await _lookupRepository.GetVaccinByIdQuery(request.VaccinId);

                if (vaccination == null)
                {
                    return new Response<VaccinDto>
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new Response<VaccinDto>
                {
                    Data = _mapper.Map<VaccinDto>(vaccination),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }

    }
}
