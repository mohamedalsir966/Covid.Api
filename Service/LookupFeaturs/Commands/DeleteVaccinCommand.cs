using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Dto.Common;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.LookupFeaturs.Commands
{
  
    public class DeleteVaccinCommand : IRequest<Response<VaccinDto>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteVaccinCommandHandler : IRequestHandler<DeleteVaccinCommand, Response<VaccinDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILookupRepository _LookupRepository;
        public DeleteVaccinCommandHandler(IMapper mapper, ILookupRepository  lookupRepository)
        {
            _mapper = mapper;
            _LookupRepository = lookupRepository;
        }
        public async Task<Response<VaccinDto>> Handle(DeleteVaccinCommand request, CancellationToken cancellationToken)
        {
            var patien = await _LookupRepository.GetVaccinByIdQuery(request.Id);
            if (patien!=null)
            {
                var deletedVaccin = await _LookupRepository.DeleteVaccinByIdCommand(patien);

                return new Response<VaccinDto>
                {
                    Data = _mapper.Map<VaccinDto>(deletedVaccin),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
                };
            }
            else
            {
                return new Response<VaccinDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

        }
    }
}
