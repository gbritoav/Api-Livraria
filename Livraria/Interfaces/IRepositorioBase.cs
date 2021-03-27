using Livraria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity :class
    {
        void Add(TEntity obj);
        TEntity GetId(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        void Contexto(Contexto _contexto);

    }
}
