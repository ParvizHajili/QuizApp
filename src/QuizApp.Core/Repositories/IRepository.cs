using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace QuizApp.Core.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        T GetFirst(Expression<Func<T, bool>> expression, bool throwException = true);
        T Add(T entity);
        T Edit(T entity, Action<EntityEntry<T>> rules = null);
        void Remove(T entity);
        int Save();
    }
}
