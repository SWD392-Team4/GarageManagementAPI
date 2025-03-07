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
        ISupplierRepository Supplier { get; }
        ICarModelRepository CarModel { get; }
        IWorkplaceRepository Workplace { get; }
        IGoodsIssuedRepository GoodsIssued { get; }
        ICarCategoryRepository CarCategory { get; }
        IGoodsIssuedDetailRepository GoodsIssuedDetail { get; }
        IServiceImageRepository ServiceImage { get; }
        IProductImageRepository ProductImage { get; }
        IEmployeeInfoRepository EmployeeInfo { get; }
        IGoodsReceivedRepository GoodsReceived { get; }
        IProductHistoryRepository ProductHistory { get; }
        IServiceHistoryRepository ServiceHistory { get; }
        IServiceFeedBackRepository ServiceFeeback { get; }
        IProductCategoryRepository ProductCategory { get; }
        ICarPartCategoryRepository CarPartCategory { get; }
        ISupplierContactRepository SupplierContact { get; }
        IGoodsReceivedDetailRepository GoodsReceivedDetail { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
    }
}
