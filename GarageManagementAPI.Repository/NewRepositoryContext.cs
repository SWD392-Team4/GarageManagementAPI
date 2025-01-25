//using System;
//using System.Collections.Generic;
//using GarageManagementAPI.Entities.NewModels;
//using Microsoft.EntityFrameworkCore;

//namespace GarageManagementAPI.Application;

//public partial class NewRepositoryContext : DbContext
//{
//    public NewRepositoryContext()
//    {
//    }

//    public NewRepositoryContext(DbContextOptions<NewRepositoryContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Appointment> Appointments { get; set; }

//    public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }

//    public virtual DbSet<AppointmentDetailPackage> AppointmentDetailPackages { get; set; }

//    public virtual DbSet<AppointmentPerDay> AppointmentPerDays { get; set; }

//    public virtual DbSet<AppointmentReplacementPart> AppointmentReplacementParts { get; set; }

//    public virtual DbSet<Brand> Brands { get; set; }

//    public virtual DbSet<CarCategory> CarCategories { get; set; }

//    public virtual DbSet<CarConditionImage> CarConditionImages { get; set; }

//    public virtual DbSet<CarModel> CarModels { get; set; }

//    public virtual DbSet<CarPart> CarParts { get; set; }

//    public virtual DbSet<CarPartCategory> CarPartCategories { get; set; }

//    public virtual DbSet<CustomerCar> CustomerCars { get; set; }

//    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

//    public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

//    public virtual DbSet<GoodsIssued> GoodsIssueds { get; set; }

//    public virtual DbSet<GoodsIssuedDetail> GoodsIssuedDetails { get; set; }

//    public virtual DbSet<GoodsReceived> GoodsReceiveds { get; set; }

//    public virtual DbSet<GoodsReceivedDetail> GoodsReceivedDetails { get; set; }

//    public virtual DbSet<Invoice> Invoices { get; set; }

//    public virtual DbSet<InvoiceAppointmentPackageDetail> InvoiceAppointmentPackageDetails { get; set; }

//    public virtual DbSet<InvoiceAppointmentServiceDetail> InvoiceAppointmentServiceDetails { get; set; }

//    public virtual DbSet<InvoiceSellProduct> InvoiceSellProducts { get; set; }

//    public virtual DbSet<Package> Packages { get; set; }

//    public virtual DbSet<PackageCondition> PackageConditions { get; set; }

//    public virtual DbSet<PackageDetail> PackageDetails { get; set; }

//    public virtual DbSet<PackageFeedBack> PackageFeedBacks { get; set; }

//    public virtual DbSet<PackageHistory> PackageHistories { get; set; }

//    public virtual DbSet<PackageImage> PackageImages { get; set; }

//    public virtual DbSet<PackageUsage> PackageUsages { get; set; }

//    public virtual DbSet<PackageUsageDetail> PackageUsageDetails { get; set; }

//    public virtual DbSet<Product> Products { get; set; }

//    public virtual DbSet<ProductAtGarage> ProductAtGarages { get; set; }

//    public virtual DbSet<ProductAtWarehouse> ProductAtWarehouses { get; set; }

//    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

//    public virtual DbSet<ProductHistory> ProductHistories { get; set; }

//    public virtual DbSet<ProductImage> ProductImages { get; set; }

//    public virtual DbSet<ReplacementPart> ReplacementParts { get; set; }

//    public virtual DbSet<Service> Services { get; set; }

//    public virtual DbSet<ServiceFeedBack> ServiceFeedBacks { get; set; }

//    public virtual DbSet<ServiceHistory> ServiceHistories { get; set; }

//    public virtual DbSet<ServiceImage> ServiceImages { get; set; }

//    public virtual DbSet<Supplier> Suppliers { get; set; }

//    public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<Workplace> Workplaces { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=.;database=TestGM; Integrated Security=true; TrustServerCertificate=true;uid=sa;pwd=sa12345");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Appointment>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("appointment_id_primary");

//            entity.ToTable("Appointment");

//            entity.HasIndex(e => e.CustomerEmail, "appointment_customeremail_index");

//            entity.HasIndex(e => new { e.CustomerPhoneNumber, e.CustomerEmail }, "appointment_customerphonenumber_customeremail_index");

//            entity.HasIndex(e => e.CustomerPhoneNumber, "appointment_customerphonenumber_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.AppointmentType).HasMaxLength(255);
//            entity.Property(e => e.CanceledReason).HasColumnType("text");
//            entity.Property(e => e.CarCondition).HasColumnType("text");
//            entity.Property(e => e.CarLicensePlateNumber).HasMaxLength(255);
//            entity.Property(e => e.CustomerEmail).HasMaxLength(255);
//            entity.Property(e => e.CustomerName).HasMaxLength(255);
//            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(255);
//            entity.Property(e => e.ExpectedPrice).HasColumnType("decimal(18, 2)");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.ApproveByEmployee).WithMany(p => p.Appointments)
//                .HasForeignKey(d => d.ApproveByEmployeeId)
//                .HasConstraintName("appointment_approvebyemployeeid_foreign");

