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

        public void Save(J j)
        {
            repo.Save(j);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public void Update(J j)
        {
            repo.Update(j);
        }

        public J GetById(long id)
        {
            return repo.GetById(id);
        }

        public List<J> GetAll()
        {
            return repo.GetAll();
        }
    }
}