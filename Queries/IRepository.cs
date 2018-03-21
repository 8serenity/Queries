using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Models
{
    public interface IRepository<T>: IDisposable
    {
        T Save(T entity);
        IQueryable<T> Get();
        T GetById(long id);
        bool Delete(int id);
    }
}