//            entity.HasOne(d => d.CarModel).WithMany(p => p.Appointments)
//                .HasForeignKey(d => d.CarModelId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointment_carmodelid_foreign");

//            entity.HasOne(d => d.Garage).WithMany(p => p.Appointments)
//                .HasForeignKey(d => d.GarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointment_garageid_foreign");
//        });

//        modelBuilder.Entity<AppointmentDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("appointmentdetail_id_primary");

//            entity.ToTable("AppointmentDetail");

//            entity.HasIndex(e => e.AppointmentId, "appointmentdetail_appointmentid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ServiceNote).HasColumnType("text");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDetails)
//                .HasForeignKey(d => d.AppointmentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentdetail_appointmentid_foreign");

//            entity.HasOne(d => d.ServiceHistory).WithMany(p => p.AppointmentDetails)
//                .HasForeignKey(d => d.ServiceHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentdetail_servicehistoryid_foreign");

//            entity.HasOne(d => d.UpdateByCustomer).WithMany(p => p.AppointmentDetailUpdateByCustomers)
//                .HasForeignKey(d => d.UpdateByCustomerId)
//                .HasConstraintName("appointmentdetail_updatebycustomerid_foreign");

//            entity.HasOne(d => d.UpdateByEmployee).WithMany(p => p.AppointmentDetailUpdateByEmployees)
//                .HasForeignKey(d => d.UpdateByEmployeeId)
//                .HasConstraintName("appointmentdetail_updatebyemployeeid_foreign");
//        });

//        modelBuilder.Entity<AppointmentDetailPackage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("appointmentdetailpackage_id_primary");

//            entity.ToTable("AppointmentDetailPackage");

//            entity.HasIndex(e => new { e.PackageHistoryId, e.AppointmentId }, "appointmentdetailpackage_packagehistoryid_appointmentid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDetailPackages)
//                .HasForeignKey(d => d.AppointmentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentdetailpackage_appointmentid_foreign");

//            entity.HasOne(d => d.PackageHistory).WithMany(p => p.AppointmentDetailPackages)
//                .HasForeignKey(d => d.PackageHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentdetailpackage_packagehistoryid_foreign");

//            entity.HasOne(d => d.UpdateByCustomer).WithMany(p => p.AppointmentDetailPackageUpdateByCustomers)
//                .HasForeignKey(d => d.UpdateByCustomerId)
//                .HasConstraintName("appointmentdetailpackage_updatebycustomerid_foreign");

//            entity.HasOne(d => d.UpdateByEmployee).WithMany(p => p.AppointmentDetailPackageUpdateByEmployees)
//                .HasForeignKey(d => d.UpdateByEmployeeId)
//                .HasConstraintName("appointmentdetailpackage_updatebyemployeeid_foreign");
//        });

//        modelBuilder.Entity<AppointmentPerDay>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("appointmentperday_id_primary");

//            entity.ToTable("AppointmentPerDay");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);
//        });

//        modelBuilder.Entity<AppointmentReplacementPart>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("appointmentreplacementpart_id_primary");

//            entity.ToTable("AppointmentReplacementPart");

//            entity.HasIndex(e => e.AppointmentDetailId, "appointmentreplacementpart_appointmentdetailid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Quantity).HasColumnName("quantity");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.AppointmentReplacementParts)
//                .HasForeignKey(d => d.AppointmentDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentreplacementpart_appointmentdetailid_foreign");

//            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.AppointmentReplacementParts)
//                .HasForeignKey(d => d.ProductAtGarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentreplacementpart_productatgarageid_foreign");

//            entity.HasOne(d => d.ProductHistory).WithMany(p => p.AppointmentReplacementParts)
//                .HasForeignKey(d => d.ProductHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("appointmentreplacementpart_producthistoryid_foreign");
//        });

//        modelBuilder.Entity<Brand>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("brand_id_primary");

//            entity.ToTable("Brand");

//            entity.HasIndex(e => e.BrandName, "brand_brandname_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.BrandName).HasMaxLength(255);
//            entity.Property(e => e.LinkLogo).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//        });

//        modelBuilder.Entity<CarCategory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("carcategory_id_primary");

//            entity.ToTable("CarCategory");

//            entity.HasIndex(e => e.Category, "carcategory_category_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Category).HasMaxLength(255);
//            entity.Property(e => e.Description).HasColumnType("text");
//            entity.Property(e => e.Status).HasMaxLength(255);
//        });

//        modelBuilder.Entity<CarConditionImage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("carconditionimage_id_primary");

