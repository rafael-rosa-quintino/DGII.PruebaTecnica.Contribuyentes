using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Aggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.SeedWork
{
    public class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>,  IRepository<TEntity>  where TEntity : class, IEntity, IAggregateRoot
    {

        public RepositoryBase(DGIIDbContext context)
            :base(context) { }


        public virtual void Insert(TEntity entity)
        {
            _DbSet.Add(entity);
        }


        private void Delete(TEntity entityToDelete)
        {
            if (_Dbcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _DbSet.Attach(entityToDelete);
            }
            _DbSet.Remove(entityToDelete);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _DbSet.Find(id)!;
            Delete(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _DbSet.Attach(entityToUpdate);
            _Dbcontext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entityToUpdate)
        {
            _DbSet.AttachRange(entityToUpdate);
            _Dbcontext.Entry(entityToUpdate).State = EntityState.Modified;
        }


    }
}
