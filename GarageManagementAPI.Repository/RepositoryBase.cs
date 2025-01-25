using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GarageManagementAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity<T>
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<T?> FindByIdAsync(Guid id, bool trackChanges)
        => !trackChanges ?
            await RepositoryContext
            .Set<T>()
            .Where(t => t.Id.Equals(id))
            .AsNoTracking()
            .SingleOrDefaultAsync() :
            await RepositoryContext
            .Set<T>()
            .Where(t => t.Id.Equals(id))
            .SingleOrDefaultAsync();

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

        public virtual void Update(T entity) =>
            RepositoryContext
            .Set<T>()
            .Update(entity);

        public virtual void Delete(T entity) =>
            RepositoryContext
            .Set<T>()
            .Remove(entity);
    }
}