//            entity.ToTable("CarConditionImage");

//            entity.HasIndex(e => e.AppointmentDetailId, "carconditionimage_appointmentdetailid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ConditionStage).HasMaxLength(255);
//            entity.Property(e => e.Link).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.CarConditionImages)
//                .HasForeignKey(d => d.AppointmentDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("carconditionimage_appointmentdetailid_foreign");
//        });

//        modelBuilder.Entity<CarModel>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("carmodel_id_primary");

//            entity.ToTable("CarModel");

//            entity.HasIndex(e => e.BrandId, "carmodel_brandid_index");

//            entity.HasIndex(e => e.CarCategoryId, "carmodel_carcategoryid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ModelName).HasMaxLength(255);
//            entity.Property(e => e.ModelYear).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Brand).WithMany(p => p.CarModels)
//                .HasForeignKey(d => d.BrandId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("carmodel_brandid_foreign");

//            entity.HasOne(d => d.CarCategory).WithMany(p => p.CarModels)
//                .HasForeignKey(d => d.CarCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("carmodel_carcategoryid_foreign");

//            entity.HasMany(d => d.Products).WithMany(p => p.CarModels)
//                .UsingEntity<Dictionary<string, object>>(
//                    "ProductCarModel",
//                    r => r.HasOne<Product>().WithMany()
//                        .HasForeignKey("ProductId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("productcarmodel_productid_foreign"),
//                    l => l.HasOne<CarModel>().WithMany()
//                        .HasForeignKey("CarModelId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("productcarmodel_carmodelid_foreign"),
//                    j =>
//                    {
//                        j.HasKey("CarModelId", "ProductId").HasName("productcarmodel_carmodelid_productid_primary");
//                        j.ToTable("ProductCarModel");
//                    });
//        });

//        modelBuilder.Entity<CarPart>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("carpart_id_primary");

//            entity.ToTable("CarPart");

//            entity.HasIndex(e => e.CarPartCategoryId, "carpart_carpartcategoryid_index");

//            entity.HasIndex(e => e.PartName, "carpart_partname_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.PartName).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.CarPartCategory).WithMany(p => p.CarParts)
//                .HasForeignKey(d => d.CarPartCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("carpart_carpartcategoryid_foreign");

//            entity.HasMany(d => d.Products).WithMany(p => p.CarParts)
//                .UsingEntity<Dictionary<string, object>>(
//                    "ProductCarPart",
//                    r => r.HasOne<Product>().WithMany()
//                        .HasForeignKey("ProductId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("productcarpart_productid_foreign"),
//                    l => l.HasOne<CarPart>().WithMany()
//                        .HasForeignKey("CarPartId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("productcarpart_carpartid_foreign"),
//                    j =>
//                    {
//                        j.HasKey("CarPartId", "ProductId").HasName("productcarpart_carpartid_productid_primary");
//                        j.ToTable("ProductCarPart");
//                    });
//        });

//        modelBuilder.Entity<CarPartCategory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("carpartcategory_id_primary");

//            entity.ToTable("CarPartCategory");

//            entity.HasIndex(e => e.PartCategory, "carpartcategory_partcategory_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.PartCategory).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//        });

//        modelBuilder.Entity<CustomerCar>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("customercar_id_primary");

//            entity.ToTable("CustomerCar");

//            entity.HasIndex(e => e.CreatedByEmployeeId, "customercar_createdbyemployeeid_index");

//            entity.HasIndex(e => e.CustomerId, "customercar_customerid_index");

//            entity.HasIndex(e => e.LicensePlateNumber, "customercar_licenseplatenumber_unique").IsUnique();

//            entity.HasIndex(e => e.VehicleIdentificationNumber, "customercar_vehicleidentificationnumber_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Color).HasMaxLength(255);
//            entity.Property(e => e.EngineNumber).HasMaxLength(255);
//            entity.Property(e => e.FuelType).HasMaxLength(255);
//            entity.Property(e => e.LicensePlateNumber).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.VehicleIdentificationNumber).HasMaxLength(255);

//            entity.HasOne(d => d.CarModel).WithMany(p => p.CustomerCars)
//                .HasForeignKey(d => d.CarModelId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("customercar_carmodelid_foreign");

//            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.CustomerCarCreatedByEmployees)
//                .HasForeignKey(d => d.CreatedByEmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("customercar_createdbyemployeeid_foreign");

//            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCarCustomers)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("customercar_customerid_foreign");
//        });

//        modelBuilder.Entity<EmployeeInfo>(entity =>
//        {
//            entity.HasKey(e => e.UserId).HasName("employeeinfo_userid_primary");

//            entity.ToTable("EmployeeInfo");

//            entity.HasIndex(e => e.CitizenIdentification, "employeeinfo_citizenidentification_unique").IsUnique();

