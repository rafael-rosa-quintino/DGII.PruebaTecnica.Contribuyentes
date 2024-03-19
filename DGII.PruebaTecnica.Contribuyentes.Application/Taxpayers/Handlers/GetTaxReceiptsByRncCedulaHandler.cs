using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs;
using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Queries;
using DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Handlers
{
    public class GetTaxReceiptsByRncCedulaHandler : IRequestHandler<GetTaxReceiptsByRncCedulaQuery, IEnumerable<TaxReceiptsDto>>
    {
        private readonly ITaxpayerRepository _taxpayerRepository;
        public GetTaxReceiptsByRncCedulaHandler(ITaxpayerRepository taxpayerRepository)
        {
            _taxpayerRepository= taxpayerRepository;
        }

        public async Task<IEnumerable<TaxReceiptsDto>> Handle(GetTaxReceiptsByRncCedulaQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TaxReceiptsDto> taxReceiptsDtos = new List<TaxReceiptsDto>();

            var taxpayer = await _taxpayerRepository.GetByRncCedula(request.rncCedula, includeProperties: "TaxReceipts");

            if (taxpayer == null)
            {
                throw new NotFoundException(DomainErrorCodes.TaxpayerNotFound);
            }

            taxReceiptsDtos = taxpayer.TaxReceipts.Select(x=> new TaxReceiptsDto
            {
                RNCCedula = taxpayer.RNCCedula,
                ITBIS18 = x.ITBIS18,
                Monto= x.Monto,
                NCF= x.NCF                
            }).ToList();

            return taxReceiptsDtos;
        }
    }
}
