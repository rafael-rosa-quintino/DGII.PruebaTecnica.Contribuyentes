using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Context;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.UniOfWork
{
    public class DGIIUnitOfWork : IUniOfWork
    {
        private readonly DbContext _DbContext;

        public DGIIUnitOfWork(DGIIDbContext context) 
        {
            _DbContext = context;
        }
        public void Dispose()
        {
            _DbContext.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _DbContext.SaveChangesAsync();
        }


    }
}