//            entity.HasIndex(e => e.WorkplaceId, "employeeinfo_workplaceid_index");

//            entity.Property(e => e.UserId).ValueGeneratedNever();
//            entity.Property(e => e.CitizenIdentification).HasMaxLength(255);
//            entity.Property(e => e.WorkPlace).HasMaxLength(255);

//            entity.HasOne(d => d.User).WithOne(p => p.EmployeeInfo)
//                .HasForeignKey<EmployeeInfo>(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("employeeinfo_userid_foreign");

//            entity.HasOne(d => d.Workplace).WithMany(p => p.EmployeeInfos)
//                .HasForeignKey(d => d.WorkplaceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("employeeinfo_workplaceid_foreign");
//        });

//        modelBuilder.Entity<EmployeeSchedule>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("employeeschedule_id_primary");

//            entity.ToTable("EmployeeSchedule");

//            entity.HasIndex(e => new { e.AppointmentDetailId, e.EmployeeId }, "employeeschedule_appointmentdetailid_employeeid_unique").IsUnique();

//            entity.HasIndex(e => e.AppointmentDetailId, "employeeschedule_appointmentdetailid_index");

//            entity.HasIndex(e => e.EmployeeId, "employeeschedule_employeeid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.EmployeeSchedules)
//                .HasForeignKey(d => d.AppointmentDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("employeeschedule_appointmentdetailid_foreign");

//            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSchedules)
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("employeeschedule_employeeid_foreign");
//        });

//        modelBuilder.Entity<GoodsIssued>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("goodsissued_id_primary");

//            entity.ToTable("GoodsIssued");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.InvoiceCode).HasMaxLength(255);
//            entity.Property(e => e.ReferenceNumber).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.TotalCost).HasColumnType("decimal(8, 2)");

//            entity.HasOne(d => d.CreatedWareHouseManager).WithMany(p => p.GoodsIssueds)
//                .HasForeignKey(d => d.CreatedWareHouseManagerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsissued_createdwarehousemanagerid_foreign");

//            entity.HasOne(d => d.Garage).WithMany(p => p.GoodsIssuedGarages)
//                .HasForeignKey(d => d.GarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsissued_garageid_foreign");

//            entity.HasOne(d => d.Warehouse).WithMany(p => p.GoodsIssuedWarehouses)
//                .HasForeignKey(d => d.WarehouseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsissued_warehouseid_foreign");
//        });

//        modelBuilder.Entity<GoodsIssuedDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("goodsissueddetail_id_primary");

//            entity.ToTable("GoodsIssuedDetail");

//            entity.HasIndex(e => e.GoodsIssuedId, "goodsissueddetail_goodsissuedid_index");

//            entity.HasIndex(e => e.ProductAtWareHouseId, "goodsissueddetail_productatwarehouseid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.GoodsIssued).WithMany(p => p.GoodsIssuedDetails)
//                .HasForeignKey(d => d.GoodsIssuedId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsissueddetail_goodsissuedid_foreign");

//            entity.HasOne(d => d.ProductAtWareHouse).WithMany(p => p.GoodsIssuedDetails)
//                .HasForeignKey(d => d.ProductAtWareHouseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsissueddetail_productatwarehouseid_foreign");
//        });

//        modelBuilder.Entity<GoodsReceived>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("goodsreceived_id_primary");

//            entity.ToTable("GoodsReceived");

//            entity.HasIndex(e => e.SupplierContactId, "goodsreceived_suppliercontactid_index");

//            entity.HasIndex(e => e.WarehouseId, "goodsreceived_warehouseid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.InvoiceCode).HasMaxLength(255);
//            entity.Property(e => e.RefereneceNumber).HasMaxLength(255);
//            entity.Property(e => e.SourceAddress).HasMaxLength(255);
//            entity.Property(e => e.SourceDistrict).HasMaxLength(255);
//            entity.Property(e => e.SourceProvince).HasMaxLength(255);
//            entity.Property(e => e.SourceWards).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

//            entity.HasOne(d => d.CreatedWarehouseManager).WithMany(p => p.GoodsReceiveds)
//                .HasForeignKey(d => d.CreatedWarehouseManagerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsreceived_createdwarehousemanagerid_foreign");

//            entity.HasOne(d => d.SupplierContact).WithMany(p => p.GoodsReceiveds)
//                .HasForeignKey(d => d.SupplierContactId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsreceived_suppliercontactid_foreign");

//            entity.HasOne(d => d.Warehouse).WithMany(p => p.GoodsReceiveds)
//                .HasForeignKey(d => d.WarehouseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsreceived_warehouseid_foreign");
//        });

//        modelBuilder.Entity<GoodsReceivedDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("goodsreceiveddetail_id_primary");

//            entity.ToTable("GoodsReceivedDetail");

