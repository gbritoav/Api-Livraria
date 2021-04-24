using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livraria.Interface;
using static Livraria.Model.Context;

namespace Livraria.Repository
{
    public class RepositoryReadWrite<TEntity> : IDisposable, IRepositoryReadWrite<TEntity> where TEntity : class
    {
        private ContextSqlServer db = new ContextSqlServer();
        public void Delete(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetId(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

   
        public void Save(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();           
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
