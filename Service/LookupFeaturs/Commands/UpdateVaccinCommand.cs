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
    
    public class UpdateVaccinCommand : IRequest<Response<VaccinDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalNumOfDose { get; set; }

    }
    public class UpdateVaccinCommandHanelar : IRequestHandler<UpdateVaccinCommand, Response<VaccinDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILookupRepository  _LookupRepository;
        public UpdateVaccinCommandHanelar(IMapper mapper, ILookupRepository  lookupRepository)
        {
            _mapper = mapper;
            _LookupRepository = lookupRepository;

        }
        public async Task<Response<VaccinDto>> Handle(UpdateVaccinCommand command, CancellationToken cancellationToken)
        {
            var existingVaccin = await _LookupRepository.GetVaccinByIdQuery(command.Id);

            if (existingVaccin.Id != Guid.Empty)
            {
                existingVaccin.Name = command.Name;
                existingVaccin.TotalNumOfDose = command.TotalNumOfDose;
                existingVaccin.ModifiedOn = DateTime.UtcNow;

                var updatedVaccin = await _LookupRepository.UpdateVaccinByIdCommand(existingVaccin);

                return new Response<VaccinDto>
                {
                    Data = _mapper.Map<VaccinDto>(updatedVaccin),
                    StatusCode = 200,
                    Message = "Data has been Updated"
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