//            entity.HasIndex(e => e.GoodsReceivedId, "goodsreceiveddetail_goodsreceivedid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");
//            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");

//            entity.HasOne(d => d.GoodsReceived).WithMany(p => p.GoodsReceivedDetails)
//                .HasForeignKey(d => d.GoodsReceivedId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsreceiveddetail_goodsreceivedid_foreign");

//            entity.HasOne(d => d.Product).WithMany(p => p.GoodsReceivedDetails)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("goodsreceiveddetail_productid_foreign");
//        });

//        modelBuilder.Entity<Invoice>(entity =>
//        {
//            entity.HasKey(e => e.AppointmentId).HasName("invoice_appointmentid_primary");

//            entity.ToTable("Invoice");

//            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
//            entity.Property(e => e.CustomerEmail).HasMaxLength(255);
//            entity.Property(e => e.CustomerName).HasMaxLength(255);
//            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(255);
//            entity.Property(e => e.InvoiceType).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

//            entity.HasOne(d => d.Appointment).WithOne(p => p.Invoice)
//                .HasForeignKey<Invoice>(d => d.AppointmentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoice_appointmentid_foreign");

//            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceCustomers)
//                .HasForeignKey(d => d.CustomerId)
//                .HasConstraintName("invoice_customerid_foreign");

//            entity.HasOne(d => d.Employee).WithMany(p => p.InvoiceEmployees)
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoice_employeeid_foreign");

//            entity.HasOne(d => d.Garage).WithMany(p => p.Invoices)
//                .HasForeignKey(d => d.GarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoice_garageid_foreign");
//        });

//        modelBuilder.Entity<InvoiceAppointmentPackageDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("invoiceappointmentpackagedetail_id_primary");

//            entity.ToTable("InvoiceAppointmentPackageDetail");

//            entity.HasIndex(e => e.InvoiceId, "invoiceappointmentpackagedetail_invoiceid_index");

//            entity.HasIndex(e => new { e.InvoiceId, e.PackageHistoryId }, "invoiceappointmentpackagedetail_invoiceid_packagehistoryid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceAppointmentPackageDetails)
//                .HasForeignKey(d => d.InvoiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoiceappointmentpackagedetail_invoiceid_foreign");

//            entity.HasOne(d => d.PackageHistory).WithMany(p => p.InvoiceAppointmentPackageDetails)
//                .HasForeignKey(d => d.PackageHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoiceappointmentpackagedetail_packagehistoryid_foreign");
//        });

//        modelBuilder.Entity<InvoiceAppointmentServiceDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("invoiceappointmentservicedetail_id_primary");

//            entity.ToTable("InvoiceAppointmentServiceDetail");

//            entity.HasIndex(e => e.InvoiceId, "invoiceappointmentservicedetail_invoiceid_index");

//            entity.HasIndex(e => new { e.InvoiceId, e.ServiceHistoryId }, "invoiceappointmentservicedetail_invoiceid_servicehistoryid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceAppointmentServiceDetails)
//                .HasForeignKey(d => d.InvoiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoiceappointmentservicedetail_invoiceid_foreign");

//            entity.HasOne(d => d.ServiceHistory).WithMany(p => p.InvoiceAppointmentServiceDetails)
//                .HasForeignKey(d => d.ServiceHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoiceappointmentservicedetail_servicehistoryid_foreign");
//        });

//        modelBuilder.Entity<InvoiceSellProduct>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("invoicesellproduct_id_primary");

//            entity.ToTable("InvoiceSellProduct");

//            entity.HasIndex(e => e.InvoiceId, "invoicesellproduct_invoiceid_index");

//            entity.HasIndex(e => new { e.ProductHistoryId, e.InvoiceId, e.ProductAtGarageId }, "invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceSellProducts)
//                .HasForeignKey(d => d.InvoiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoicesellproduct_invoiceid_foreign");

//            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.InvoiceSellProducts)
//                .HasForeignKey(d => d.ProductAtGarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoicesellproduct_productatgarageid_foreign");

//            entity.HasOne(d => d.ProductHistory).WithMany(p => p.InvoiceSellProducts)
//                .HasForeignKey(d => d.ProductHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("invoicesellproduct_producthistoryid_foreign");
//        });

//        modelBuilder.Entity<Package>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("package_id_primary");

//            entity.ToTable("Package");

//            entity.HasIndex(e => e.CarCategoryId, "package_carcategoryid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Description).HasColumnType("text");
//            entity.Property(e => e.PackageName).HasMaxLength(255);
//            entity.Property(e => e.ServiceCategory).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.CarCategory).WithMany(p => p.Packages)
//                .HasForeignKey(d => d.CarCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("package_carcategoryid_foreign");
//        });

//        modelBuilder.Entity<PackageCondition>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packagecondition_id_primary");

//            entity.ToTable("PackageCondition");

