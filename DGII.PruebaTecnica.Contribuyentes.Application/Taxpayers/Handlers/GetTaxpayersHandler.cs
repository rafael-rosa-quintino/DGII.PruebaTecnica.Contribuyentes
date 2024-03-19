using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs;
using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Queries;
using DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Handlers
{
    public class GetTaxpayersHandler : IRequestHandler<GetTaxpayersQuery, IEnumerable<TaxpayerDto>>
    {

        private readonly ITaxpayerRepository _taxpayerRepository;
        public GetTaxpayersHandler(ITaxpayerRepository taxpayerRepository)
        {
            _taxpayerRepository = taxpayerRepository;
        }

        public async Task<IEnumerable<TaxpayerDto>> Handle(GetTaxpayersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TaxpayerDto> taxpayerDtos = Enumerable.Empty<TaxpayerDto>();

            var taxpayers = await _taxpayerRepository.GetAsync();

            taxpayerDtos = taxpayers.Select(x => new TaxpayerDto
            {
                Type = x.Type.GetDescription(),
                Name = x.Name,
                Status = x.Status.GetDescription(),
                RNCCedula = x.RNCCedula
            });

            return taxpayerDtos;
        }
    }
}
