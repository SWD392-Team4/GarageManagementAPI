using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GarageManagementAPI.Repository
{
    public class RepositoryContext : IdentityDbContext<User, Roles, Guid>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            // Configure auto-generation for Guid primary keys
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var keyProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault();
                if (keyProperty?.ClrType == typeof(Guid))
                {
                    keyProperty.ValueGenerated = ValueGenerated.OnAdd;
                }
            }

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentDetailConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentDetailPackageConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentPerDayConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentReplacementPartConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CarCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CarConditionImageConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarPartCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CarPartConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCarConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeInfoConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsIssuedConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsIssuedDetailConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsReceivedConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsReceivedDetailConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoicePackageDetailConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceSellDetailConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceServiceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConditionConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PackageFeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new PackageHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PackageImageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageUsageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageUsageDetailConfiguraiton());
            modelBuilder.ApplyConfiguration(new ProductAtGarageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAtWarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ReplacementPartConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceFeedBackConfiguraiton());
            modelBuilder.ApplyConfiguration(new ServiceHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceImageConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierContactConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkplaceConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
        }



        public virtual DbSet<Appointment> Appointments { get; set; }

        public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }

        public virtual DbSet<AppointmentDetailPackage> AppointmentDetailPackages { get; set; }

        public virtual DbSet<AppointmentPerDay> AppointmentPerDays { get; set; }

        public virtual DbSet<AppointmentReplacementPart> AppointmentReplacementParts { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<CarCategory> CarCategories { get; set; }

        public virtual DbSet<CarConditionImage> CarConditionImages { get; set; }

        public virtual DbSet<CarModel> CarModels { get; set; }

        public virtual DbSet<CarPart> CarParts { get; set; }

        public virtual DbSet<CarPartCategory> CarPartCategories { get; set; }

        public virtual DbSet<CustomerCar> CustomerCars { get; set; }

        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

        public virtual DbSet<GoodsIssued> GoodsIssueds { get; set; }

        public virtual DbSet<GoodsIssuedDetail> GoodsIssuedDetails { get; set; }

        public virtual DbSet<GoodsReceived> GoodsReceiveds { get; set; }

        public virtual DbSet<GoodsReceivedDetail> GoodsReceivedDetails { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<InvoicePackageDetail> InvoicePackageDetails { get; set; }

        public virtual DbSet<InvoiceServiceDetail> InvoiceServiceDetails { get; set; }

        public virtual DbSet<InvoiceSellProduct> InvoiceSellProducts { get; set; }

        public virtual DbSet<Package> Packages { get; set; }

        public virtual DbSet<PackageCondition> PackageConditions { get; set; }

        public virtual DbSet<PackageDetail> PackageDetails { get; set; }

        public virtual DbSet<PackageFeedBack> PackageFeedBacks { get; set; }

        public virtual DbSet<PackageHistory> PackageHistories { get; set; }

        public virtual DbSet<PackageImage> PackageImages { get; set; }

        public virtual DbSet<PackageUsage> PackageUsages { get; set; }

        public virtual DbSet<PackageUsageDetail> PackageUsageDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductAtGarage> ProductAtGarages { get; set; }

        public virtual DbSet<ProductAtWarehouse> ProductAtWarehouses { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<ProductHistory> ProductHistories { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ReplacementPart> ReplacementParts { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServiceFeedBack> ServiceFeedBacks { get; set; }

        public virtual DbSet<ServiceHistory> ServiceHistories { get; set; }

        public virtual DbSet<ServiceImage> ServiceImages { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

        public virtual DbSet<Workplace> Workplaces { get; set; }

    }
}
