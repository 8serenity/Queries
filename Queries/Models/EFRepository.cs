using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queries.Models;
using Queries.Models.EF;

namespace Queries.Models
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private QueriesContext Db { get; set; }

        public EFRepository()
        {
            Db = new QueriesContext();
        }

        public IEnumerable<Query> GetQueries()
        {
            return Db.Queries;
        }

        public IEnumerable<User> GetUsers()
        {
            return Db.Users;
        }

        public IQueryable<TEntity> Get()
        {
            return Db.Set<TEntity>();
        }

        public TEntity GetById(long id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity Save(TEntity entity)
        {
            TEntity user = Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
            return user;
        }
        public void Dispose()
        {
            if (Db.Database.CurrentTransaction != null)
            {
                //Db.Database.CurrentTransaction.Rollback();
            }
        }

        public bool Delete(int id)
        {
            TEntity entity = Db.Set<TEntity>().Find(id);
            if (entity != null)
            {
                Db.Set<TEntity>().Remove(entity);
                return true;
            }
            return false;
        }
    }
}