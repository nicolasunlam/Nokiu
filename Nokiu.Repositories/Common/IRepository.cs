using System.Collections.Generic;

namespace Repositories
{
    interface IRepository<T>
    {
        bool Save(T t);

        IEnumerable<T> GetAll();

        T GetById(long id);

        bool Delete(long id);

        bool Update(T t);
    }
}