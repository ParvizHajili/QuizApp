using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace QuizApp.Core.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _table;
        public Repository(DbContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<T>();
        }

        protected DbContext DbContext { get => this.DbContext; }
        protected DbSet<T> Table { get => this.Table; }

        public T Add(T entity)
        {
            _table.Add(entity);
            return entity;
        }

        public T Edit(T entity, EntityEntry<T> rules = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = _table.AsQueryable();

            if (expression != null)
                query = query.Where(expression);

            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> expression)
        {
            var query = _table.AsQueryable();

            if (expression != null)
                query = query.Where(expression);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
