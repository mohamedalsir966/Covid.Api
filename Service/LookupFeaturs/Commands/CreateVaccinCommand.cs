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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.LookupFeaturs.Commands
{
    public class CreateVaccinCommand : IRequest<Response<VaccinDto>>
    {

        public string Name { get; set; }
        public int TotalNumOfDose { get; set; }
        public class CreateVaccinCommandCommandHandler : IRequestHandler<CreateVaccinCommand, Response<VaccinDto>>
        {
            private readonly IMapper _mapper;
            private readonly ILookupRepository _LookupRepository;
            public CreateVaccinCommandCommandHandler(IMapper mapper, ILookupRepository lookupRepository)
            {
                _mapper = mapper;
                _LookupRepository= lookupRepository;
            }
            public async Task<Response<VaccinDto>> Handle(CreateVaccinCommand command, CancellationToken cancellationToken)
            {
                var vaccin = _mapper.Map<Vaccin>(command);
                  await _LookupRepository.CreateNewVaccinCommand(vaccin);
                return new Response<VaccinDto>
                {
                    Data = _mapper.Map<VaccinDto>(vaccin),
                    StatusCode = 200,
                    Message = "Data has been added"
                };
               

            }
        }
    }
}

