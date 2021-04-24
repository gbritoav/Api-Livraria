using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Interface
{
    public interface IRepositoryWrite<T>
    {

        void Save(T obj);
        void Update(T obj);
        void Delete(T obj);

    }
}
