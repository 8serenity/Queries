using System;
using System.Linq;

namespace DataAccessLayer
{
    public interface IRepository<T>: IDisposable
    {
        T Save(T entity);
        IQueryable<T> Get();
        T GetById(long id);
        bool Delete(int id);
    }
}
