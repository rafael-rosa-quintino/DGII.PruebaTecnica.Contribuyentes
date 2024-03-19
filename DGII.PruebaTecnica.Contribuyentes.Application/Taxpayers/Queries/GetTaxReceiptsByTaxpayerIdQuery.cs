using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Queries
{
    public record class GetTaxReceiptsByTaxpayerIdQuery(int taxPayerId) : IRequest<IEnumerable<TaxReceiptsDto>>;
}