//            entity.HasIndex(e => new { e.ConditionType, e.ConditionValue }, "packagecondition_conditiontype_conditionvalue_unique").IsUnique();

//            entity.HasIndex(e => e.PackageId, "packagecondition_packageid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ConditionType).HasMaxLength(255);

//            entity.HasOne(d => d.Package).WithMany(p => p.PackageConditions)
//                .HasForeignKey(d => d.PackageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagecondition_packageid_foreign");
//        });

//        modelBuilder.Entity<PackageDetail>(entity =>
//        {
//            entity.HasKey(e => new { e.PackageHistoryId, e.ServiceId }).HasName("packagedetail_packagehistoryid_serviceid_primary");

//            entity.ToTable("PackageDetail");

//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.PackageHistory).WithMany(p => p.PackageDetails)
//                .HasForeignKey(d => d.PackageHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagedetail_packagehistoryid_foreign");

//            entity.HasOne(d => d.Service).WithMany(p => p.PackageDetails)
//                .HasForeignKey(d => d.ServiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagedetail_serviceid_foreign");
//        });

//        modelBuilder.Entity<PackageFeedBack>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packagefeedback_id_primary");

//            entity.ToTable("PackageFeedBack");

//            entity.HasIndex(e => e.CustomerId, "packagefeedback_customerid_index");

//            entity.HasIndex(e => e.PackageId, "packagefeedback_packageid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Emoji).HasMaxLength(255);
//            entity.Property(e => e.FeedBack).HasColumnType("text");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Customer).WithMany(p => p.PackageFeedBacks)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagefeedback_customerid_foreign");

//            entity.HasOne(d => d.Package).WithMany(p => p.PackageFeedBacks)
//                .HasForeignKey(d => d.PackageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagefeedback_packageid_foreign");
//        });

//        modelBuilder.Entity<PackageHistory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packagehistory_id_primary");

//            entity.ToTable("PackageHistory");

//            entity.HasIndex(e => e.PackageId, "packagehistory_packageid_index");

//            entity.HasIndex(e => new { e.PackageId, e.PackagePrice, e.ValidityPeriod, e.TimeUnit, e.UsageLimit }, "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.PackagePrice).HasColumnType("decimal(8, 2)");
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.TimeUnit).HasMaxLength(255);

//            entity.HasOne(d => d.Package).WithMany(p => p.PackageHistories)
//                .HasForeignKey(d => d.PackageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packagehistory_packageid_foreign");
//        });

//        modelBuilder.Entity<PackageImage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packageimage_id_primary");

//            entity.ToTable("PackageImage");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Link).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Package).WithMany(p => p.PackageImages)
//                .HasForeignKey(d => d.PackageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageimage_packageid_foreign");
//        });

//        modelBuilder.Entity<PackageUsage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packageusage_id_primary");

//            entity.ToTable("PackageUsage");

//            entity.HasIndex(e => e.CustomerCarId, "packageusage_customercarid_index");

//            entity.HasIndex(e => e.InvoiceAppointmentId, "packageusage_invoiceappointmentid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.CustomerCar).WithMany(p => p.PackageUsages)
//                .HasForeignKey(d => d.CustomerCarId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageusage_customercarid_foreign");

//            entity.HasOne(d => d.InvoiceAppointment).WithOne(p => p.PackageUsage)
//                .HasForeignKey<PackageUsage>(d => d.InvoiceAppointmentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageusage_invoiceappointmentid_foreign");

//            entity.HasOne(d => d.PackageHistory).WithMany(p => p.PackageUsages)
//                .HasForeignKey(d => d.PackageHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageusage_packagehistoryid_foreign");
//        });

//        modelBuilder.Entity<PackageUsageDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("packageusagedetail_id_primary");

//            entity.HasIndex(e => new { e.PackageUsageId, e.AppointmentId }).HasName("packageusagedetail_packageusageid_appointmentid_unique").IsUnique();

//            entity.ToTable("PackageUsageDetail");

//            entity.HasIndex(e => e.AppointmentId, "packageusagedetail_appointmentid_unique").IsUnique();

//            entity.HasIndex(e => e.PackageUsageId, "packageusagedetail_packageusageid_index");

//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Appointment).WithOne(p => p.PackageUsageDetail)
//                .HasForeignKey<PackageUsageDetail>(d => d.AppointmentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageusagedetail_appointmentid_foreign");

//            entity.HasOne(d => d.PackageUsage).WithMany(p => p.PackageUsageDetails)
//                .HasForeignKey(d => d.PackageUsageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("packageusagedetail_packageusageid_foreign");
//        });

//        modelBuilder.Entity<Product>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("product_id_primary");

//            entity.ToTable("Product");

//            entity.HasIndex(e => e.BrandId, "product_brandid_index");

//            entity.HasIndex(e => e.ProductBarcode, "product_productbarcode_unique").IsUnique();

