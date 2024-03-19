using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Aggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.SeedWork
{
    public class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {

        protected readonly DbContext _Dbcontext;
        protected readonly DbSet<TEntity> _DbSet;

        public ReadOnlyRepositoryBase(DGIIDbContext context)
        {
            this._Dbcontext = context;
            this._DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity?> GetByIdAsync(int id, string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
