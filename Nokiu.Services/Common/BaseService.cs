using Nokiu.Entities.Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class BaseService<T, J> : IService<J> where T : BaseRepository<J> where J : class
    {
        protected T repo;
        public BaseService(NokiuContext contexto)
        {
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T;
        }

        public bool Save(J j)
        {
            return repo.Save(j);
        }

        public bool Delete(long id)
        {
            return repo.Delete(id);
        }

        public bool Update(J j)
        {
           return repo.Update(j);
        }

        public J GetById(long id)
        {
            return repo.GetById(id);
        }

        public IEnumerable<J> GetAll()
        {
            return repo.GetAll();
        }

    }
}