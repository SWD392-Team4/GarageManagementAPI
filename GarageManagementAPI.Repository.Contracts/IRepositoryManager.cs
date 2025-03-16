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
        IServiceImageRepository ServiceImage { get; }
        IProductImageRepository ProductImage { get; }
        IEmployeeInfoRepository EmployeeInfo { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IGoodsReceivedRepository GoodsReceived { get; }
        IProductHistoryRepository ProductHistory { get; }
        IServiceHistoryRepository ServiceHistory { get; }
        IServiceFeedBackRepository ServiceFeeback { get; }
        IProductCategoryRepository ProductCategory { get; }
        ICarPartCategoryRepository CarPartCategory { get; }
        IProductAtGarageRepository ProductAtGarage { get; }
        ISupplierContactRepository SupplierContact { get; }
        IGoodsTransactionRepository GoodsTransaction { get; }
        IGoodsIssuedDetailRepository GoodsIssuedDetail { get; }
        IProductAtWarehouseRepository ProductAtWarehouse { get; }
        IGoodsReceivedDetailRepository GoodsReceivedDetail { get; }
        IInvoiceSellProductRepository InvoiceSellProductRepository { get; }
        IInvoiceSellProduct_ProductAtGarageRepository InvoiceSellProduct_ProductAtGarage { get; }
        IGoodsIssuedDetailProductAtWarehouseRepository GoodsIssuedDetailProductAtWarehouse { get; }
        IAppointmentRepository Appointment { get; }
        IAppointmentPerDayRepository AppointmentPerDay { get; }
        IAppointmentDetailPackageRepository AppointmentDetailPackage { get; }
        IAppointmentDetailRepository AppointmentDetail { get; }
        IAppointmentReplacementPartRepository AppointmentReplacementPart { get; }
        IPackageRepository Package { get; }
        IPackageConditionRepository PackageCondition { get; }
        IPackageFeedBackRepository PackageFeedBack { get; }
        IPackageHistoryRepository PackageHistory { get; }
        IPackageImageRepository PackageImage { get; }
        IPackageUsageRepository PackageUsage { get; }
        IPackageUsageDetailRepository PackageUsageDetail { get; }
        IPackageDetailRepository PackageDetail { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
    }
}
