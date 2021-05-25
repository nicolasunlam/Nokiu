using Microsoft.EntityFrameworkCore;
using Nokiu.Entities.Models;
using System;
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

        public virtual bool Save(T t)
        {
            dbSet.Add(t);

            if (ctx.SaveChanges()>0)
            {
                return true;
            }
            
            return false;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(long id)
        {
            T t = dbSet.Find(id);

            return t;
        }

        public virtual bool Delete(long id)
        {
            T t = GetById(id);

            if (t != null)
            {
                dbSet.Remove(t);
            }
            if (ctx.SaveChanges()>0)
            {
                return true;
            }

            return false;
        }

        public abstract bool Update(T t);

        
    }
}