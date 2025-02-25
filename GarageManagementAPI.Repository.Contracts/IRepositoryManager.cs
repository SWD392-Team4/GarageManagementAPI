using Microsoft.EntityFrameworkCore.Storage;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IWorkplaceRepository Workplace { get; }
        IUserRepository User { get; }
        IEmployeeInfoRepository EmployeeInfo { get; }
        IBrandRepository Brand { get; }
        IProductRepository Product { get; }
        IProductHistoryRepository ProductHistory { get; }
        IProductCategoryRepository ProductCategory { get; }
        IProductImageRepository ProductImage { get; }
        IServiceRepository Service { get; }
        ICarPartRepository CarPart { get; }
        ICarPartCategoryRepository CarPartCategory { get; }
        ICarCategoryRepository CarCategory { get; }
        ICarModelRepository CarModel { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
    }
}
