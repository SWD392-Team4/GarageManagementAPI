IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [AppointmentPerDay] (
    [Id] uniqueidentifier NOT NULL,
    [CountPerDay] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [appointmentperday_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [Brand] (
    [Id] uniqueidentifier NOT NULL,
    [BrandName] nvarchar(255) NOT NULL,
    [LinkLogo] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [brand_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [CarCategory] (
    [Id] uniqueidentifier NOT NULL,
    [Category] nvarchar(255) NOT NULL,
    [Description] text NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [carcategory_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [CarPartCategory] (
    [Id] uniqueidentifier NOT NULL,
    [PartCategory] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [carpartcategory_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [ProductCategory] (
    [Id] uniqueidentifier NOT NULL,
    [Category] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [productcategory_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [Roles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

CREATE TABLE [Supplier] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [TaxCode] nvarchar(255) NULL,
    [Address] nvarchar(50) NOT NULL,
    [Province] nvarchar(50) NOT NULL,
    [District] nvarchar(50) NOT NULL,
    [Wards] nvarchar(50) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    [SupplierCategory] nvarchar(255) NOT NULL,
    CONSTRAINT [supplier_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [RefreshToken] nvarchar(255) NULL,
    [RefreshTokenExpiryTime] datetime2 NULL,
    [Status] nvarchar(50) NOT NULL,
    [Image] nvarchar(255) NULL,
    [UserName] nvarchar(25) NULL,
    [NormalizedUserName] nvarchar(25) NULL,
    [Email] varchar(255) NULL,
    [NormalizedEmail] varchar(255) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(255) NULL,
    [SecurityStamp] nvarchar(255) NULL,
    [ConcurrencyStamp] nvarchar(255) NULL,
    [PhoneNumber] nvarchar(255) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [users_id_primary] PRIMARY KEY ([Id])
);

CREATE TABLE [Workplace] (
    [id] uniqueidentifier NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [PhoneNumber] nvarchar(255) NOT NULL,
    [Address] nvarchar(50) NOT NULL,
    [Province] nvarchar(50) NOT NULL,
    [District] nvarchar(50) NOT NULL,
    [Wards] nvarchar(50) NOT NULL,
    [WorkplaceType] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [workplace_id_primary] PRIMARY KEY ([id])
);

CREATE TABLE [CarModel] (
    [Id] uniqueidentifier NOT NULL,
    [BrandId] uniqueidentifier NOT NULL,
    [CarCategoryId] uniqueidentifier NOT NULL,
    [ModelName] nvarchar(255) NOT NULL,
    [ModelYear] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [carmodel_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [carmodel_brandid_foreign] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]),
    CONSTRAINT [carmodel_carcategoryid_foreign] FOREIGN KEY ([CarCategoryId]) REFERENCES [CarCategory] ([Id])
);

CREATE TABLE [Package] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceCategory] nvarchar(255) NOT NULL,
    [CarCategoryId] uniqueidentifier NOT NULL,
    [PackageName] nvarchar(255) NOT NULL,
    [Description] text NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [package_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [package_carcategoryid_foreign] FOREIGN KEY ([CarCategoryId]) REFERENCES [CarCategory] ([Id])
);

CREATE TABLE [CarPart] (
    [Id] uniqueidentifier NOT NULL,
    [CarPartCategoryId] uniqueidentifier NOT NULL,
    [PartName] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [carpart_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [carpart_carpartcategoryid_foreign] FOREIGN KEY ([CarPartCategoryId]) REFERENCES [CarPartCategory] ([Id])
);

CREATE TABLE [Product] (
    [Id] uniqueidentifier NOT NULL,
    [BrandId] uniqueidentifier NOT NULL,
    [ProductCategoryId] uniqueidentifier NOT NULL,
    [ProductName] nvarchar(255) NOT NULL,
    [ProductBarcode] nvarchar(255) NOT NULL,
    [ProductDescription] text NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [product_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [product_brandid_foreign] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]),
    CONSTRAINT [product_productcategoryid_foreign] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([Id])
);

CREATE TABLE [RoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [SupplierContact] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [ContactPersonName] nvarchar(255) NOT NULL,
    [ContactPosition] nvarchar(255) NOT NULL,
    [ContactPhoneNumber] nvarchar(255) NOT NULL,
    [ContactEmail] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [suppliercontact_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [suppliercontact_supplierid_foreign] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([Id])
);

CREATE TABLE [UserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [EmployeeInfo] (
    [Id] uniqueidentifier NOT NULL,
    [WorkplaceId] uniqueidentifier NOT NULL,
    [CitizenIdentification] nvarchar(255) NOT NULL,
    [Gender] bit NOT NULL,
    [DateOfBirth] date NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    [WorkPlaceType] nvarchar(255) NOT NULL,
    CONSTRAINT [employeeinfo_userid_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [employeeinfo_userid_foreign] FOREIGN KEY ([Id]) REFERENCES [Users] ([Id]),
    CONSTRAINT [employeeinfo_workplaceid_foreign] FOREIGN KEY ([WorkplaceId]) REFERENCES [Workplace] ([id])
);

CREATE TABLE [GoodsIssued] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedWareHouseManagerId] uniqueidentifier NOT NULL,
    [WarehouseId] uniqueidentifier NOT NULL,
    [GarageId] uniqueidentifier NOT NULL,
    [TotalCost] decimal(8,2) NOT NULL,
    [ReferenceNumber] nvarchar(255) NOT NULL,
    [InvoiceCode] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [goodsissued_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [goodsissued_createdwarehousemanagerid_foreign] FOREIGN KEY ([CreatedWareHouseManagerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [goodsissued_garageid_foreign] FOREIGN KEY ([GarageId]) REFERENCES [Workplace] ([id]),
    CONSTRAINT [goodsissued_warehouseid_foreign] FOREIGN KEY ([WarehouseId]) REFERENCES [Workplace] ([id])
);

CREATE TABLE [Appointment] (
    [Id] uniqueidentifier NOT NULL,
    [ApproveByEmployeeId] uniqueidentifier NULL,
    [CarModelId] uniqueidentifier NOT NULL,
    [GarageId] uniqueidentifier NOT NULL,
    [Mileage] int NOT NULL,
    [CustomerName] nvarchar(255) NOT NULL,
    [CustomerPhoneNumber] nvarchar(255) NOT NULL,
    [CustomerEmail] nvarchar(255) NOT NULL,
    [EstimatedAppointmentTime] datetimeoffset NOT NULL,
    [ActualAppointmentTime] datetimeoffset NULL,
    [EstimatedEndTime] datetimeoffset NOT NULL,
    [ActualEndTime] datetimeoffset NULL,
    [ExpectedPrice] decimal(18,2) NOT NULL,
    [AppointmentType] nvarchar(255) NOT NULL,
    [CarLicensePlateNumber] nvarchar(255) NULL,
    [CarCondition] text NULL,
    [CanceledReason] text NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [appointment_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [appointment_approvebyemployeeid_foreign] FOREIGN KEY ([ApproveByEmployeeId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [appointment_carmodelid_foreign] FOREIGN KEY ([CarModelId]) REFERENCES [CarModel] ([Id]),
    CONSTRAINT [appointment_garageid_foreign] FOREIGN KEY ([GarageId]) REFERENCES [Workplace] ([id])
);

CREATE TABLE [CustomerCar] (
    [Id] uniqueidentifier NOT NULL,
    [CarModelId] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [CreatedByEmployeeId] uniqueidentifier NOT NULL,
    [LicensePlateNumber] nvarchar(255) NOT NULL,
    [VehicleIdentificationNumber] nvarchar(255) NOT NULL,
    [EngineNumber] nvarchar(255) NOT NULL,
    [Color] nvarchar(255) NOT NULL,
    [FuelType] nvarchar(255) NOT NULL,
    [Mileage] int NOT NULL,
    [RegistrationDate] date NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [customercar_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [customercar_carmodelid_foreign] FOREIGN KEY ([CarModelId]) REFERENCES [CarModel] ([Id]),
    CONSTRAINT [customercar_createdbyemployeeid_foreign] FOREIGN KEY ([CreatedByEmployeeId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [customercar_customerid_foreign] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id])
);

CREATE TABLE [PackageCondition] (
    [Id] uniqueidentifier NOT NULL,
    [PackageId] uniqueidentifier NOT NULL,
    [ConditionType] int NOT NULL,
    [ConditionValue] int NOT NULL,
    CONSTRAINT [packagecondition_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packagecondition_packageid_foreign] FOREIGN KEY ([PackageId]) REFERENCES [Package] ([Id])
);

CREATE TABLE [PackageFeedBack] (
    [Id] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [PackageId] uniqueidentifier NOT NULL,
    [FeedBack] text NOT NULL,
    [Emoji] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [packagefeedback_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packagefeedback_customerid_foreign] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [packagefeedback_packageid_foreign] FOREIGN KEY ([PackageId]) REFERENCES [Package] ([Id])
);

CREATE TABLE [PackageHistory] (
    [Id] uniqueidentifier NOT NULL,
    [PackageId] uniqueidentifier NOT NULL,
    [PackagePrice] decimal(8,2) NOT NULL,
    [ValidityPeriod] int NOT NULL,
    [TimeUnit] int NOT NULL,
    [UsageLimit] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [packagehistory_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packagehistory_packageid_foreign] FOREIGN KEY ([PackageId]) REFERENCES [Package] ([Id])
);

CREATE TABLE [PackageImage] (
    [Id] uniqueidentifier NOT NULL,
    [PackageId] uniqueidentifier NOT NULL,
    [Link] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [packageimage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packageimage_packageid_foreign] FOREIGN KEY ([PackageId]) REFERENCES [Package] ([Id])
);

CREATE TABLE [Service] (
    [Id] uniqueidentifier NOT NULL,
    [CarPartId] uniqueidentifier NOT NULL,
    [CarCategoryId] uniqueidentifier NOT NULL,
    [ServiceCategory] nvarchar(255) NOT NULL,
    [WorkNature] nvarchar(255) NOT NULL,
    [Action] nvarchar(255) NOT NULL,
    [Description] text NOT NULL,
    [EstimatedHours] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [service_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [service_carcategoryid_foreign] FOREIGN KEY ([CarCategoryId]) REFERENCES [CarCategory] ([Id]),
    CONSTRAINT [service_carpartid_foreign] FOREIGN KEY ([CarPartId]) REFERENCES [CarPart] ([Id])
);

CREATE TABLE [ProductCarModel] (
    [CarModelId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    CONSTRAINT [productcarmodel_carmodelid_productid_primary] PRIMARY KEY ([CarModelId], [ProductId]),
    CONSTRAINT [productcarmodel_carmodelid_foreign] FOREIGN KEY ([CarModelId]) REFERENCES [CarModel] ([Id]),
    CONSTRAINT [productcarmodel_productid_foreign] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE TABLE [ProductCarPart] (
    [CarPartId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    CONSTRAINT [productcarpart_carpartid_productid_primary] PRIMARY KEY ([CarPartId], [ProductId]),
    CONSTRAINT [productcarpart_carpartid_foreign] FOREIGN KEY ([CarPartId]) REFERENCES [CarPart] ([Id]),
    CONSTRAINT [productcarpart_productid_foreign] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE TABLE [ProductHistory] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [ProductPrice] decimal(8,2) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [producthistory_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [producthistory_productid_foreign] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE TABLE [ProductImage] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Link] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [productimage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [productimage_productid_foreign] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE TABLE [GoodsReceived] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedWarehouseManagerId] uniqueidentifier NOT NULL,
    [SupplierContactId] uniqueidentifier NOT NULL,
    [WarehouseId] uniqueidentifier NOT NULL,
    [RefereneceNumber] nvarchar(255) NOT NULL,
    [InvoiceCode] nvarchar(255) NOT NULL,
    [SourceAddress] nvarchar(255) NOT NULL,
    [SourceProvince] nvarchar(255) NOT NULL,
    [SourceDistrict] nvarchar(255) NOT NULL,
    [SourceWards] nvarchar(255) NOT NULL,
    [TotalPrice] decimal(8,2) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [goodsreceived_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [goodsreceived_createdwarehousemanagerid_foreign] FOREIGN KEY ([CreatedWarehouseManagerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [goodsreceived_suppliercontactid_foreign] FOREIGN KEY ([SupplierContactId]) REFERENCES [SupplierContact] ([Id]),
    CONSTRAINT [goodsreceived_warehouseid_foreign] FOREIGN KEY ([WarehouseId]) REFERENCES [Workplace] ([id])
);

CREATE TABLE [Invoice] (
    [Id] uniqueidentifier NOT NULL,
    [EmployeeId] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NULL,
    [GarageId] uniqueidentifier NOT NULL,
    [InvoiceType] int NOT NULL,
    [CustomerName] nvarchar(255) NOT NULL,
    [CustomerPhoneNumber] nvarchar(255) NOT NULL,
    [CustomerEmail] nvarchar(255) NOT NULL,
    [TotalPrice] decimal(8,2) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [invoice_appointmentid_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [invoice_appointmentid_foreign] FOREIGN KEY ([Id]) REFERENCES [Appointment] ([Id]),
    CONSTRAINT [invoice_customerid_foreign] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [invoice_employeeid_foreign] FOREIGN KEY ([EmployeeId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [invoice_garageid_foreign] FOREIGN KEY ([GarageId]) REFERENCES [Workplace] ([id])
);

CREATE TABLE [AppointmentDetailPackage] (
    [Id] uniqueidentifier NOT NULL,
    [PackageHistoryId] uniqueidentifier NOT NULL,
    [AppointmentId] uniqueidentifier NOT NULL,
    [UpdateByEmployeeId] uniqueidentifier NULL,
    [UpdateByCustomerId] uniqueidentifier NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [appointmentdetailpackage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [appointmentdetailpackage_appointmentid_foreign] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointment] ([Id]),
    CONSTRAINT [appointmentdetailpackage_packagehistoryid_foreign] FOREIGN KEY ([PackageHistoryId]) REFERENCES [PackageHistory] ([Id]),
    CONSTRAINT [appointmentdetailpackage_updatebycustomerid_foreign] FOREIGN KEY ([UpdateByCustomerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [appointmentdetailpackage_updatebyemployeeid_foreign] FOREIGN KEY ([UpdateByEmployeeId]) REFERENCES [Users] ([Id])
);

CREATE TABLE [PackageDetail] (
    [ServiceId] uniqueidentifier NOT NULL,
    [PackageHistoryId] uniqueidentifier NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    [Id] uniqueidentifier NOT NULL,
    CONSTRAINT [packagedetail_packagehistoryid_serviceid_primary] PRIMARY KEY ([PackageHistoryId], [ServiceId]),
    CONSTRAINT [packagedetail_packagehistoryid_foreign] FOREIGN KEY ([PackageHistoryId]) REFERENCES [PackageHistory] ([Id]),
    CONSTRAINT [packagedetail_serviceid_foreign] FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
);

CREATE TABLE [ServiceFeedBack] (
    [Id] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [FeedBack] text NOT NULL,
    [Emoji] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [servicefeedback_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [servicefeedback_customerid_foreign] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [servicefeedback_serviceid_foreign] FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
);

CREATE TABLE [ServiceHistory] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [Price] decimal(8,2) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [servicehistory_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [servicehistory_serviceid_foreign] FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
);

CREATE TABLE [ServiceImage] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [Link] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [serviceimage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [serviceimage_id_foreign] FOREIGN KEY ([Id]) REFERENCES [Service] ([Id])
);

CREATE TABLE [GoodsReceivedDetail] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [GoodsReceivedId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] decimal(8,2) NOT NULL,
    [TotalPrice] decimal(8,2) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [goodsreceiveddetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [goodsreceiveddetail_goodsreceivedid_foreign] FOREIGN KEY ([GoodsReceivedId]) REFERENCES [GoodsReceived] ([Id]),
    CONSTRAINT [goodsreceiveddetail_productid_foreign] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE TABLE [InvoicePackageDetail] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [PackageHistoryId] uniqueidentifier NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [invoicepackagedetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [invoicepackagedetail_invoiceid_foreign] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([Id]),
    CONSTRAINT [invoicepackagedetail_packagehistoryid_foreign] FOREIGN KEY ([PackageHistoryId]) REFERENCES [PackageHistory] ([Id])
);

CREATE TABLE [PackageUsage] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceAppointmentId] uniqueidentifier NOT NULL,
    [PackageHistoryId] uniqueidentifier NOT NULL,
    [CustomerCarId] uniqueidentifier NOT NULL,
    [UsagedCount] int NOT NULL,
    [StartDate] datetimeoffset NOT NULL,
    [EndDate] datetimeoffset NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [packageusage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packageusage_customercarid_foreign] FOREIGN KEY ([CustomerCarId]) REFERENCES [CustomerCar] ([Id]),
    CONSTRAINT [packageusage_invoiceappointmentid_foreign] FOREIGN KEY ([InvoiceAppointmentId]) REFERENCES [Invoice] ([Id]),
    CONSTRAINT [packageusage_packagehistoryid_foreign] FOREIGN KEY ([PackageHistoryId]) REFERENCES [PackageHistory] ([Id])
);

CREATE TABLE [AppointmentDetail] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceHistoryId] uniqueidentifier NOT NULL,
    [UpdateByEmployeeId] uniqueidentifier NULL,
    [UpdateByCustomerId] uniqueidentifier NULL,
    [AppointmentId] uniqueidentifier NOT NULL,
    [ServiceNote] text NOT NULL,
    [Status] int NOT NULL,
    [CreateAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [appointmentdetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [appointmentdetail_appointmentid_foreign] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointment] ([Id]),
    CONSTRAINT [appointmentdetail_servicehistoryid_foreign] FOREIGN KEY ([ServiceHistoryId]) REFERENCES [ServiceHistory] ([Id]),
    CONSTRAINT [appointmentdetail_updatebycustomerid_foreign] FOREIGN KEY ([UpdateByCustomerId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [appointmentdetail_updatebyemployeeid_foreign] FOREIGN KEY ([UpdateByEmployeeId]) REFERENCES [Users] ([Id])
);

CREATE TABLE [InvoiceServiceDetail] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceHistoryId] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [invoiceservicedetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [invoiceservicedetail_invoiceid_foreign] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([Id]),
    CONSTRAINT [invoiceservicedetail_servicehistoryid_foreign] FOREIGN KEY ([ServiceHistoryId]) REFERENCES [ServiceHistory] ([Id])
);

CREATE TABLE [ProductAtWarehouse] (
    [Id] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [productatwarehouse_goodsreceiveddetailid_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [productatwarehouse_goodsreceiveddetailid_foreign] FOREIGN KEY ([Id]) REFERENCES [GoodsReceivedDetail] ([Id])
);

CREATE TABLE [PackageUsageDetail] (
    [Id] uniqueidentifier NOT NULL,
    [PackageUsageId] uniqueidentifier NOT NULL,
    [AppointmentId] uniqueidentifier NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [packageusagedetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [packageusagedetail_appointmentid_foreign] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointment] ([Id]),
    CONSTRAINT [packageusagedetail_packageusageid_foreign] FOREIGN KEY ([PackageUsageId]) REFERENCES [PackageUsage] ([Id])
);

CREATE TABLE [CarConditionImage] (
    [Id] uniqueidentifier NOT NULL,
    [AppointmentDetailId] uniqueidentifier NOT NULL,
    [Link] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [ConditionStage] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [carconditionimage_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [carconditionimage_appointmentdetailid_foreign] FOREIGN KEY ([AppointmentDetailId]) REFERENCES [AppointmentDetail] ([Id])
);

CREATE TABLE [EmployeeSchedule] (
    [Id] uniqueidentifier NOT NULL,
    [AppointmentDetailId] uniqueidentifier NOT NULL,
    [EmployeeId] uniqueidentifier NOT NULL,
    [StartTime] datetimeoffset NULL,
    [EstimatedEndTime] datetimeoffset NULL,
    [ActualEndTime] datetimeoffset NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [employeeschedule_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [employeeschedule_appointmentdetailid_foreign] FOREIGN KEY ([AppointmentDetailId]) REFERENCES [AppointmentDetail] ([Id]),
    CONSTRAINT [employeeschedule_employeeid_foreign] FOREIGN KEY ([EmployeeId]) REFERENCES [Users] ([Id])
);

CREATE TABLE [GoodsIssuedDetail] (
    [Id] uniqueidentifier NOT NULL,
    [ProductAtWareHouseId] uniqueidentifier NOT NULL,
    [GoodsIssuedId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [goodsissueddetail_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [goodsissueddetail_goodsissuedid_foreign] FOREIGN KEY ([GoodsIssuedId]) REFERENCES [GoodsIssued] ([Id]),
    CONSTRAINT [goodsissueddetail_productatwarehouseid_foreign] FOREIGN KEY ([ProductAtWareHouseId]) REFERENCES [ProductAtWarehouse] ([Id])
);

CREATE TABLE [ProductAtGarage] (
    [Id] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [ProductBarcodeAtGarage] nvarchar(255) NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [productatgarage_goodsissueddetailid_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [productatgarage_goodsissueddetailid_foreign] FOREIGN KEY ([Id]) REFERENCES [GoodsIssuedDetail] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AppointmentReplacementPart] (
    [Id] uniqueidentifier NOT NULL,
    [AppointmentDetailId] uniqueidentifier NOT NULL,
    [ProductHistoryId] uniqueidentifier NOT NULL,
    [ProductAtGarageId] uniqueidentifier NOT NULL,
    [quantity] int NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [appointmentreplacementpart_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [appointmentreplacementpart_appointmentdetailid_foreign] FOREIGN KEY ([AppointmentDetailId]) REFERENCES [AppointmentDetail] ([Id]),
    CONSTRAINT [appointmentreplacementpart_productatgarageid_foreign] FOREIGN KEY ([ProductAtGarageId]) REFERENCES [ProductAtGarage] ([Id]),
    CONSTRAINT [appointmentreplacementpart_producthistoryid_foreign] FOREIGN KEY ([ProductHistoryId]) REFERENCES [ProductHistory] ([Id])
);

CREATE TABLE [InvoiceSellProduct] (
    [Id] uniqueidentifier NOT NULL,
    [ProductHistoryId] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [ProductAtGarageId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [invoicesellproduct_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [invoicesellproduct_invoiceid_foreign] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([Id]),
    CONSTRAINT [invoicesellproduct_productatgarageid_foreign] FOREIGN KEY ([ProductAtGarageId]) REFERENCES [ProductAtGarage] ([Id]),
    CONSTRAINT [invoicesellproduct_producthistoryid_foreign] FOREIGN KEY ([ProductHistoryId]) REFERENCES [ProductHistory] ([Id])
);

CREATE TABLE [ReplacementPart] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceDetailId] uniqueidentifier NOT NULL,
    [ProductHistoryId] uniqueidentifier NOT NULL,
    [ProductAtGarageId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [TotalPrice] decimal(8,2) NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [replacementpart_id_primary] PRIMARY KEY ([Id]),
    CONSTRAINT [replacementpart_invoiceappointmentdetailid_foreign] FOREIGN KEY ([InvoiceDetailId]) REFERENCES [InvoiceServiceDetail] ([Id]),
    CONSTRAINT [replacementpart_productatgarageid_foreign] FOREIGN KEY ([ProductAtGarageId]) REFERENCES [ProductAtGarage] ([Id]),
    CONSTRAINT [replacementpart_producthistoryid_foreign] FOREIGN KEY ([ProductHistoryId]) REFERENCES [ProductHistory] ([Id])
);

CREATE INDEX [appointment_customeremail_index] ON [Appointment] ([CustomerEmail]);

CREATE INDEX [appointment_customerphonenumber_customeremail_index] ON [Appointment] ([CustomerPhoneNumber], [CustomerEmail]);

CREATE INDEX [appointment_customerphonenumber_index] ON [Appointment] ([CustomerPhoneNumber]);

CREATE INDEX [IX_Appointment_ApproveByEmployeeId] ON [Appointment] ([ApproveByEmployeeId]);

CREATE INDEX [IX_Appointment_CarModelId] ON [Appointment] ([CarModelId]);

CREATE INDEX [IX_Appointment_GarageId] ON [Appointment] ([GarageId]);

CREATE INDEX [appointmentdetail_appointmentid_index] ON [AppointmentDetail] ([AppointmentId]);

CREATE INDEX [IX_AppointmentDetail_ServiceHistoryId] ON [AppointmentDetail] ([ServiceHistoryId]);

CREATE INDEX [IX_AppointmentDetail_UpdateByCustomerId] ON [AppointmentDetail] ([UpdateByCustomerId]);

CREATE INDEX [IX_AppointmentDetail_UpdateByEmployeeId] ON [AppointmentDetail] ([UpdateByEmployeeId]);

CREATE UNIQUE INDEX [appointmentdetailpackage_packagehistoryid_appointmentid_unique] ON [AppointmentDetailPackage] ([PackageHistoryId], [AppointmentId]);

CREATE INDEX [IX_AppointmentDetailPackage_AppointmentId] ON [AppointmentDetailPackage] ([AppointmentId]);

CREATE INDEX [IX_AppointmentDetailPackage_UpdateByCustomerId] ON [AppointmentDetailPackage] ([UpdateByCustomerId]);

CREATE INDEX [IX_AppointmentDetailPackage_UpdateByEmployeeId] ON [AppointmentDetailPackage] ([UpdateByEmployeeId]);

CREATE INDEX [appointmentreplacementpart_appointmentdetailid_index] ON [AppointmentReplacementPart] ([AppointmentDetailId]);

CREATE INDEX [IX_AppointmentReplacementPart_ProductAtGarageId] ON [AppointmentReplacementPart] ([ProductAtGarageId]);

CREATE INDEX [IX_AppointmentReplacementPart_ProductHistoryId] ON [AppointmentReplacementPart] ([ProductHistoryId]);

CREATE UNIQUE INDEX [brand_brandname_unique] ON [Brand] ([BrandName]);

CREATE UNIQUE INDEX [carcategory_category_unique] ON [CarCategory] ([Category]);

CREATE INDEX [carconditionimage_appointmentdetailid_index] ON [CarConditionImage] ([AppointmentDetailId]);

CREATE INDEX [carmodel_brandid_index] ON [CarModel] ([BrandId]);

CREATE INDEX [carmodel_carcategoryid_index] ON [CarModel] ([CarCategoryId]);

CREATE INDEX [carpart_carpartcategoryid_index] ON [CarPart] ([CarPartCategoryId]);

CREATE UNIQUE INDEX [carpart_partname_unique] ON [CarPart] ([PartName]);

CREATE UNIQUE INDEX [carpartcategory_partcategory_unique] ON [CarPartCategory] ([PartCategory]);

CREATE INDEX [customercar_createdbyemployeeid_index] ON [CustomerCar] ([CreatedByEmployeeId]);

CREATE INDEX [customercar_customerid_index] ON [CustomerCar] ([CustomerId]);

CREATE UNIQUE INDEX [customercar_licenseplatenumber_unique] ON [CustomerCar] ([LicensePlateNumber]);

CREATE UNIQUE INDEX [customercar_vehicleidentificationnumber_unique] ON [CustomerCar] ([VehicleIdentificationNumber]);

CREATE INDEX [IX_CustomerCar_CarModelId] ON [CustomerCar] ([CarModelId]);

CREATE UNIQUE INDEX [employeeinfo_citizenidentification_unique] ON [EmployeeInfo] ([CitizenIdentification]);

CREATE INDEX [employeeinfo_workplaceid_index] ON [EmployeeInfo] ([WorkplaceId]);

CREATE UNIQUE INDEX [employeeschedule_appointmentdetailid_employeeid_unique] ON [EmployeeSchedule] ([AppointmentDetailId], [EmployeeId]);

CREATE INDEX [employeeschedule_appointmentdetailid_index] ON [EmployeeSchedule] ([AppointmentDetailId]);

CREATE INDEX [employeeschedule_employeeid_index] ON [EmployeeSchedule] ([EmployeeId]);

CREATE INDEX [IX_GoodsIssued_CreatedWareHouseManagerId] ON [GoodsIssued] ([CreatedWareHouseManagerId]);

CREATE INDEX [IX_GoodsIssued_GarageId] ON [GoodsIssued] ([GarageId]);

CREATE INDEX [IX_GoodsIssued_WarehouseId] ON [GoodsIssued] ([WarehouseId]);

CREATE INDEX [goodsissueddetail_goodsissuedid_index] ON [GoodsIssuedDetail] ([GoodsIssuedId]);

CREATE INDEX [goodsissueddetail_productatwarehouseid_index] ON [GoodsIssuedDetail] ([ProductAtWareHouseId]);

CREATE INDEX [goodsreceived_suppliercontactid_index] ON [GoodsReceived] ([SupplierContactId]);

CREATE INDEX [goodsreceived_warehouseid_index] ON [GoodsReceived] ([WarehouseId]);

CREATE INDEX [IX_GoodsReceived_CreatedWarehouseManagerId] ON [GoodsReceived] ([CreatedWarehouseManagerId]);

CREATE INDEX [goodsreceiveddetail_goodsreceivedid_index] ON [GoodsReceivedDetail] ([GoodsReceivedId]);

CREATE INDEX [IX_GoodsReceivedDetail_ProductId] ON [GoodsReceivedDetail] ([ProductId]);

CREATE INDEX [IX_Invoice_CustomerId] ON [Invoice] ([CustomerId]);

CREATE INDEX [IX_Invoice_EmployeeId] ON [Invoice] ([EmployeeId]);

CREATE INDEX [IX_Invoice_GarageId] ON [Invoice] ([GarageId]);

CREATE INDEX [invoicepackagedetail_invoiceid_index] ON [InvoicePackageDetail] ([InvoiceId]);

CREATE UNIQUE INDEX [invoicepackagedetail_invoiceid_packagehistoryid_unique] ON [InvoicePackageDetail] ([InvoiceId], [PackageHistoryId]);

CREATE INDEX [IX_InvoicePackageDetail_PackageHistoryId] ON [InvoicePackageDetail] ([PackageHistoryId]);

CREATE INDEX [invoicesellproduct_invoiceid_index] ON [InvoiceSellProduct] ([InvoiceId]);

CREATE UNIQUE INDEX [invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique] ON [InvoiceSellProduct] ([ProductHistoryId], [InvoiceId], [ProductAtGarageId]);

CREATE INDEX [IX_InvoiceSellProduct_ProductAtGarageId] ON [InvoiceSellProduct] ([ProductAtGarageId]);

CREATE INDEX [invoiceservicedetail_invoiceid_index] ON [InvoiceServiceDetail] ([InvoiceId]);

CREATE UNIQUE INDEX [invoiceservicedetail_invoiceid_servicehistoryid_unique] ON [InvoiceServiceDetail] ([InvoiceId], [ServiceHistoryId]);

CREATE INDEX [IX_InvoiceServiceDetail_ServiceHistoryId] ON [InvoiceServiceDetail] ([ServiceHistoryId]);

CREATE INDEX [package_carcategoryid_index] ON [Package] ([CarCategoryId]);

CREATE UNIQUE INDEX [packagecondition_conditiontype_conditionvalue_unique] ON [PackageCondition] ([ConditionType], [ConditionValue]);

CREATE INDEX [packagecondition_packageid_index] ON [PackageCondition] ([PackageId]);

CREATE INDEX [IX_PackageDetail_ServiceId] ON [PackageDetail] ([ServiceId]);

CREATE INDEX [packagefeedback_customerid_index] ON [PackageFeedBack] ([CustomerId]);

CREATE INDEX [packagefeedback_packageid_index] ON [PackageFeedBack] ([PackageId]);

CREATE INDEX [packagehistory_packageid_index] ON [PackageHistory] ([PackageId]);

CREATE UNIQUE INDEX [packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique] ON [PackageHistory] ([PackageId], [PackagePrice], [ValidityPeriod], [TimeUnit], [UsageLimit]);

CREATE INDEX [IX_PackageImage_PackageId] ON [PackageImage] ([PackageId]);

CREATE INDEX [IX_PackageUsage_PackageHistoryId] ON [PackageUsage] ([PackageHistoryId]);

CREATE INDEX [packageusage_customercarid_index] ON [PackageUsage] ([CustomerCarId]);

CREATE UNIQUE INDEX [packageusage_invoiceappointmentid_unique] ON [PackageUsage] ([InvoiceAppointmentId]);

CREATE UNIQUE INDEX [packageusagedetail_appointmentid_unique] ON [PackageUsageDetail] ([AppointmentId]);

CREATE UNIQUE INDEX [packageusagedetail_packageusageid_appointmentid_unique] ON [PackageUsageDetail] ([PackageUsageId], [AppointmentId]);

CREATE INDEX [packageusagedetail_packageusageid_index] ON [PackageUsageDetail] ([PackageUsageId]);

CREATE INDEX [product_brandid_index] ON [Product] ([BrandId]);

CREATE UNIQUE INDEX [product_productbarcode_unique] ON [Product] ([ProductBarcode]);

CREATE INDEX [product_productcategoryid_index] ON [Product] ([ProductCategoryId]);

CREATE INDEX [IX_ProductCarModel_ProductId] ON [ProductCarModel] ([ProductId]);

CREATE INDEX [IX_ProductCarPart_ProductId] ON [ProductCarPart] ([ProductId]);

CREATE UNIQUE INDEX [productcategory_category_unique] ON [ProductCategory] ([Category]);

CREATE INDEX [producthistory_productid_index] ON [ProductHistory] ([ProductId]);

CREATE INDEX [productimage_productid_index] ON [ProductImage] ([ProductId]);

CREATE INDEX [IX_ReplacementPart_ProductAtGarageId] ON [ReplacementPart] ([ProductAtGarageId]);

CREATE INDEX [IX_ReplacementPart_ProductHistoryId] ON [ReplacementPart] ([ProductHistoryId]);

CREATE INDEX [replacementpart_invoiceappointmentdetailid_index] ON [ReplacementPart] ([InvoiceDetailId]);

CREATE UNIQUE INDEX [replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique] ON [ReplacementPart] ([InvoiceDetailId], [ProductHistoryId], [ProductAtGarageId]);

CREATE INDEX [IX_RoleClaims_RoleId] ON [RoleClaims] ([RoleId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [Roles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_Service_CarCategoryId] ON [Service] ([CarCategoryId]);

CREATE INDEX [service_carpartid_index] ON [Service] ([CarPartId]);

CREATE UNIQUE INDEX [service_servicecategory_worknature_action_carcategoryid_unique] ON [Service] ([ServiceCategory], [WorkNature], [Action], [CarCategoryId]);

CREATE INDEX [servicefeedback_customerid_index] ON [ServiceFeedBack] ([CustomerId]);

CREATE INDEX [servicefeedback_serviceid_index] ON [ServiceFeedBack] ([ServiceId]);

CREATE INDEX [servicehistory_serviceid_index] ON [ServiceHistory] ([ServiceId]);

CREATE INDEX [serviceimage_serviceid_index] ON [ServiceImage] ([ServiceId]);

CREATE UNIQUE INDEX [supplier_address_province_district_wards_unique] ON [Supplier] ([Address], [Province], [District], [Wards]);

CREATE UNIQUE INDEX [supplier_name_unique] ON [Supplier] ([Name]);

CREATE INDEX [suppliercontact_supplierid_index] ON [SupplierContact] ([SupplierId]);

CREATE INDEX [IX_UserClaims_UserId] ON [UserClaims] ([UserId]);

CREATE INDEX [IX_UserLogins_UserId] ON [UserLogins] ([UserId]);

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);

CREATE INDEX [EmailIndex] ON [Users] ([NormalizedEmail]);

CREATE UNIQUE INDEX [UserNameIndex] ON [Users] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

CREATE UNIQUE INDEX [users_email_unique] ON [Users] ([Email]) WHERE [Email] IS NOT NULL;

CREATE UNIQUE INDEX [users_phonenumber_unique] ON [Users] ([PhoneNumber]) WHERE [PhoneNumber] IS NOT NULL;

CREATE UNIQUE INDEX [users_username_unique] ON [Users] ([UserName]) WHERE [UserName] IS NOT NULL;

CREATE UNIQUE INDEX [workplace_address_province_district_wards_unique] ON [Workplace] ([Address], [Province], [District], [Wards]);

CREATE UNIQUE INDEX [workplace_name_unique] ON [Workplace] ([Name]);

CREATE UNIQUE INDEX [workplace_phonenumber_unique] ON [Workplace] ([PhoneNumber]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250125142930_InitDatabase', N'9.0.1');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Workplace]') AND [c].[name] = N'WorkplaceType');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Workplace] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Workplace] ALTER COLUMN [WorkplaceType] nvarchar(255) NOT NULL;

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Workplace]') AND [c].[name] = N'Status');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Workplace] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Workplace] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SupplierContact]') AND [c].[name] = N'Status');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [SupplierContact] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [SupplierContact] ALTER COLUMN [Status] nvarchar(max) NOT NULL;

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Supplier]') AND [c].[name] = N'Status');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Supplier] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Supplier] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ServiceImage]') AND [c].[name] = N'Status');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ServiceImage] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [ServiceImage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ServiceHistory]') AND [c].[name] = N'Status');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ServiceHistory] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ServiceHistory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ServiceFeedBack]') AND [c].[name] = N'Status');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ServiceFeedBack] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [ServiceFeedBack] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Service]') AND [c].[name] = N'Status');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Service] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Service] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductImage]') AND [c].[name] = N'Status');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ProductImage] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [ProductImage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductHistory]') AND [c].[name] = N'Status');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ProductHistory] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [ProductHistory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductCategory]') AND [c].[name] = N'Status');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ProductCategory] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [ProductCategory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductAtWarehouse]') AND [c].[name] = N'Status');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [ProductAtWarehouse] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [ProductAtWarehouse] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductAtGarage]') AND [c].[name] = N'Status');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [ProductAtGarage] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [ProductAtGarage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'Status');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Product] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageUsageDetail]') AND [c].[name] = N'Status');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [PackageUsageDetail] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [PackageUsageDetail] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageUsage]') AND [c].[name] = N'Status');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [PackageUsage] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [PackageUsage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageImage]') AND [c].[name] = N'Status');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [PackageImage] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [PackageImage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DROP INDEX [packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique] ON [PackageHistory];
DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageHistory]') AND [c].[name] = N'TimeUnit');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [PackageHistory] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [PackageHistory] ALTER COLUMN [TimeUnit] nvarchar(255) NOT NULL;
CREATE UNIQUE INDEX [packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique] ON [PackageHistory] ([PackageId], [PackagePrice], [ValidityPeriod], [TimeUnit], [UsageLimit]);

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageHistory]') AND [c].[name] = N'Status');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [PackageHistory] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [PackageHistory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageFeedBack]') AND [c].[name] = N'Status');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [PackageFeedBack] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [PackageFeedBack] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageDetail]') AND [c].[name] = N'Status');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [PackageDetail] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [PackageDetail] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DROP INDEX [packagecondition_conditiontype_conditionvalue_unique] ON [PackageCondition];
DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PackageCondition]') AND [c].[name] = N'ConditionType');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [PackageCondition] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [PackageCondition] ALTER COLUMN [ConditionType] nvarchar(255) NOT NULL;
CREATE UNIQUE INDEX [packagecondition_conditiontype_conditionvalue_unique] ON [PackageCondition] ([ConditionType], [ConditionValue]);

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Package]') AND [c].[name] = N'Status');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Package] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [Package] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoice]') AND [c].[name] = N'Status');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Invoice] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [Invoice] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoice]') AND [c].[name] = N'InvoiceType');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Invoice] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [Invoice] ALTER COLUMN [InvoiceType] nvarchar(255) NOT NULL;

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GoodsReceivedDetail]') AND [c].[name] = N'Status');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [GoodsReceivedDetail] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [GoodsReceivedDetail] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GoodsReceived]') AND [c].[name] = N'Status');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [GoodsReceived] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [GoodsReceived] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GoodsIssuedDetail]') AND [c].[name] = N'Status');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [GoodsIssuedDetail] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [GoodsIssuedDetail] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GoodsIssued]') AND [c].[name] = N'Status');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [GoodsIssued] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [GoodsIssued] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var29 sysname;
SELECT @var29 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeSchedule]') AND [c].[name] = N'Status');
IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeSchedule] DROP CONSTRAINT [' + @var29 + '];');
ALTER TABLE [EmployeeSchedule] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var30 sysname;
SELECT @var30 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerCar]') AND [c].[name] = N'Status');
IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [CustomerCar] DROP CONSTRAINT [' + @var30 + '];');
ALTER TABLE [CustomerCar] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var31 sysname;
SELECT @var31 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarPartCategory]') AND [c].[name] = N'Status');
IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [CarPartCategory] DROP CONSTRAINT [' + @var31 + '];');
ALTER TABLE [CarPartCategory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var32 sysname;
SELECT @var32 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarPart]') AND [c].[name] = N'Status');
IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [CarPart] DROP CONSTRAINT [' + @var32 + '];');
ALTER TABLE [CarPart] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var33 sysname;
SELECT @var33 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarModel]') AND [c].[name] = N'Status');
IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [CarModel] DROP CONSTRAINT [' + @var33 + '];');
ALTER TABLE [CarModel] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var34 sysname;
SELECT @var34 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarConditionImage]') AND [c].[name] = N'Status');
IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [CarConditionImage] DROP CONSTRAINT [' + @var34 + '];');
ALTER TABLE [CarConditionImage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var35 sysname;
SELECT @var35 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarConditionImage]') AND [c].[name] = N'ConditionStage');
IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [CarConditionImage] DROP CONSTRAINT [' + @var35 + '];');
ALTER TABLE [CarConditionImage] ALTER COLUMN [ConditionStage] nvarchar(255) NOT NULL;

