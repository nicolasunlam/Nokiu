using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IService<T>
    {
        void Save(T t);

        List<T> GetAll();

        T GetById(long id);

        void Delete(long id);

        void Update(T t);
    }
}