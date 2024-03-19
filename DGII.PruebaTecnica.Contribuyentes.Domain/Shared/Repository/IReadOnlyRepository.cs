using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity, IAggregateRoot
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity?> GetByIdAsync(int id, string includeProperties = "");
    }
}
