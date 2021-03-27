using Livraria.Interfaces;
using Livraria.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Repositorio
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {

        private Contexto _contexto;

        public void Contexto(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
            _contexto.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity GetId(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _contexto.Set<TEntity>().Remove(obj);
            _contexto.SaveChanges();
        }

     
    }
}
