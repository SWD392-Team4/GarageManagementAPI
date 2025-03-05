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
        ICarCategoryRepository CarCategory { get; }
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
        IAppointmentRepository Appointment { get; }
        IPackageRepository Package { get; }
        IPackageConditionRepository PackageCondition { get; }
        IPackageFeedBackRepository PackageFeedBack { get; }
        IPackageHistoryRepository PackageHistory { get; }
        IPackageImageRepository PackageImage { get; }
        IPackageUsageRepository PackageUsage { get; }
        IPackageUsageDetailRepository PackageUsageDetail { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
    }
}
