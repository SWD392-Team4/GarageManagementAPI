using System.Linq.Expressions;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);

        IQueryable<T> FindByCondition(
            Expression<Func<T, bool>> expression,
            bool trackChanges);

        void Create(T entity);

        void Creates(T[] entity);

        Task CreateAsync(T entity);

        Task CreatesAsync(T[] entity);

        void Update(T entity);

        void Updates(T[] entity);

        void Delete(T entity);

        void Deletes(T[] entity);
    }
}
