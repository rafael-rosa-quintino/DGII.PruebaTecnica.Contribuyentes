using DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Context;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Repositories
{
    public class TaxpayerRepository : ReadOnlyRepositoryBase<Taxpayer>, ITaxpayerRepository
    {
        public TaxpayerRepository(DGIIDbContext context)
            : base(context)
        {

        }

        public async Task<Taxpayer?> GetByRncCedula(string rncCedula, string includeProperties = "")
        {
            IQueryable<Taxpayer> query = _DbSet;

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(x => x.RNCCedula == rncCedula).FirstOrDefaultAsync();
        }
    }
}