//            entity.HasIndex(e => e.ProductCategoryId, "product_productcategoryid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ProductBarcode).HasMaxLength(255);
//            entity.Property(e => e.ProductDescription).HasColumnType("text");
//            entity.Property(e => e.ProductName).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
//                .HasForeignKey(d => d.BrandId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("product_brandid_foreign");

//            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
//                .HasForeignKey(d => d.ProductCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("product_productcategoryid_foreign");
//        });

//        modelBuilder.Entity<ProductAtGarage>(entity =>
//        {
//            entity.HasKey(e => e.GoodsIssuedDetailId).HasName("productatgarage_goodsissueddetailid_primary");

//            entity.ToTable("ProductAtGarage");

//            entity.Property(e => e.GoodsIssuedDetailId).ValueGeneratedNever();
//            entity.Property(e => e.ProductBarcodeAtGarage).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.GoodsIssuedDetail).WithOne(p => p.ProductAtGarage)
//                .HasForeignKey<ProductAtGarage>(d => d.GoodsIssuedDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("productatgarage_goodsissueddetailid_foreign");
//        });

//        modelBuilder.Entity<ProductAtWarehouse>(entity =>
//        {
//            entity.HasKey(e => e.GoodsReceivedDetailId).HasName("productatwarehouse_goodsreceiveddetailid_primary");

//            entity.ToTable("ProductAtWarehouse");

//            entity.Property(e => e.GoodsReceivedDetailId).ValueGeneratedNever();
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.GoodsReceivedDetail).WithOne(p => p.ProductAtWarehouse)
//                .HasForeignKey<ProductAtWarehouse>(d => d.GoodsReceivedDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("productatwarehouse_goodsreceiveddetailid_foreign");
//        });

//        modelBuilder.Entity<ProductCategory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("productcategory_id_primary");

//            entity.ToTable("ProductCategory");

//            entity.HasIndex(e => e.Category, "productcategory_category_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Category).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//        });

//        modelBuilder.Entity<ProductHistory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("producthistory_id_primary");

//            entity.ToTable("ProductHistory");

//            entity.HasIndex(e => e.ProductId, "producthistory_productid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ProductPrice).HasColumnType("decimal(8, 2)");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Product).WithMany(p => p.ProductHistories)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("producthistory_productid_foreign");
//        });

//        modelBuilder.Entity<ProductImage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("productimage_id_primary");

//            entity.ToTable("ProductImage");

//            entity.HasIndex(e => e.ProductId, "productimage_productid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Link).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("productimage_productid_foreign");
//        });

//        modelBuilder.Entity<ReplacementPart>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("replacementpart_id_primary");

//            entity.ToTable("ReplacementPart");

//            entity.HasIndex(e => e.InvoiceAppointmentDetailId, "replacementpart_invoiceappointmentdetailid_index");

//            entity.HasIndex(e => new { e.InvoiceAppointmentDetailId, e.ProductHistoryId, e.ProductAtGarageId }, "replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

//            entity.HasOne(d => d.InvoiceAppointmentDetail).WithMany(p => p.ReplacementParts)
//                .HasForeignKey(d => d.InvoiceAppointmentDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("replacementpart_invoiceappointmentdetailid_foreign");

//            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.ReplacementParts)
//                .HasForeignKey(d => d.ProductAtGarageId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("replacementpart_productatgarageid_foreign");

//            entity.HasOne(d => d.ProductHistory).WithMany(p => p.ReplacementParts)
//                .HasForeignKey(d => d.ProductHistoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("replacementpart_producthistoryid_foreign");
//        });

//        modelBuilder.Entity<Service>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("service_id_primary");

//            entity.ToTable("Service");

//            entity.HasIndex(e => e.CarPartId, "service_carpartid_index");

//            entity.HasIndex(e => new { e.ServiceCategory, e.WorkNature, e.Action, e.CarCategoryId }, "service_servicecategory_worknature_action_carcategoryid_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Action).HasMaxLength(255);
//            entity.Property(e => e.Description).HasColumnType("text");
//            entity.Property(e => e.ServiceCategory).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.WorkNature).HasMaxLength(255);

//            entity.HasOne(d => d.CarCategory).WithMany(p => p.Services)
//                .HasForeignKey(d => d.CarCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("service_carcategoryid_foreign");

//            entity.HasOne(d => d.CarPart).WithMany(p => p.Services)
//                .HasForeignKey(d => d.CarPartId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("service_carpartid_foreign");
//        });

//        modelBuilder.Entity<ServiceFeedBack>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("servicefeedback_id_primary");

//            entity.ToTable("ServiceFeedBack");

//            entity.HasIndex(e => e.CustomerId, "servicefeedback_customerid_index");

