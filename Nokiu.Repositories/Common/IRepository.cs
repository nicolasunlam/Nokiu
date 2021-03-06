using System.Collections.Generic;

namespace Repositories
{
    interface IRepository<T>
    {
        void Save(T t);

        List<T> GetAll();

        T GetById(long id);

        void Delete(long id);

        void Update(T t);

    }
}