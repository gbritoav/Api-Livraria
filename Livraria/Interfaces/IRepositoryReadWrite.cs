using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Interface
{
    public interface IRepositoryReadWrite<T> : IRepositoryReadOnly<T>, IRepositoryWrite<T>
    {
      

    }
}