//            entity.HasIndex(e => e.ServiceId, "servicefeedback_serviceid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Emoji).HasMaxLength(255);
//            entity.Property(e => e.FeedBack).HasColumnType("text");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceFeedBacks)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("servicefeedback_customerid_foreign");

//            entity.HasOne(d => d.Service).WithMany(p => p.ServiceFeedBacks)
//                .HasForeignKey(d => d.ServiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("servicefeedback_serviceid_foreign");
//        });

//        modelBuilder.Entity<ServiceHistory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("servicehistory_id_primary");

//            entity.ToTable("ServiceHistory");

//            entity.HasIndex(e => e.ServiceId, "servicehistory_serviceid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.Service).WithMany(p => p.ServiceHistories)
//                .HasForeignKey(d => d.ServiceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("servicehistory_serviceid_foreign");
//        });

//        modelBuilder.Entity<ServiceImage>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("serviceimage_id_primary");

//            entity.ToTable("ServiceImage");

//            entity.HasIndex(e => e.ServiceId, "serviceimage_serviceid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Link).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(255);

//            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ServiceImage)
//                .HasForeignKey<ServiceImage>(d => d.Id)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("serviceimage_id_foreign");
//        });

//        modelBuilder.Entity<Supplier>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("supplier_id_primary");

//            entity.ToTable("Supplier");

//            entity.HasIndex(e => new { e.Address, e.Province, e.District, e.Wards }, "supplier_address_province_district_wards_unique").IsUnique();

//            entity.HasIndex(e => e.Name, "supplier_name_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Address).HasMaxLength(50);
//            entity.Property(e => e.District).HasMaxLength(50);
//            entity.Property(e => e.Name).HasMaxLength(255);
//            entity.Property(e => e.Province).HasMaxLength(50);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.SupplierCategory).HasMaxLength(255);
//            entity.Property(e => e.TaxCode).HasMaxLength(255);
//            entity.Property(e => e.Wards).HasMaxLength(50);
//        });

//        modelBuilder.Entity<SupplierContact>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("suppliercontact_id_primary");

//            entity.ToTable("SupplierContact");

//            entity.HasIndex(e => e.SupplierId, "suppliercontact_supplierid_index");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ContactEmail).HasMaxLength(255);
//            entity.Property(e => e.ContactPersonName).HasMaxLength(255);
//            entity.Property(e => e.ContactPhoneNumber).HasMaxLength(255);
//            entity.Property(e => e.ContactPosition).HasMaxLength(255);
//            entity.Property(e => e.Notes).HasColumnType("text");

//            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierContacts)
//                .HasForeignKey(d => d.SupplierId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("suppliercontact_supplierid_foreign");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("users_id_primary");

//            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

//            entity.HasIndex(e => e.PhoneNumber, "users_phonenumber_unique").IsUnique();

//            entity.HasIndex(e => e.UserName, "users_username_unique").IsUnique();

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(255);
//            entity.Property(e => e.Email)
//                .HasMaxLength(255)
//                .IsUnicode(false);
//            entity.Property(e => e.FirstName).HasMaxLength(50);
//            entity.Property(e => e.Image).HasMaxLength(255);
//            entity.Property(e => e.LastName).HasMaxLength(50);
//            entity.Property(e => e.NormalizedEmail)
//                .HasMaxLength(255)
//                .IsUnicode(false);
//            entity.Property(e => e.NormalizedUserName).HasMaxLength(25);
//            entity.Property(e => e.PasswordHash).HasMaxLength(255);
//            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
//            entity.Property(e => e.RefreshToken).HasMaxLength(255);
//            entity.Property(e => e.SecurityStamp).HasMaxLength(255);
//            entity.Property(e => e.Status).HasMaxLength(50);
//            entity.Property(e => e.UserName).HasMaxLength(25);
//        });

//        modelBuilder.Entity<Workplace>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("workplace_id_primary");

//            entity.ToTable("Workplace");

//            entity.HasIndex(e => new { e.Address, e.Province, e.District, e.Wards }, "workplace_address_province_district_wards_unique").IsUnique();

//            entity.HasIndex(e => e.Name, "workplace_name_unique").IsUnique();

//            entity.HasIndex(e => e.PhoneNumber, "workplace_phonenumber_unique").IsUnique();

//            entity.Property(e => e.Id)
//                .ValueGeneratedNever()
//                .HasColumnName("id");
//            entity.Property(e => e.Address).HasMaxLength(50);
//            entity.Property(e => e.District).HasMaxLength(50);
//            entity.Property(e => e.Name).HasMaxLength(255);
//            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
//            entity.Property(e => e.Province).HasMaxLength(50);
//            entity.Property(e => e.Status).HasMaxLength(255);
//            entity.Property(e => e.Wards).HasMaxLength(50);
//            entity.Property(e => e.WorkplaceType).HasMaxLength(255);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
