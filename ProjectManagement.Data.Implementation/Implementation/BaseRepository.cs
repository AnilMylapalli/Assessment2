using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal PMContext Context;
        internal DbSet<T> DbSet;

        public BaseRepository(PMContext _context)
        {
            Context = DependencyResolver.Current.GetService<PMContext>();
            this.DbSet = Context.Set<T>();
        }

        public virtual IEnumerable<T> Get()
        {
            IQueryable<T> query = DbSet;

            return query.ToList();
        }

        public T Get(Expression<Func<T, Boolean>> where)
        {
            return DbSet.Where(where).FirstOrDefault<T>();
        }


        public async Task<T> Add(T entity)
        {
            Context.Add<T>(entity);
            await Context.SaveChangesAsync();
            return Get(entity.ID);
        }

        public async Task<int> Delete(long id)
        {
            Context.Remove<T>(Get(id));
            return await Context.SaveChangesAsync();
        }

        public T Get(long id)
        {
            return Context.Set<T>().Where(i => i.ID == id).FirstOrDefault();
        }

        public virtual void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        Task<T> IBaseRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
