using System;
using System.Linq;
using Queries.Models;
using NHibernate;

namespace Queries.Controllers
{
    internal class NHibernateRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public ISession Session { get; set; }

        public ITransaction Transaction { get; set; }

        public NHibernateRepository()
        {
            Session = NhibernateSession.OpenSession();
        }

        #region Transaction and Session Management Methods
        public void BeginTransaction()
        {
            Transaction = Session.BeginTransaction();
        }
        public void CommitTransaction()
        {
            // Transaction will be replaced with a new transaction         
            // by NHibernate, but we will close to keep a consistent state.
            Transaction.Commit();
            CloseTransaction();
        }
        public void RollbackTransaction()
        {
            // _session must be closed and disposed after a transaction
            // rollback to keep a consistent state.
            Transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }
        private void CloseTransaction()
        {
            Transaction.Dispose();
            Transaction = null;
        }
        private void CloseSession()
        {
            Session.Close();
            Session.Dispose();
            Session = null;
        }
        #endregion
        #region IRepository Members
        public IQueryable<TEntity> Get()
        {
            return Session.Query<TEntity>();
        }
        public TEntity GetById(long id)
        {
            //return Session.Query<TEntity>().SingleOrDefault(x => x.UserID == id);
            return Session.Get<TEntity>(id);

        }
        public TEntity Save(TEntity entity)
        {
            BeginTransaction();
            Session.Save(entity);
            CommitTransaction();
            return entity;

        }
        #endregion
        public void Dispose()
        {
            if (Transaction != null)
            {
                RollbackTransaction();
            }
        }

        public bool Delete(int id)
        {
            TEntity entity = Session.Get<TEntity>(id);
            if (entity != null)
            {
                Session.Delete(entity);
                return true;
            }
            return false;
        }
    }
}