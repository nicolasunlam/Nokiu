using System.Collections.Generic;

namespace Services
{
    interface IService<T>
    {
        bool Save(T t);

        IEnumerable<T> GetAll();

        T GetById(long id);

        bool Delete(long id);

        bool Update(T t);
    }
}