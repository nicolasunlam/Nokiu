using Microsoft.EntityFrameworkCore;
using Nokiu.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected NokiuContext ctx;
        private readonly DbSet<T> dbSet;

        public BaseRepository(NokiuContext contexto)
        {
            ctx = contexto;
            dbSet = ctx.Set<T>();
        }

        public virtual void Save(T t)
        {
            
            dbSet.Add(t);
            ctx.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(long id)
        {
            T t = dbSet.Find(id);

            return t;
        }

        public virtual void Delete(long id)
        {
            T t = GetById(id);

            if (t != null)
            {
                dbSet.Remove(t);
            }

            ctx.SaveChanges();
        }

        public abstract void Update(T t);

    }
}