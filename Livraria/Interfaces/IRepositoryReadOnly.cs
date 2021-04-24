using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Interface
{
    public interface IRepositoryReadOnly<T>
    {

        IEnumerable<T> GetAll();
        T GetId(int id);
    }
}
