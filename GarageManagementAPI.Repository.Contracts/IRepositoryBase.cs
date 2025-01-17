using System.Linq.Expressions;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<T?> FindByIdAsync(Guid id, bool trackChanges);

        IQueryable<T> FindAll(bool trackChanges);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
