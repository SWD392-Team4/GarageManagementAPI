using GarageManagementAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GarageManagementAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            RepositoryContext
            .Set<T>()
            .AsNoTracking() :
            RepositoryContext
            .Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            RepositoryContext
            .Set<T>()
            .Where(expression)
            .AsNoTracking() :
            RepositoryContext
            .Set<T>()
            .Where(expression);

        public virtual void Create(T entity) =>
            RepositoryContext
            .Set<T>()
            .Add(entity);

        public virtual async Task CreateAsync(T entity) =>
            await RepositoryContext
            .Set<T>()
            .AddAsync(entity);

        public virtual void Creates(T[] entity) =>
            RepositoryContext
            .Set<T>()
            .AddRange(entity);

        public virtual async Task CreatesAsync(T[] entity) =>
            await RepositoryContext
            .Set<T>()
            .AddRangeAsync(entity);

        public virtual void Update(T entity) =>
            RepositoryContext
            .Set<T>()
            .Update(entity);

        public virtual void Updates(T[] entity) =>
            RepositoryContext
            .Set<T>()
            .UpdateRange(entity);

        public virtual void Delete(T entity) =>
            RepositoryContext
            .Set<T>()
            .Remove(entity);

        public virtual void Deletes(T[] entity) =>
            RepositoryContext
            .Set<T>()
            .RemoveRange(entity);
    }
}
