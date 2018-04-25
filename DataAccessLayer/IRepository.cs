using System;
using System.Linq;

namespace DataAccessLayer
{
    public interface IRepository<T>: IDisposable
    {
        T Save(T entity);
        IQueryable<T> Get();
        T GetById(string id);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
