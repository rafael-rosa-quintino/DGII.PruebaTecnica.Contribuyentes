using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : IEntity, IAggregateRoot
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Update(IEnumerable<TEntity> objs);
        void Delete(int id);
    }
}