DECLARE @var36 sysname;
SELECT @var36 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CarCategory]') AND [c].[name] = N'Status');
IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [CarCategory] DROP CONSTRAINT [' + @var36 + '];');
ALTER TABLE [CarCategory] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var37 sysname;
SELECT @var37 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brand]') AND [c].[name] = N'Status');
IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [Brand] DROP CONSTRAINT [' + @var37 + '];');
ALTER TABLE [Brand] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var38 sysname;
SELECT @var38 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppointmentReplacementPart]') AND [c].[name] = N'Status');
IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [AppointmentReplacementPart] DROP CONSTRAINT [' + @var38 + '];');
ALTER TABLE [AppointmentReplacementPart] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var39 sysname;
SELECT @var39 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppointmentPerDay]') AND [c].[name] = N'Status');
IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [AppointmentPerDay] DROP CONSTRAINT [' + @var39 + '];');
ALTER TABLE [AppointmentPerDay] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var40 sysname;
SELECT @var40 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppointmentDetailPackage]') AND [c].[name] = N'Status');
IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [AppointmentDetailPackage] DROP CONSTRAINT [' + @var40 + '];');
ALTER TABLE [AppointmentDetailPackage] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var41 sysname;
SELECT @var41 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppointmentDetail]') AND [c].[name] = N'Status');
IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [AppointmentDetail] DROP CONSTRAINT [' + @var41 + '];');
ALTER TABLE [AppointmentDetail] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

DECLARE @var42 sysname;
SELECT @var42 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Appointment]') AND [c].[name] = N'Status');
IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [Appointment] DROP CONSTRAINT [' + @var42 + '];');
ALTER TABLE [Appointment] ALTER COLUMN [Status] nvarchar(255) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250125143821_AddConversionForEnumType', N'9.0.1');

DROP INDEX [users_username_unique] ON [Users];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250125144226_RemoveUniqueUserNameInUserConfiguration', N'9.0.1');

COMMIT;
GO

