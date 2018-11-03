using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service.Infrastructure
{
    public interface IService<T>
    {
        T Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
