using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate
{
    public interface ITaxpayerRepository : IReadOnlyRepository<Taxpayer>
    {
        Task<Taxpayer?> GetByRncCedula(string rncCedula, string includeProperties = "");
    }
}
