using Microsoft.EntityFrameworkCore.Storage;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IBrandRepository Brand { get; }
        IServiceRepository Service { get; }
        ICarPartRepository CarPart { get; }
        IProductRepository Product { get; }
        ICarModelRepository CarModel { get; }
        IWorkplaceRepository Workplace { get; }
        ICarCategoryRepository CarCategory { get; }
        IServiceImageRepository ServiceImage { get; }
        IProductImageRepository ProductImage { get; }
        IEmployeeInfoRepository EmployeeInfo { get; }
        IProductHistoryRepository ProductHistory { get; }
        IServiceHistoryRepository ServiceHistory { get; }
        IProductCategoryRepository ProductCategory { get; }
        ICarPartCategoryRepository CarPartCategory { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
    }
}
