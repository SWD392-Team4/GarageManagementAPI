using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class MergeDevToCRUDAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentPerDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CountPerDay = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentperday_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BrandName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("brand_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carcategory_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarPartCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PartCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carpartcategory_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productcategory_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wards = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SupplierCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("supplier_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workplace",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkplaceType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workplace_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModelYear = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carmodel_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "carmodel_brandid_foreign",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "carmodel_carcategoryid_foreign",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ServiceCategory = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("package_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "package_carcategoryid_foreign",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CarPartCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carpart_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "carpart_carpartcategoryid_foreign",
                        column: x => x.CarPartCategoryId,
                        principalTable: "CarPartCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductBarcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "product_brandid_foreign",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "product_productcategoryid_foreign",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactPosition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("suppliercontact_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "suppliercontact_supplierid_foreign",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    WorkplaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CitizenIdentification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employeeinfo_userid_primary", x => x.Id);
                    table.ForeignKey(
                        name: "employeeinfo_userid_foreign",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "employeeinfo_workplaceid_foreign",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplace",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssued",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CreatedWareHouseManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InvoiceCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("goodsissued_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "goodsissued_createdwarehousemanagerid_foreign",
                        column: x => x.CreatedWareHouseManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "goodsissued_warehouseid_foreign",
                        column: x => x.WarehouseId,
                        principalTable: "Workplace",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ApproveByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstimatedAppointmentTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActualAppointmentTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EstimatedEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActualEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CarLicensePlateNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CarCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanceledReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointment_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "appointment_approvebyemployeeid_foreign",
                        column: x => x.ApproveByEmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointment_carmodelid_foreign",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointment_garageid_foreign",
                        column: x => x.GarageId,
                        principalTable: "Workplace",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerCar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleIdentificationNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customercar_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "customercar_carmodelid_foreign",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "customercar_createdbyemployeeid_foreign",
                        column: x => x.CreatedByEmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "customercar_customerid_foreign",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConditionValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packagecondition_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packagecondition_packageid_foreign",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageFeedBack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packagefeedback_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packagefeedback_customerid_foreign",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "packagefeedback_packageid_foreign",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidityPeriod = table.Column<int>(type: "int", nullable: false),
                    TimeUnit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packagehistory_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packagehistory_packageid_foreign",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packageimage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packageimage_packageid_foreign",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CarPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkNature = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedHours = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("service_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "service_carcategoryid_foreign",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "service_carpartid_foreign",
                        column: x => x.CarPartId,
                        principalTable: "CarPart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCarModel",
                columns: table => new
                {
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productcarmodel_carmodelid_productid_primary", x => new { x.CarModelId, x.ProductId });
                    table.ForeignKey(
                        name: "productcarmodel_carmodelid_foreign",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "productcarmodel_productid_foreign",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCarPart",
                columns: table => new
                {
                    CarPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productcarpart_carpartid_productid_primary", x => new { x.CarPartId, x.ProductId });
                    table.ForeignKey(
                        name: "productcarpart_carpartid_foreign",
                        column: x => x.CarPartId,
                        principalTable: "CarPart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "productcarpart_productid_foreign",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("producthistory_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "producthistory_productid_foreign",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productimage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "productimage_productid_foreign",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceived",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CreatedWarehouseManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefereneceNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InvoiceCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceProvince = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceDistrict = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceWards = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("goodsreceived_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "goodsreceived_createdwarehousemanagerid_foreign",
                        column: x => x.CreatedWarehouseManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "goodsreceived_suppliercontactid_foreign",
                        column: x => x.SupplierContactId,
                        principalTable: "SupplierContact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "goodsreceived_warehouseid_foreign",
                        column: x => x.WarehouseId,
                        principalTable: "Workplace",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_appointmentid_primary", x => x.Id);
                    table.ForeignKey(
                        name: "invoice_appointmentid_foreign",
                        column: x => x.Id,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoice_customerid_foreign",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoice_employeeid_foreign",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoice_garageid_foreign",
                        column: x => x.GarageId,
                        principalTable: "Workplace",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetailPackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PackageHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateByCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentdetailpackage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "appointmentdetailpackage_appointmentid_foreign",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetailpackage_packagehistoryid_foreign",
                        column: x => x.PackageHistoryId,
                        principalTable: "PackageHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetailpackage_updatebycustomerid_foreign",
                        column: x => x.UpdateByCustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetailpackage_updatebyemployeeid_foreign",
                        column: x => x.UpdateByEmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => new { x.ServiceId, x.PackageHistoryId });
                    table.ForeignKey(
                        name: "FK_PackageDetail_PackageHistory_PackageHistoryId",
                        column: x => x.PackageHistoryId,
                        principalTable: "PackageHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageDetail_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFeedBack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("servicefeedback_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "servicefeedback_customerid_foreign",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "servicefeedback_serviceid_foreign",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("servicehistory_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "servicehistory_serviceid_foreign",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceimage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "serviceimage_id_foreign",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivedDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsReceivedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("goodsreceiveddetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "goodsreceiveddetail_goodsreceivedid_foreign",
                        column: x => x.GoodsReceivedId,
                        principalTable: "GoodsReceived",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "goodsreceiveddetail_productid_foreign",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoicePackageDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoicepackagedetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "invoicepackagedetail_invoiceid_foreign",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoicepackagedetail_packagehistoryid_foreign",
                        column: x => x.PackageHistoryId,
                        principalTable: "PackageHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageUsage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceAppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsagedCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packageusage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packageusage_customercarid_foreign",
                        column: x => x.CustomerCarId,
                        principalTable: "CustomerCar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "packageusage_invoiceappointmentid_foreign",
                        column: x => x.InvoiceAppointmentId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "packageusage_packagehistoryid_foreign",
                        column: x => x.PackageHistoryId,
                        principalTable: "PackageHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ServiceHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateByCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentdetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "appointmentdetail_appointmentid_foreign",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetail_servicehistoryid_foreign",
                        column: x => x.ServiceHistoryId,
                        principalTable: "ServiceHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetail_updatebycustomerid_foreign",
                        column: x => x.UpdateByCustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentdetail_updatebyemployeeid_foreign",
                        column: x => x.UpdateByEmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceServiceDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ServiceHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoiceservicedetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "invoiceservicedetail_invoiceid_foreign",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoiceservicedetail_servicehistoryid_foreign",
                        column: x => x.ServiceHistoryId,
                        principalTable: "ServiceHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductAtWarehouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GoodsReceivedDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productatwarehouse_goodsreceiveddetailid_primary", x => x.Id);
                    table.ForeignKey(
                        name: "productatwarehouse_goodsreceiveddetailid_foreign",
                        column: x => x.GoodsReceivedDetailId,
                        principalTable: "GoodsReceivedDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageUsageDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageUsageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packageusagedetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "packageusagedetail_appointmentid_foreign",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "packageusagedetail_packageusageid_foreign",
                        column: x => x.PackageUsageId,
                        principalTable: "PackageUsage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarConditionImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AppointmentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConditionStage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carconditionimage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "carconditionimage_appointmentdetailid_foreign",
                        column: x => x.AppointmentDetailId,
                        principalTable: "AppointmentDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AppointmentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EstimatedEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActualEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employeeschedule_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "employeeschedule_appointmentdetailid_foreign",
                        column: x => x.AppointmentDetailId,
                        principalTable: "AppointmentDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "employeeschedule_employeeid_foreign",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssuedDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProductAtWareHouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsIssuedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("goodsissueddetail_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "goodsissueddetail_goodsissuedid_foreign",
                        column: x => x.GoodsIssuedId,
                        principalTable: "GoodsIssued",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "goodsissueddetail_productatwarehouseid_foreign",
                        column: x => x.ProductAtWareHouseId,
                        principalTable: "ProductAtWarehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductAtGarage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GoodsIssuedDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductBarcodeAtGarage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productatgarage_goodsissueddetailid_primary", x => x.Id);
                    table.ForeignKey(
                        name: "productatgarage_goodsissueddetailid_foreign",
                        column: x => x.GoodsIssuedDetailId,
                        principalTable: "GoodsIssuedDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentReplacementPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AppointmentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentreplacementpart_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "appointmentreplacementpart_appointmentdetailid_foreign",
                        column: x => x.AppointmentDetailId,
                        principalTable: "AppointmentDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentreplacementpart_productatgarageid_foreign",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "appointmentreplacementpart_producthistoryid_foreign",
                        column: x => x.ProductHistoryId,
                        principalTable: "ProductHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSellProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProductHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoicesellproduct_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "invoicesellproduct_invoiceid_foreign",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoicesellproduct_productatgarageid_foreign",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoicesellproduct_producthistoryid_foreign",
                        column: x => x.ProductHistoryId,
                        principalTable: "ProductHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReplacementPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("replacementpart_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "replacementpart_invoiceappointmentdetailid_foreign",
                        column: x => x.InvoiceDetailId,
                        principalTable: "InvoiceServiceDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "replacementpart_productatgarageid_foreign",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "replacementpart_producthistoryid_foreign",
                        column: x => x.ProductHistoryId,
                        principalTable: "ProductHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "BrandName", "CreatedAt", "ImageId", "ImageLink", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), "Kia", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/wfmlm6uwd5hnguwpbioj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422439/Brand/wfmlm6uwd5hnguwpbioj.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"), "Bugatti", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/x1iiioelr1eduzvlz6gz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420222/Brand/x1iiioelr1eduzvlz6gz.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"), "Isuzu", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zrlnucqkikvx4necltgs", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421187/Brand/zrlnucqkikvx4necltgs.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"), "Honda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kx3xsj26x6czy664rjrx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422018/Brand/kx3xsj26x6czy664rjrx.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), "Mitsubishi", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lyu7mi3lyfunwizhju9r", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423615/Brand/lyu7mi3lyfunwizhju9r.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"), "Hyundai", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/n4vgf2iu2xlddjq0fies", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422392/Brand/n4vgf2iu2xlddjq0fies.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), "Skoda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zndqli8qgxhwjmr7fyo5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421656/Brand/zndqli8qgxhwjmr7fyo5.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), "Tesla", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/tmplel6lrqlfazu1bhy0", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423698/Brand/tmplel6lrqlfazu1bhy0.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), "Volkswagen", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/gahdhvt1wvon18doxhvy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421976/Brand/gahdhvt1wvon18doxhvy.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), "Lexus", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qmp6fgd6qktgt52viovi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422492/Brand/qmp6fgd6qktgt52viovi.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), "Mini", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/w6ca9jl8nxdrtsluak70", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422988/Brand/w6ca9jl8nxdrtsluak70.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), "Ford", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qb6avmc6okdc39zg0uzz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421924/Brand/qb6avmc6okdc39zg0uzz.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), "Dodge", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/sy90i7nnlc45r3l9xxff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422553/Brand/sy90i7nnlc45r3l9xxff.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"), "Maserati", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dcfpdtrz6pqk5b7rkdfn", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420549/Brand/dcfpdtrz6pqk5b7rkdfn.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"), "Nissan", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qhnes6tgs3i6nsbft8dk", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422160/Brand/qhnes6tgs3i6nsbft8dk.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), "Toyota", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jh1rqnn0oavjilladcuy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421861/Brand/jh1rqnn0oavjilladcuy.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), "GMC", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kchfjjavlom9a4qnywvg", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423772/Brand/kchfjjavlom9a4qnywvg.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"), "Audi", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/biocmnahytbpqzvdtj3k", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422333/Brand/biocmnahytbpqzvdtj3k.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"), "Koenigsegg", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jvcdennahy5k7y8tgcin", "https://res.cloudinary.com/dt2b5qfoe/image/upload/f_auto,q_auto/v1/Brand/jvcdennahy5k7y8tgcin", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), "Suzuki", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/elsbmo9uhii4prclhfx2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421766/Brand/elsbmo9uhii4prclhfx2.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), "BMW", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/akxxqktdh9mhylbhywxj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422278/Brand/akxxqktdh9mhylbhywxj.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("61c63482-0890-497e-9013-6c1509e819eb"), "Lamborghini", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/yjzqo0gcbjye6j78cfff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420327/Brand/yjzqo0gcbjye6j78cfff.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"), "Genesis", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/bn8lek9t1qielpj33asx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421364/Brand/bn8lek9t1qielpj33asx.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"), "Lincoln", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dvxwxwkt98k2vm237hb3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421296/Brand/dvxwxwkt98k2vm237hb3.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), "Infiniti", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/vkk2c8pgwgsdov9omkyd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423282/Brand/vkk2c8pgwgsdov9omkyd.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), "Renault", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dtvvsfc8hclugj3rt6fi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422660/Brand/dtvvsfc8hclugj3rt6fi.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"), "Chevrolet", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lovrlrwiei2xukzv6zq3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422071/Brand/lovrlrwiei2xukzv6zq3.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7a021389-57ea-453d-b194-3c692735671d"), "Pagani", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/hmvywzznk4hecggkxi3p", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740419988/Brand/hmvywzznk4hecggkxi3p.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"), "Alfa Romeo", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ot1xglmql3kdxpdbwcte", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421522/Brand/ot1xglmql3kdxpdbwcte.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), "Subaru", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dpq3tgrogw3ilo6jwqoz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421768/Brand/dpq3tgrogw3ilo6jwqoz.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), "Jeep", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/xqggwm0nnswweukoaoxd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423926/Brand/xqggwm0nnswweukoaoxd.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), "Acura", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/mkyjol2tpt7jhjmaofaz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423136/Brand/mkyjol2tpt7jhjmaofaz.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"), "Aston Martin", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/hnposen4390ckqokcgcq", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421051/Brand/hnposen4390ckqokcgcq.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), "Buick", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/pbdy8azpl3zaj57jqsjh", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423195/Brand/pbdy8azpl3zaj57jqsjh.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"), "Opel", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zkby3nlbmv7path5ujwj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421597/Brand/zkby3nlbmv7path5ujwj.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), "Cadillac", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/m5yackgrajh62hnouttj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423856/Brand/m5yackgrajh62hnouttj.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"), "Rolls-Royce", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jmluhi20qavru6lcvpvc", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420078/Brand/jmluhi20qavru6lcvpvc.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), "Fiat", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ifubhf1jsnt9k6xkwhv7", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423064/Brand/ifubhf1jsnt9k6xkwhv7.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b9333f92-0e83-4343-973a-760182aea47e"), "McLaren", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/cpxc269y35mhr8pdijlr", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420144/Brand/cpxc269y35mhr8pdijlr.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), "Porsche", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/sbmjof2ugzzsuwoyj7r5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423565/Brand/sbmjof2ugzzsuwoyj7r5.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), "Ferrari", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/k8qf8xzk746w5ff9j6wx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420390/Brand/k8qf8xzk746w5ff9j6wx.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"), "Jaguar", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jbn02u6cdkbhr9suovy1", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420465/Brand/jbn02u6cdkbhr9suovy1.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), "Peugeot", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/diqhpfvayh4esj3vion2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422609/Brand/diqhpfvayh4esj3vion2.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"), "Mazda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kkxeemoptvcenvt86l3w", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423366/Brand/kkxeemoptvcenvt86l3w.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), "Chrysler", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/umb5c1sp4044krzzpo88", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422880/Brand/umb5c1sp4044krzzpo88.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), "Volvo", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/n3dc1tql2hvqydjaekzl", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423480/Brand/n3dc1tql2hvqydjaekzl.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "Land Rover", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ulvsdpqvmfvib7i6wxos", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423422/Brand/ulvsdpqvmfvib7i6wxos.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), "Mercedes-Benz", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/nkhahhkmagpxarghm1us", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422229/Brand/nkhahhkmagpxarghm1us.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("fa7fab24-c298-43cf-b990-341b29a02996"), "Saab", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lexnrqalxuzivogd6mov", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421444/Brand/lexnrqalxuzivogd6mov.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"), "Bentley", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/uu8ru4pxd9lywnclld9y", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421127/Brand/uu8ru4pxd9lywnclld9y.png", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CarCategory",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), "Station Wagon / Estate", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A station wagon (estate) features extended cargo space via a rear liftgate, making it ideal for families and long trips.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), "Minivan / MPV", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Minivans (or MPVs) are designed for family transport with spacious interiors, sliding doors, and flexible seating arrangements.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), "SUV (Sport Utility Vehicle)", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "SUVs offer a high driving position, ample cargo space, and often off-road capability, making them versatile for various terrains.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), "Sedan", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A sedan is a passenger car with a three-box configuration (engine, passenger, cargo) that offers comfort and efficiency for daily commuting.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), "Muscle Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Muscle cars are characterized by their powerful engines and aggressive styling, designed for high performance and an exhilarating drive.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), "Convertible", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A convertible offers a retractable roof for open-air driving, blending the appeal of sporty performance with leisure versatility.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"), "Coupe", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A coupe is a two-door car known for its sporty design and performance, often emphasizing style over practicality.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), "Off-Road Vehicle", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Off-road vehicles are engineered with high ground clearance and durable suspension systems, built to tackle rough terrain and challenging environments.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), "Mid-Size Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Mid-size cars balance space, comfort, and efficiency, providing versatility for both personal and family use.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6f9e4206-d0a0-4366-a997-094827005006"), "Sports Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Sports cars are engineered for high performance and agility, providing an exhilarating driving experience with a focus on speed.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), "Luxury Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Luxury cars offer premium comfort, cutting-edge technology, and superior craftsmanship for a refined and sophisticated driving experience.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("89bd23de-98f2-4de2-a753-403789911119"), "Crossover", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A crossover blends features of SUVs and sedans, offering a balance of comfort, efficiency, and a modern design.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"), "Hybrid Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Hybrid cars combine a conventional internal combustion engine with an electric motor, boosting fuel efficiency and reducing emissions.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), "Hatchback", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A hatchback features a rear door that swings upward, providing versatile cargo space while maintaining a compact footprint.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), "Roadster", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Roadsters are lightweight, two-seater cars designed for spirited driving and open-air enjoyment, emphasizing agility and performance.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), "Electric Vehicle (EV)", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Electric vehicles are powered solely by electric motors and batteries, providing a sustainable and energy-efficient alternative to traditional fuel.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), "Compact Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Compact cars are small, fuel-efficient vehicles designed for city driving while offering practicality for everyday use.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), "Pickup Truck", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Pickup trucks are built for utility with a separate cargo bed, robust performance for hauling and towing, and off-road potential.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), "Full-Size Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Full-size cars offer maximum interior space and premium comfort, ideal for long-distance travel and upscale driving experiences.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), "Subcompact Car", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Subcompact cars are even smaller than compact models, offering excellent maneuverability and efficiency for urban environments.", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CarPartCategory",
                columns: new[] { "Id", "CreatedAt", "PartCategory", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Interior Parts", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suspension", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brake System", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Exhaust System", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Engine Part", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Steering System", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cooling System", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Electrical System", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Fuel System", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Category", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "Home & Kitchen", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9bb6d84-350a-4ecb-ad5c-51d1924efee1"), "Clothing", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f4b8eff5-c7d2-4625-adb1-f4af19a922dd"), "Electronics", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), null, "Cashier", "CASHIER" },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), null, "Mechanic", "MECHANIC" },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), null, "Customer", "CUSTOMER" },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), null, "WarehouseManager", "WAREHOUSEMANAGER" },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "ImageId", "ImageLink", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"), 0, "b2e4f7e1-3c1d-4f09-bcf5-6f23d7d56d9b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic1@gmail.com", true, "Mechanic_1_first_name", "N/A", "N/A", "Mechanic_1_last_name", true, null, "MECHANIC1@gmail.com", "MECHANIC1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0921122334", true, null, null, "M1N2O3EI4NHQTPOCMMT6KJZVZUAYSQXJ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic1" },
                    { new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"), 0, "6daf287a-eba6-437d-b358-018a073059c9", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "hanhthse171828@fpt.edu.vn", true, "Hanh", "N/A", "N/A", "Trần", true, null, "HANHTHSE171828@FPT.EDU.VN", "HANHTHSE171828", "AQAAAAIAAYagAAAAEM1Ha9Qvsjr4ZYn0G3EVnXw9NCOzJAUH5/8W+aVGNQYFCdX3oOOSMtJTvohWbcohuA==", "0902596147", true, null, null, "P7XZM6YDXPFYIY32RM5TXWUN54ISRUSB", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "hanhthse171828" },
                    { new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"), 0, "c3f5a8e2-4d2e-4a10-cdf6-7e34f8e67ead", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic2@gmail.com", true, "Mechanic_2_first_name", "N/A", "N/A", "Mechanic_2_last_name", true, null, "MECHANIC2@gmail.com", "MECHANIC2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0922233445", true, null, null, "K2L3M4EI4NHQTPOCMMT6KJZVZUAYSQXK", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic2" },
                    { new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"), 0, "d4a6b9e3-5e3f-4b11-def7-8f45a9e78fbe", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic3@gmail.com", true, "Mechanic_3_first_name", "N/A", "N/A", "Mechanic_3_last_name", true, null, "MECHANIC3@gmail.com", "MECHANIC3", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0923344556", true, null, null, "P5Q6R7EI4NHQTPOCMMT6KJZVZUAYSQXL", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic3" },
                    { new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"), 0, "e5b7c0e4-6f4a-4c12-ef08-9a56bab89fcf", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic4@gmail.com", true, "Mechanic_4_first_name", "N/A", "N/A", "Mechanic_4_last_name", true, null, "MECHANIC4@gmail.com", "MECHANIC4", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0924455667", true, null, null, "S8T9U0EI4NHQTPOCMMT6KJZVZUAYSQXM", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic4" },
                    { new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"), 0, "f6c8d1e5-7a5b-4d13-ef19-ab67cbc9ad0a", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic5@gmail.com", true, "Mechanic_5_first_name", "N/A", "N/A", "Mechanic_5_last_name", true, null, "MECHANIC5@gmail.com", "MECHANIC5", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0925566778", true, null, null, "V1W2X3EI4NHQTPOCMMT6KJZVZUAYSQXN", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic5" },
                    { new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"), 0, "a7d9e2f6-8b6c-4e14-ef2a-bc78dcdabd1b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6@gmail.com", true, "Mechanic_6_first_name", "N/A", "N/A", "Mechanic_6_last_name", true, null, "MECHANIC6@gmail.com", "MECHANIC6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0926677889", true, null, null, "Y4Z5A6EI4NHQTPOCMMT6KJZVZUAYSQXO", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6" },
                    { new Guid("6789abcd-ef01-2345-6789-abcdef012345"), 0, "b8eaf307-9c7d-4f15-ef3b-cd89edcbce2c", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7@gmail.com", true, "Mechanic_7_first_name", "N/A", "N/A", "Mechanic_7_last_name", true, null, "MECHANIC7@gmail.com", "MECHANIC7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0927788990", true, null, null, "B7C8D9EI4NHQTPOCMMT6KJZVZUAYSQXP", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7" },
                    { new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1"), 0, "c8e7d1a4-22ab-48a4-9c57-12e334c5b0a6", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer2@gmail.com", true, "Customer_2_first_name", "N/A", "N/A", "Customer_2_last_name", true, null, "CUSTOMER2@gmail.com", "CUSTOMER2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0901234567", true, null, null, "A7D5Q2EI4NHYTPOCMMT6KJZVZUAYSQZT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer2" },
                    { new Guid("773d6761-8990-4408-be8f-321a7659825a"), 0, "db2f38c8-64ae-438f-a28d-34074e1e4a42", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer1@gmail.com", true, "Customer_1_first_name", "N/A", "N/A", "Customer_1_last_name", true, null, "CUSTOMER1@gmail.com", "CUSTOMER1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0902596109", true, null, null, "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer1" },
                    { new Guid("789abcde-f012-3456-789a-bcdef0123456"), 0, "c9f0a418-ad8e-4a16-ef4c-de90feacdf3d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8@gmail.com", true, "Mechanic_8_first_name", "N/A", "N/A", "Mechanic_8_last_name", true, null, "MECHANIC8@gmail.com", "MECHANIC8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0928899001", true, null, null, "E0F1G2EI4NHQTPOCMMT6KJZVZUAYSQXQ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8" },
                    { new Guid("89abcdef-0123-4567-89ab-cdef01234567"), 0, "da012529-be9f-4b17-ef5d-ef01afbd0e4e", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9@gmail.com", true, "Mechanic_9_first_name", "N/A", "N/A", "Mechanic_9_last_name", true, null, "MECHANIC9@gmail.com", "MECHANIC9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0929900112", true, null, null, "H3I4J5EI4NHQTPOCMMT6KJZVZUAYSQXR", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9" },
                    { new Guid("9abcdef0-1234-5678-9abc-def012345678"), 0, "eb12363a-cf10-4c18-ef6e-f012becd1f5f", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10@gmail.com", true, "Mechanic_10_first_name", "N/A", "N/A", "Mechanic_10_last_name", true, null, "MECHANIC10@gmail.com", "MECHANIC10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0930011223", true, null, null, "K6L7M8EI4NHQTPOCMMT6KJZVZUAYSQXS", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10" },
                    { new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f"), 0, "35ef5a68-2d9c-68f5-c157-8e94fbbd68bc", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer5@gmail.com", true, "Customer_5_first_name", "N/A", "N/A", "Customer_5_last_name", true, null, "CUSTOMER5@gmail.com", "CUSTOMER5", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0912233445", true, null, null, "P3Q2R1EI4NHQTPOCMMT6KJZVZUAYSQXD", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer5" },
                    { new Guid("abcd1234-ef56-7890-abcd-ef1234567890"), 0, "e89cf584-5b71-4a53-a6c5-4d3fa8db0a67", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier1@gmail.com", true, "Cashier_1_first_name", "N/A", "N/A", "Cashier_1_last_name", true, null, "CASHIER1@gmail.com", "CASHIER1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0931122334", true, null, null, "U2V3W4EI4NHQTPOCMMT6KJZVZUAYSQXU", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier1" },
                    { new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"), 0, "46ff6b79-3ead-4af6-d268-9fabc0cda79d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6@gmail.com", true, "Customer_6_first_name", "N/A", "N/A", "Customer_6_last_name", true, null, "CUSTOMER6@gmail.com", "CUSTOMER6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0913344556", true, null, null, "S4T5U6EI4NHQTPOCMMT6KJZVZUAYSQXE", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6" },
                    { new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"), 0, "ea354e65-522c-4931-99e2-cff427b74b14", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tannhnse171836@fpt.edu.vn", true, "Tân", "N/A", "N/A", "Nguyễn", true, null, "TANNHNSE171836@FPT.EDU.VN", "TANNHNSE171836", "AQAAAAIAAYagAAAAEIAkdif146dK+20v4+41Unot91RU8IPXdeCTz7BFJuTHznQt/EeVm4wX5Uj9l0XYmA==", "0902596148", true, null, null, "KLYQWCV3ZURKCJ7LH2HXECD27E5CC3YZ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tannhnse171836" },
                    { new Guid("bcde2345-f678-9012-bcde-f23456789012"), 0, "f90df695-6c82-4b64-b7d6-5e4fb9ec1b78", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier2@gmail.com", true, "Cashier_2_first_name", "N/A", "N/A", "Cashier_2_last_name", true, null, "CASHIER2@gmail.com", "CASHIER2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0932233445", true, null, null, "X5Y6Z7EI4NHQTPOCMMT6KJZVZUAYSQXV", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier2" },
                    { new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"), 0, "57a07c8a-4fbe-4b07-e379-afbcde1eb8ae", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7@gmail.com", true, "Customer_7_first_name", "N/A", "N/A", "Customer_7_last_name", true, null, "CUSTOMER7@gmail.com", "CUSTOMER7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0914455667", true, null, null, "V7W8X9EI4NHQTPOCMMT6KJZVZUAYSQXF", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7" },
                    { new Guid("cdef3456-7890-1234-cdef-345678901234"), 0, "a1b2c3d4-e5f6-4a7b-8c9d-0a1b2c3d4e5f", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse1@gmail.com", true, "Warehouse_1_first_name", "N/A", "N/A", "Warehouse_1_last_name", true, null, "WAREHOUSE1@gmail.com", "WAREHOUSE1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0933344556", true, null, null, "A8B9C0EI4NHQTPOCMMT6KJZVZUAYSQXW", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse1" },
                    { new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3"), 0, "13cf3846-0b7a-46d3-a935-6c72d9bc469a", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer3@gmail.com", true, "Customer_3_first_name", "N/A", "N/A", "Customer_3_last_name", true, null, "CUSTOMER3@gmail.com", "CUSTOMER3", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0909876543", true, null, null, "K5R8X9EI4NHQTPOCMMT6KJZVZUAYSQXB", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer3" },
                    { new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"), 0, "68b18d9b-50cf-4c18-f48a-bcdef1234a0b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8@gmail.com", true, "Customer_8_first_name", "N/A", "N/A", "Customer_8_last_name", true, null, "CUSTOMER8@gmail.com", "CUSTOMER8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0915566778", true, null, null, "Z1A2B3EI4NHQTPOCMMT6KJZVZUAYSQXG", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8" },
                    { new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"), 0, "db2f38c8-64ae-438f-a28d-34074e1e4a42", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "khanhbdse173224@fpt.edu.vn", true, "Khánh", "N/A", "N/A", "Bùi", true, null, "KHANHBDSE173224@FPT.EDU.VN", "KHANHBDSE173224", "AQAAAAIAAYagAAAAEM8HN46vRsKmlCeYqZXwtRzylfbdmE/IlaRy8NUGvve7BEWIU2SR93NV4bw/bEe8Iw==", "0902596149", true, null, null, "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "khanhbdse173224" },
                    { new Guid("def45678-9012-3456-def0-456789012345"), 0, "b2c3d4e5-f6a7-4b8c-9d0e-1b2c3d4e5f60", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse2@gmail.com", true, "Warehouse_2_first_name", "N/A", "N/A", "Warehouse_2_last_name", true, null, "WAREHOUSE2@gmail.com", "WAREHOUSE2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0934455667", true, null, null, "D1E2F3EI4NHQTPOCMMT6KJZVZUAYSQXX", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse2" },
                    { new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"), 0, "0834ee87-36fb-4002-844d-12adb9910e3c", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "giangnthse183257@fpt.edu.vn", true, "Giang", "N/A", "N/A", "Nguyễn", true, null, "GIANGNTHSE183257@FPT.EDU.VN", "GIANGNTHSE183257", "AQAAAAIAAYagAAAAEJxI/AyF6NXvHVHrfnu9kLzmRHOHOq8dDZwRUD9GWWkzLee8u4C8TmYw4A6R3bInDg==", "0902596142", true, null, null, "CKQPC56VA55WBN7KB3AXN4PKT4HHRQDA", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "giangnthse183257" },
                    { new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"), 0, "79c29eac-61d0-4d29-a59b-cdef2345b1c2", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9@gmail.com", true, "Customer_9_first_name", "N/A", "N/A", "Customer_9_last_name", true, null, "CUSTOMER9@gmail.com", "CUSTOMER9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0916677889", true, null, null, "C4D5E6EI4NHQTPOCMMT6KJZVZUAYSQXH", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9" },
                    { new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8"), 0, "24de4957-1c8b-57e4-b046-7d83eaac57ab", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer4@gmail.com", true, "Customer_4_first_name", "N/A", "N/A", "Customer_4_last_name", true, null, "CUSTOMER4@gmail.com", "CUSTOMER4", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0911122233", true, null, null, "L9M7N8EI4NHQTPOCMMT6KJZVZUAYSQXC", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer4" },
                    { new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"), 0, "8ad3afbd-72e1-4e3a-b6ac-def34567c2d3", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10@gmail.com", true, "Customer_10_first_name", "N/A", "N/A", "Customer_10_last_name", true, null, "CUSTOMER10@gmail.com", "CUSTOMER10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0917788990", true, null, null, "F7G8H9EI4NHQTPOCMMT6KJZVZUAYSQXI", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10" },
                    { new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"), 0, "34ab88bc-a7f7-49b1-bdda-50c2a0850b64", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tanlhnse171831@fpt.edu.vn", true, "Tân", "N/A", "N/A", "Lê", true, null, "TANLHNSE171831@FPT.EDU.VN", "TANLHNSE171831", "AQAAAAIAAYagAAAAEE8W3WHfSOaP5A3wiInfQ85VBHjz7kBqx4jZUgJenP7T1ArBJU3JQvHEguudGCBChA==", "0902596143", true, null, null, "R44AGPSXQCFMH6LRBGSWBK3PZKZP6LUT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tanlhnse171831" }
                });

            migrationBuilder.InsertData(
                table: "Workplace",
                columns: new[] { "id", "Address", "CreatedAt", "District", "Name", "PhoneNumber", "Province", "Status", "UpdatedAt", "Ward", "WorkplaceType" },
                values: new object[,]
                {
                    { new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e"), "432 Static Ave.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Another District", "Warehouse 2", "0987084321", "Another Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "60890", "Warehouse" },
                    { new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"), "124 Static St.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Static District", "Garage 2", "0983456139", "Static Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "12345", "Garage" },
                    { new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"), "123 Static St.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Static District", "Garage 1", "0983456789", "Static Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "12345", "Garage" },
                    { new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb"), "456 Static Ave.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Another District", "Warehouse 1", "0987654321", "Another Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "67890", "Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "Id", "BrandId", "CarCategoryId", "CreatedAt", "ModelName", "ModelYear", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04d301dc-d20d-4985-b124-0edfe96aeede"), new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Chiron", new DateOnly(2016, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("078bf0ae-414f-4bd3-9880-4cbef3ed1d69"), new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Passat", new DateOnly(1973, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("0af1bd43-7aca-47f2-a682-5085fdcd9254"), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Range Rover", new DateOnly(1970, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("0b079daa-528a-4a2d-bff4-c33c093c7f95"), new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "F-150", new DateOnly(1975, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("0c027854-f172-4c85-b345-5a2a50a2540e"), new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Impreza", new DateOnly(1992, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("117cdc46-af9f-4574-a012-b083c2412d50"), new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Yukon", new DateOnly(1992, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1ab3d403-fdd9-4443-87be-5bc3987c7350"), new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Model S", new DateOnly(2012, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1d509463-fa11-4729-b3e8-3b928547784e"), new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "XE", new DateOnly(2004, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1d5d22e0-80fb-4840-b1de-81587c86b3c1"), new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Vitara", new DateOnly(1988, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1e04fadf-3f54-4856-9952-f5141ad5d346"), new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Q50", new DateOnly(2013, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1e8e784c-b9d2-427d-b4ad-c16f4a088ad7"), new Guid("fa7fab24-c298-43cf-b990-341b29a02996"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "9-5", new DateOnly(2001, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1ef45e5a-6014-46ba-8edd-2ebc5bd4ec51"), new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "RDX", new DateOnly(2006, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1f9f9bce-f9f2-4ac6-a614-004ae7fd9d6a"), new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Portofino", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("237a7434-e92a-44a7-abdf-88bc1e5722f1"), new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Mazda3", new DateOnly(2003, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("247edaa4-9c42-47bb-9809-5e2e7af462bd"), new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"), new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Navigator", new DateOnly(1998, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2772a079-889e-491e-8f0a-1f5c674c32d4"), new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "CX-5", new DateOnly(2012, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2f0d3e9a-4e57-4146-a25a-b8e1ac1f109d"), new Guid("b9333f92-0e83-4343-973a-760182aea47e"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "720S", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("304937c8-e8b5-4322-9707-81ee54917f09"), new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Elantra", new DateOnly(1990, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("30b0d0a8-0d50-4025-8583-6a41747c1138"), new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Flying Spur", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("328e80cf-251d-460d-928b-345e08cf642b"), new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Agera", new DateOnly(1999, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("32d4f172-fa59-4a15-be8b-f2f9c539814d"), new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A4", new DateOnly(1994, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("35b311c9-0315-47c2-8615-6497c6161797"), new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Santa Fe", new DateOnly(2000, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("382a5533-5b8c-49ca-bb3e-242e8aa4675d"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Escalade", new DateOnly(1999, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("38801743-71f9-4265-a680-f77c0a601876"), new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Astra", new DateOnly(1991, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3977dc0e-af17-454c-a798-60c4a1c44893"), new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Regera", new DateOnly(2016, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3977dc0e-af17-454c-a798-60c4a1e44893"), new Guid("b9333f92-0e83-4343-973a-760182aea47e"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "570S", new DateOnly(2015, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3b22fb62-233c-481d-a6db-3ccc71e92414"), new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Veyron", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3de05ece-3ef8-48a2-b27d-412a9de7b52c"), new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ghibli", new DateOnly(2013, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3e65852a-2f29-4617-b145-650d02b92703"), new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "308", new DateOnly(2007, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3f0b103c-d953-40d8-bf11-8b74e0f0760c"), new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Swift", new DateOnly(1983, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("42845e68-16d7-4dca-8ecf-4d6a9424da6a"), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lancer", new DateOnly(1973, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("444cae6b-9521-4997-8619-21d8628cc14f"), new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Civic", new DateOnly(1972, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("44556cfd-a389-4b43-b7f4-b13d8374e4f8"), new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Outback", new DateOnly(1994, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("458f42e3-b7ce-4fb4-b63d-7dac89efe0a8"), new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Vantage", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("46262201-7c4f-4cc8-b0c0-b70ff84071b6"), new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "GLE", new DateOnly(2015, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4dce94b1-6053-479f-b4e2-0dbdf578305f"), new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Quattroporte", new DateOnly(1963, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5391d472-b17f-4edc-b0a0-97a825d08037"), new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "C-Class", new DateOnly(1993, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("56ee2663-5e97-48a6-934d-618ac3ff1cea"), new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ghost", new DateOnly(2003, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("57c0e845-7c0e-436a-a458-4166b8bf87e8"), new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"), new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Impala", new DateOnly(1958, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("58ad4554-54e2-4374-b20b-80eb92a5ce32"), new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "ES", new DateOnly(1989, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5fee507a-e299-4dea-b9b3-c2621a5d12cd"), new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Clio", new DateOnly(1990, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6397f180-d2b0-4244-8ef9-3c30fab15579"), new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Megane", new DateOnly(1995, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6869ab0a-21e1-4232-a060-eb01662e70cd"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "3 Series", new DateOnly(1975, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("69e9f0e8-9823-42ce-8deb-01d0a69c607c"), new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Model 3", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("69f92b34-0a15-4497-b843-6addc4e56e34"), new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Clubman", new DateOnly(2007, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6b4b10f7-50aa-41e1-99b5-0cea46b4417c"), new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "TLX", new DateOnly(2014, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6dc0c636-498f-4391-8569-d9321efc1939"), new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Panda", new DateOnly(1980, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6efa7da6-8d4a-403b-afd3-738eb0e9bd98"), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "XC90", new DateOnly(2002, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("70117f5d-6ff1-4858-8d5a-61023d7bfe97"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Grand Cherokee", new DateOnly(1992, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7182e277-e952-4879-b2f7-ab5dc04584e1"), new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Sierra", new DateOnly(1998, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("71f51929-7b86-4f0f-b576-d7ff85e90747"), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "S60", new DateOnly(2000, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("726e5e9e-1fdf-4a12-b307-2b07cc3cac2e"), new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"), new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Accord", new DateOnly(1976, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("75a19a55-2eea-4d73-abe8-a0edbb76aecb"), new Guid("fa7fab24-c298-43cf-b990-341b29a02996"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "9-3", new DateOnly(1998, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("789a06d0-ff12-4251-b03f-3709cb545736"), new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Cooper", new DateOnly(1959, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7c471545-35a0-484c-bf97-f62b6a362e32"), new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Giulia", new DateOnly(2016, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8046ad13-b68e-4c1a-b0c7-f74d15e9837a"), new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "300", new DateOnly(2004, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8095ada4-712b-4805-b806-7d00d95d6858"), new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Phantom", new DateOnly(1925, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8599ac63-b85c-41d5-b789-46b062d05e5d"), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Cayenne", new DateOnly(2002, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8e6a6ca8-fbe1-4d15-92f6-70970006fffb"), new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"), new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "D-Max", new DateOnly(2002, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("90398dd5-a925-4a42-9da0-1fb4ca4db86f"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Challenger", new DateOnly(1970, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("96924990-3a5f-439c-9890-f8c8c0851ec0"), new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "488 GTB", new DateOnly(2009, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("9869d0b2-8f87-44b6-9f48-02fe4db7d229"), new Guid("7a021389-57ea-453d-b194-3c692735671d"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Huayra", new DateOnly(2011, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("992017e3-0db0-41b4-b07a-ee6f291b3560"), new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "MU-X", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("9e285f15-c966-4154-ad18-1534ab5030ea"), new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Continental GT", new DateOnly(2003, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("9f56523e-903c-4dc4-a1a8-df7730bc1ccd"), new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corolla", new DateOnly(1966, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("9f56523e-903c-4dc4-a1a8-df7730bc1cce"), new Guid("7a021389-57ea-453d-b194-3c692735671d"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Zonda", new DateOnly(1999, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("a153be07-ddda-4b52-b540-b37fe38e6263"), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Discovery", new DateOnly(1989, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("a1575758-cb4b-4389-9b09-416dc9faff00"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "X5", new DateOnly(1999, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("a5f3f9f6-8d0a-4cb9-81cd-006b8d0ff567"), new Guid("61c63482-0890-497e-9013-6c1509e819eb"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Huracan", new DateOnly(2014, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ad6c4793-befb-49d9-ba29-f179174916db"), new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Pacifica", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b6246e92-dad1-40e7-b3b6-7962d7986d77"), new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "F-Type", new DateOnly(2013, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b695c394-dc9a-4e8d-88fc-c6b39ec3d244"), new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Octavia", new DateOnly(1996, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b78f0ea5-2866-4ec2-bb8b-ac9824babb5e"), new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"), new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corsa", new DateOnly(1982, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("bf758d69-4028-4560-a5de-758fae3dad94"), new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "G70", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("c062a7b0-8bc4-43ff-af1b-14ce393f89b3"), new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Camry", new DateOnly(1982, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("c2706a10-3499-45de-a011-cc8d332c7230"), new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enclave", new DateOnly(2008, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("c490a1a7-fc47-44b9-8839-e2cd0f854dae"), new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "MKZ", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("c6bca118-85de-4d7a-94a5-4609d0738542"), new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "508", new DateOnly(2010, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cb7fef13-3f55-4121-a274-0937d1d0c810"), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Outlander", new DateOnly(2001, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cd733067-7346-4a1e-abcc-09621c28c99d"), new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "GV80", new DateOnly(2020, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cd831f07-859d-44b9-981a-91472c7428a9"), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "911", new DateOnly(1964, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cf57a9f5-459e-48ed-8886-f073da7db496"), new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Stelvio", new DateOnly(2017, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d40079b8-bad2-4892-96cf-e33f8f64c3ba"), new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Optima", new DateOnly(2000, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d9de80a0-0669-48dc-b4fa-6c2da348ae21"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Charger", new DateOnly(1966, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("dd601366-9262-4058-a0cb-efe4706b7886"), new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Q7", new DateOnly(2005, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e0ca3b3e-b6d8-42b0-8931-86e685804b5c"), new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Superb", new DateOnly(2001, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e0da9f81-d53d-43df-a09b-54dc4d1c7056"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Wrangler", new DateOnly(1986, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e3baed85-5ab4-43b0-8648-bde97d1a27f9"), new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Golf", new DateOnly(1974, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e41ed308-cfbf-4597-8c74-d2bff7956e22"), new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Regal", new DateOnly(1973, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e41eed79-a74e-4f3e-b73b-8f75a73b9eef"), new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"), new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Camaro", new DateOnly(1966, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e63c596e-0889-453d-8772-8918ffec7bb9"), new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Mustang", new DateOnly(1964, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ec4d118f-a22a-49da-bf50-93b504b2e623"), new Guid("61c63482-0890-497e-9013-6c1509e819eb"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aventador", new DateOnly(2011, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ef025de9-516e-4a89-9a5e-381efbbf363b"), new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "QX60", new DateOnly(2004, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ef19e53a-86e5-4794-a160-a2b1009fed10"), new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), new Guid("89bd23de-98f2-4de2-a753-403789911119"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Soul", new DateOnly(2009, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f4784e36-400b-4a68-ae3c-28c0d24e0154"), new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "500", new DateOnly(1957, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5ca917c-681f-4b4b-97e0-250e6c14fe66"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "CTS", new DateOnly(2003, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f7aceb18-a3f6-441f-a243-78d65dea2520"), new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"), new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Altima", new DateOnly(1992, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("fa8da65d-fa4c-4382-9dfa-2a550a3e7633"), new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"), new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "GT-R", new DateOnly(2007, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("fc90a161-8393-4cf9-a41b-ceb04ab4d65b"), new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "RX", new DateOnly(1998, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("feba8e7f-d732-4eb0-8a12-7831c9b714dd"), new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"), new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "DB11", new DateOnly(2016, 1, 1), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CarPart",
                columns: new[] { "Id", "CarPartCategoryId", "CreatedAt", "PartName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Exhaust Pipe", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Engine Oil", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Clutch Plate", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Shock Absorber", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Air Filter", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battery", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brake Disc", "Inactive", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brake Pad", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Engine Oill", "Active", new DateTimeOffset(new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeInfo",
                columns: new[] { "Id", "CitizenIdentification", "DateOfBirth", "Gender", "WorkplaceId" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"), "78213515", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"), "1234", new DateOnly(1, 1, 1), true, new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") },
                    { new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"), "78213514", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"), "78213513", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"), "78213512", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"), "78213511", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"), "51249", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("6789abcd-ef01-2345-6789-abcdef012345"), "51248", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("789abcde-f012-3456-789a-bcdef0123456"), "51247", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("89abcdef-0123-4567-89ab-cdef01234567"), "51246", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("9abcdef0-1234-5678-9abc-def012345678"), "51245", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("abcd1234-ef56-7890-abcd-ef1234567890"), "7821354", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"), "5124", new DateOnly(1, 1, 1), true, new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") },
                    { new Guid("bcde2345-f678-9012-bcde-f23456789012"), "51243", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("cdef3456-7890-1234-cdef-345678901234"), "7821352", new DateOnly(1, 1, 1), true, new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e") },
                    { new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"), "782135", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("def45678-9012-3456-def0-456789012345"), "51241", new DateOnly(1, 1, 1), true, new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") },
                    { new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"), "616747", new DateOnly(1, 1, 1), false, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"), "66316", new DateOnly(1, 1, 1), true, new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreatedAt", "ProductBarcode", "ProductCategoryId", "ProductDescription", "ProductName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "6291041500213", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The Smartphone XYZ Pro is a premium device featuring a 6.7-inch AMOLED display with 4K resolution and HDR10+ technology. Powered by the Snapdragon 888 chipset, 12GB of RAM, and 256GB of internal storage, this phone delivers smooth performance for all tasks. The 108MP main camera supports 8K video recording, and the 5000mAh battery supports 65W fast charging.", "Toyota Camry", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "5901234123457", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The UltraBook 2023 is an ultra-thin and lightweight laptop, weighing just 1.2kg, with a 14-inch 2.5K resolution display. It is equipped with a 12th Gen Intel Core i7 processor, 16GB of RAM, and a 512GB SSD. With up to 12 hours of battery life and Thunderbolt 4 connectivity, it is perfect for mobile work and entertainment.", "Ford Mustang", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "4006381333931", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The Mirrorless Alpha Z9 is the perfect choice for professional photographers. With a 45MP full-frame sensor, 6K video recording, and 5-axis image stabilization, this camera delivers sharp and true-to-life image quality. It also offers a continuous shooting speed of up to 20 frames per second.", "Volkswagen Golf", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "9780201379624", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The SoundWave 360 Smart Speaker features an integrated AI virtual assistant and supports voice control. With 360-degree surround sound and 50W of power, it delivers an immersive audio experience. It connects wirelessly via Bluetooth 5.0 and Wi-Fi, and is compatible with smart home devices.", "Honda Civic", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("5f6789ab-cdef-0123-4567-89abcdef0123") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("6789abcd-ef01-2345-6789-abcdef012345") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("773d6761-8990-4408-be8f-321a7659825a") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("789abcde-f012-3456-789a-bcdef0123456") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("89abcdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("9abcdef0-1234-5678-9abc-def012345678") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f") },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("abcd1234-ef56-7890-abcd-ef1234567890") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629") },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("bcde2345-f678-9012-bcde-f23456789012") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f") },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("cdef3456-7890-1234-cdef-345678901234") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5") },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("def45678-9012-3456-def0-456789012345") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9") }
                });

            migrationBuilder.InsertData(
                table: "ProductHistory",
                columns: new[] { "Id", "CreatedAt", "ProductId", "ProductPrice", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 300m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), 520m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 200m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 1200m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 150m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 500m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ImageId", "ImageLink", "ProductId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/5.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/1.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/3.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/2.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/4.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Action", "CarCategoryId", "CarPartId", "CreatedAt", "Description", "EstimatedHours", "ServiceCategory", "ServiceName", "Status", "UpdatedAt", "WorkNature" },
                values: new object[,]
                {
                    { new Guid("0af80b56-c94e-4665-9660-2caf6f2faa92"), "Inspect", new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Routine engine inspection to detect early signs of wear.", 1, "Maintenance", "Regular Engine Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"), "Polish", new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Thorough cleaning and polishing of the cabin to restore a premium feel.", 2, "Detailing", "Interior Detailing & Polishing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("0fdac649-9fa0-4ed9-8b68-2c51290db904"), "Replace", new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing the air filter to maintain optimal engine performance.", 1, "Maintenance", "Air Filter Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("108faee1-bdc5-4a21-99ab-1446d7070817"), "Clean", new Guid("89bd23de-98f2-4de2-a753-403789911119"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A complete exterior wash to remove dirt and restore shine.", 1, "CarWash", "Exterior Wash & Clean", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"), "Repair", new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing malfunctioning brake components for safety.", 2, "Repair", "Brake System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("1aef6a6e-7376-42e2-ba86-50954246809e"), "Lubricate", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the differential to reduce wear and maintain performance.", 1, "Maintenance", "Differential Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("1d001811-24d7-4f17-9b99-040417ee758c"), "Update", new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Updating the infotainment software to incorporate the latest features.", 2, "Upgrade", "Infotainment Software Update", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Digital" },
                    { new Guid("1f3cc46a-b312-4100-9efc-12e3c64eb60c"), "Lubricate", new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the differential to reduce friction in off-road conditions.", 1, "Maintenance", "Differential Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("292e282b-441e-4eae-b4d3-fa66e998093d"), "Upgrade", new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the infotainment system for enhanced connectivity and features.", 3, "Upgrade", "Infotainment System Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("2e7f0139-ca6b-4261-b8b1-92025af17c23"), "Repair", new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing worn brake pads to restore optimal braking performance.", 2, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"), "Clean", new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Exterior wash designed specifically for subcompact cars.", 1, "CarWash", "Compact Car Exterior Wash", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("2ffc838c-bc9c-4f50-9aae-c1626d28f948"), "Align", new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Adjusting wheel angles to ensure even tire wear and improved handling.", 2, "Maintenance", "Wheel Alignment Service", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("3605af66-e2e0-4189-acfa-78b2151e8108"), "Repair", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the brake system to ensure reliable stopping performance.", 2, "Repair", "Brake System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("41e56392-31fc-4013-bcf1-a5a3348bce68"), "Polish", new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Comprehensive interior detailing to restore and maintain a luxurious cabin finish.", 3, "Detailing", "Full Interior Detailing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("465f7c43-42ad-446a-88a3-1de98daff9d5"), "Upgrade", new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the exhaust system to boost performance and achieve a sporty sound.", 3, "Upgrade", "Sport Exhaust Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"), "Update", new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Updating software to optimize battery performance and safety.", 2, "Upgrade", "Battery Management Software Update", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Digital" },
                    { new Guid("5699cd29-fc73-4495-86c2-d3854f3844c6"), "Replace", new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Changing engine oil to maintain performance and extend engine life.", 1, "Maintenance", "Engine Oil Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"), "Inspect", new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Inspecting brake fluid levels and condition to ensure reliable braking.", 1, "Maintenance", "Brake Fluid Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"), "Replace", new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Changing transmission fluid to ensure smooth gear shifts and prolong transmission life.", 2, "Maintenance", "Transmission Fluid Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("679799ff-ac1e-4db5-95c0-611bbb151930"), "Replace", new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing worn wiper blades to maintain clear visibility during rain.", 1, "Maintenance", "Windshield Wiper Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("6fc59687-aaf1-4fdc-821f-6fa276232515"), "Repair", new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the drive shaft to restore proper power transmission.", 3, "Repair", "Drive Shaft Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("804addd4-32e2-40e2-8836-cba4314a37cb"), "Repair", new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing suspension components to improve ride comfort and safety.", 3, "Repair", "Suspension Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"), "Repair", new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the electric motor to restore hybrid performance.", 3, "Repair", "Electric Motor Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("8e09e528-ef74-4687-993d-33447cbc7b46"), "Upgrade", new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the exhaust for enhanced performance and aggressive sound.", 3, "Upgrade", "Performance Exhaust Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("8e8f9751-ea57-41f1-aebe-653d7c2707e2"), "Lubricate", new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating engine components to reduce friction and wear.", 1, "Maintenance", "Engine Oil Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("95417c69-fadd-45f8-94f9-70b89bbded4e"), "Refill", new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Refilling the coolant system to prevent overheating.", 1, "Maintenance", "Coolant Refill Service", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"), "Repair", new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Comprehensive repair of engine components to restore peak performance.", 4, "Repair", "Engine Overhaul Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("9fc6018f-efcf-45c3-9208-a4b4eac755fb"), "Lubricate", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the power steering system for smooth steering response.", 1, "Maintenance", "Power Steering Fluid Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("a1d96353-b314-4c19-ba52-c95252d838ed"), "Upgrade", new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the infotainment system with advanced features for a superior experience.", 3, "Upgrade", "Advanced Infotainment Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"), "Inspect", new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Performing diagnostic tests to ensure hybrid system efficiency.", 1, "Maintenance", "Hybrid System Diagnostic Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("ae0292b9-460b-453b-a7e3-94f5e37c72b1"), "Clean", new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Cleaning the roof mechanism to ensure smooth operation and a spotless finish.", 1, "CarWash", "Convertible Roof Cleaning", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"), "Inspect", new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Conducting a comprehensive inspection to fine-tune engine performance.", 1, "Maintenance", "Engine Tune-Up Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"), "Repair", new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing suspension mounts to ensure durability on rough terrain.", 3, "Repair", "Suspension Mount Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("ca325344-f16a-44e5-b1cf-2b2c33375b16"), "Polish", new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Polishing leather seats to maintain a luxurious and refined interior.", 2, "Detailing", "Leather Seat Polishing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("ca9e6960-f038-4e9f-97c9-9190378129a4"), "Repair", new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing faulty suspension components to restore ride quality.", 3, "Repair", "Suspension System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("d55973be-a40f-435b-8078-d489c74d0fd7"), "Upgrade", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the ECU for improved performance and responsiveness.", 3, "Upgrade", "Performance ECU Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("dae53a3d-c422-4242-a6c6-752ad99223ec"), "Refill", new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Refilling the coolant to ensure the engine runs at optimal temperatures.", 1, "Maintenance", "Coolant Refill", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("dbd23c8d-f822-4924-926e-c47d67bfb11c"), "Restore", new Guid("89bd23de-98f2-4de2-a753-403789911119"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Restoring headlight clarity to improve nighttime visibility.", 1, "Detailing", "Headlight Restoration", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"), "Inspect", new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Inspecting high voltage cables for damage or wear to ensure EV safety.", 1, "Maintenance", "High Voltage Cable Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"), "Replace", new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing brake pads to maintain effective stopping power.", 2, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" }
                });

            migrationBuilder.CreateIndex(
                name: "appointment_customeremail_index",
                table: "Appointment",
                column: "CustomerEmail");

            migrationBuilder.CreateIndex(
                name: "appointment_customerphonenumber_customeremail_index",
                table: "Appointment",
                columns: new[] { "CustomerPhoneNumber", "CustomerEmail" });

            migrationBuilder.CreateIndex(
                name: "appointment_customerphonenumber_index",
                table: "Appointment",
                column: "CustomerPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ApproveByEmployeeId",
                table: "Appointment",
                column: "ApproveByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CarModelId",
                table: "Appointment",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_GarageId",
                table: "Appointment",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "appointmentdetail_appointmentid_index",
                table: "AppointmentDetail",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_ServiceHistoryId",
                table: "AppointmentDetail",
                column: "ServiceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_UpdateByCustomerId",
                table: "AppointmentDetail",
                column: "UpdateByCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_UpdateByEmployeeId",
                table: "AppointmentDetail",
                column: "UpdateByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "appointmentdetailpackage_packagehistoryid_appointmentid_unique",
                table: "AppointmentDetailPackage",
                columns: new[] { "PackageHistoryId", "AppointmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetailPackage_AppointmentId",
                table: "AppointmentDetailPackage",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetailPackage_UpdateByCustomerId",
                table: "AppointmentDetailPackage",
                column: "UpdateByCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetailPackage_UpdateByEmployeeId",
                table: "AppointmentDetailPackage",
                column: "UpdateByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "appointmentreplacementpart_appointmentdetailid_index",
                table: "AppointmentReplacementPart",
                column: "AppointmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReplacementPart_ProductAtGarageId",
                table: "AppointmentReplacementPart",
                column: "ProductAtGarageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReplacementPart_ProductHistoryId",
                table: "AppointmentReplacementPart",
                column: "ProductHistoryId");

            migrationBuilder.CreateIndex(
                name: "brand_brandname_unique",
                table: "Brand",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carcategory_category_unique",
                table: "CarCategory",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carconditionimage_appointmentdetailid_index",
                table: "CarConditionImage",
                column: "AppointmentDetailId");

            migrationBuilder.CreateIndex(
                name: "carmodel_brandid_index",
                table: "CarModel",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "carmodel_carcategoryid_index",
                table: "CarModel",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BrandId_CarCategoryId_ModelName_ModelYear",
                table: "CarModel",
                columns: new[] { "BrandId", "CarCategoryId", "ModelName", "ModelYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carpart_carpartcategoryid_index",
                table: "CarPart",
                column: "CarPartCategoryId");

            migrationBuilder.CreateIndex(
                name: "carpart_partname_unique",
                table: "CarPart",
                column: "PartName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carpartcategory_partcategory_unique",
                table: "CarPartCategory",
                column: "PartCategory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "customercar_createdbyemployeeid_index",
                table: "CustomerCar",
                column: "CreatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "customercar_customerid_index",
                table: "CustomerCar",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "customercar_licenseplatenumber_unique",
                table: "CustomerCar",
                column: "LicensePlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "customercar_vehicleidentificationnumber_unique",
                table: "CustomerCar",
                column: "VehicleIdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCar_CarModelId",
                table: "CustomerCar",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "employeeinfo_citizenidentification_unique",
                table: "EmployeeInfo",
                column: "CitizenIdentification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "employeeinfo_workplaceid_index",
                table: "EmployeeInfo",
                column: "WorkplaceId");

            migrationBuilder.CreateIndex(
                name: "employeeschedule_appointmentdetailid_employeeid_unique",
                table: "EmployeeSchedule",
                columns: new[] { "AppointmentDetailId", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "employeeschedule_appointmentdetailid_index",
                table: "EmployeeSchedule",
                column: "AppointmentDetailId");

            migrationBuilder.CreateIndex(
                name: "employeeschedule_employeeid_index",
                table: "EmployeeSchedule",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssued_CreatedWareHouseManagerId",
                table: "GoodsIssued",
                column: "CreatedWareHouseManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssued_WarehouseId",
                table: "GoodsIssued",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "goodsissueddetail_goodsissuedid_index",
                table: "GoodsIssuedDetail",
                column: "GoodsIssuedId");

            migrationBuilder.CreateIndex(
                name: "goodsissueddetail_productatwarehouseid_index",
                table: "GoodsIssuedDetail",
                column: "ProductAtWareHouseId");

            migrationBuilder.CreateIndex(
                name: "goodsreceived_suppliercontactid_index",
                table: "GoodsReceived",
                column: "SupplierContactId");

            migrationBuilder.CreateIndex(
                name: "goodsreceived_warehouseid_index",
                table: "GoodsReceived",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceived_CreatedWarehouseManagerId",
                table: "GoodsReceived",
                column: "CreatedWarehouseManagerId");

            migrationBuilder.CreateIndex(
                name: "goodsreceiveddetail_goodsreceivedid_index",
                table: "GoodsReceivedDetail",
                column: "GoodsReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedDetail_ProductId",
                table: "GoodsReceivedDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_EmployeeId",
                table: "Invoice",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_GarageId",
                table: "Invoice",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "invoicepackagedetail_invoiceid_index",
                table: "InvoicePackageDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "invoicepackagedetail_invoiceid_packagehistoryid_unique",
                table: "InvoicePackageDetail",
                columns: new[] { "InvoiceId", "PackageHistoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePackageDetail_PackageHistoryId",
                table: "InvoicePackageDetail",
                column: "PackageHistoryId");

            migrationBuilder.CreateIndex(
                name: "invoicesellproduct_invoiceid_index",
                table: "InvoiceSellProduct",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique",
                table: "InvoiceSellProduct",
                columns: new[] { "ProductHistoryId", "InvoiceId", "ProductAtGarageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellProduct_ProductAtGarageId",
                table: "InvoiceSellProduct",
                column: "ProductAtGarageId");

            migrationBuilder.CreateIndex(
                name: "invoiceservicedetail_invoiceid_index",
                table: "InvoiceServiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "invoiceservicedetail_invoiceid_servicehistoryid_unique",
                table: "InvoiceServiceDetail",
                columns: new[] { "InvoiceId", "ServiceHistoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServiceDetail_ServiceHistoryId",
                table: "InvoiceServiceDetail",
                column: "ServiceHistoryId");

            migrationBuilder.CreateIndex(
                name: "package_carcategoryid_index",
                table: "Package",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "packagecondition_conditiontype_conditionvalue_unique",
                table: "PackageCondition",
                columns: new[] { "PackageId", "ConditionType", "ConditionValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "packagecondition_packageid_index",
                table: "PackageCondition",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_PackageHistoryId",
                table: "PackageDetail",
                column: "PackageHistoryId");

            migrationBuilder.CreateIndex(
                name: "packagefeedback_customerid_index",
                table: "PackageFeedBack",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "packagefeedback_packageid_index",
                table: "PackageFeedBack",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "packagehistory_packageid_index",
                table: "PackageHistory",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit",
                table: "PackageHistory",
                columns: new[] { "PackageId", "PackagePrice", "ValidityPeriod", "TimeUnit", "UsageLimit" });

            migrationBuilder.CreateIndex(
                name: "IX_PackageImage_PackageId",
                table: "PackageImage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageUsage_PackageHistoryId",
                table: "PackageUsage",
                column: "PackageHistoryId");

            migrationBuilder.CreateIndex(
                name: "packageusage_customercarid_index",
                table: "PackageUsage",
                column: "CustomerCarId");

            migrationBuilder.CreateIndex(
                name: "packageusage_invoiceappointmentid_unique",
                table: "PackageUsage",
                column: "InvoiceAppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "packageusagedetail_appointmentid_unique",
                table: "PackageUsageDetail",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "packageusagedetail_packageusageid_appointmentid_unique",
                table: "PackageUsageDetail",
                columns: new[] { "PackageUsageId", "AppointmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "packageusagedetail_packageusageid_index",
                table: "PackageUsageDetail",
                column: "PackageUsageId");

            migrationBuilder.CreateIndex(
                name: "product_brandid_index",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "product_productbarcode_unique",
                table: "Product",
                column: "ProductBarcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "product_productcategoryid_index",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtGarage_GoodsIssuedDetailId",
                table: "ProductAtGarage",
                column: "GoodsIssuedDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtWarehouse_GoodsReceivedDetailId",
                table: "ProductAtWarehouse",
                column: "GoodsReceivedDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarModel_ProductId",
                table: "ProductCarModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarPart_ProductId",
                table: "ProductCarPart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "productcategory_category_unique",
                table: "ProductCategory",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "producthistory_productid_index",
                table: "ProductHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "productimage_productid_index",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementPart_ProductAtGarageId",
                table: "ReplacementPart",
                column: "ProductAtGarageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementPart_ProductHistoryId",
                table: "ReplacementPart",
                column: "ProductHistoryId");

            migrationBuilder.CreateIndex(
                name: "replacementpart_invoiceappointmentdetailid_index",
                table: "ReplacementPart",
                column: "InvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique",
                table: "ReplacementPart",
                columns: new[] { "InvoiceDetailId", "ProductHistoryId", "ProductAtGarageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CarCategoryId",
                table: "Service",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "service_carpartid_index",
                table: "Service",
                column: "CarPartId");

            migrationBuilder.CreateIndex(
                name: "service_servicecategory_worknature_action_carcategoryid_unique",
                table: "Service",
                columns: new[] { "ServiceCategory", "WorkNature", "Action", "CarCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "servicefeedback_customerid_index",
                table: "ServiceFeedBack",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "servicefeedback_serviceid_index",
                table: "ServiceFeedBack",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "servicehistory_serviceid_index",
                table: "ServiceHistory",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "serviceimage_serviceid_index",
                table: "ServiceImage",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "supplier_address_province_district_wards_unique",
                table: "Supplier",
                columns: new[] { "Address", "Province", "District", "Wards" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "supplier_name_unique",
                table: "Supplier",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "suppliercontact_supplierid_index",
                table: "SupplierContact",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "users_email_unique",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "users_phonenumber_unique",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "workplace_address_province_district_wards_unique",
                table: "Workplace",
                columns: new[] { "Address", "Province", "District", "Ward" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "workplace_name_unique",
                table: "Workplace",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "workplace_phonenumber_unique",
                table: "Workplace",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetailPackage");

            migrationBuilder.DropTable(
                name: "AppointmentPerDay");

            migrationBuilder.DropTable(
                name: "AppointmentReplacementPart");

            migrationBuilder.DropTable(
                name: "CarConditionImage");

            migrationBuilder.DropTable(
                name: "EmployeeInfo");

            migrationBuilder.DropTable(
                name: "EmployeeSchedule");

            migrationBuilder.DropTable(
                name: "InvoicePackageDetail");

            migrationBuilder.DropTable(
                name: "InvoiceSellProduct");

            migrationBuilder.DropTable(
                name: "PackageCondition");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "PackageFeedBack");

            migrationBuilder.DropTable(
                name: "PackageImage");

            migrationBuilder.DropTable(
                name: "PackageUsageDetail");

            migrationBuilder.DropTable(
                name: "ProductCarModel");

            migrationBuilder.DropTable(
                name: "ProductCarPart");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ReplacementPart");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "ServiceFeedBack");

            migrationBuilder.DropTable(
                name: "ServiceImage");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AppointmentDetail");

            migrationBuilder.DropTable(
                name: "PackageUsage");

            migrationBuilder.DropTable(
                name: "InvoiceServiceDetail");

            migrationBuilder.DropTable(
                name: "ProductAtGarage");

            migrationBuilder.DropTable(
                name: "ProductHistory");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CustomerCar");

            migrationBuilder.DropTable(
                name: "PackageHistory");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "ServiceHistory");

            migrationBuilder.DropTable(
                name: "GoodsIssuedDetail");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "GoodsIssued");

            migrationBuilder.DropTable(
                name: "ProductAtWarehouse");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarPart");

            migrationBuilder.DropTable(
                name: "GoodsReceivedDetail");

            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropTable(
                name: "CarPartCategory");

            migrationBuilder.DropTable(
                name: "GoodsReceived");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SupplierContact");

            migrationBuilder.DropTable(
                name: "Workplace");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
