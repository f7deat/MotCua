using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service.Infrastructure
{
    public interface IService<T>
    {
        T Add(T user);
        bool Delete(T user);
        bool Update(T user);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
