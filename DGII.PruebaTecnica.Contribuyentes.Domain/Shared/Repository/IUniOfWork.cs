using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository
{
    public interface IUniOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
