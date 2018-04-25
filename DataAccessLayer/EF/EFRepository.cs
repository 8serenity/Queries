using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccessLayer.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private QueriesContext Db { get; set; }

        public EFRepository()
        {
            Db = new QueriesContext();
        }

        public IQueryable<TEntity> Get()
        {
            return Db.Set<TEntity>();
        }

        public TEntity GetById(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity Save(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
            return entity;
        }
        public void Dispose()
        {
            if (Db.Database.CurrentTransaction != null)
            {
                Db.Database.CurrentTransaction.Rollback();
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                Db.Set<TEntity>().Remove(entity);
                Db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                Db.Set<TEntity>().AddOrUpdate(entity);
                Db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}