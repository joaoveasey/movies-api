using System.Collections.Generic;
using System.Linq.Expressions;

namespace movies_api.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add (T entity);
        void Update (T entity);
        void Delete(T entity);
    }
}
