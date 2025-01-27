using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentPerDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LinkLogo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModelYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductBarcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkplaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenIdentification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WorkPlaceType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employeeinfo_userid_primary", x => x.Id);
                    table.ForeignKey(
                        name: "employeeinfo_userid_foreign",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "employeeinfo_workplaceid_foreign",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplace",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssued",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedWareHouseManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                        name: "goodsissued_garageid_foreign",
                        column: x => x.GarageId,
                        principalTable: "Workplace",
                        principalColumn: "id");
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ExpectedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CarLicensePlateNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CarCondition = table.Column<string>(type: "text", nullable: true),
                    CanceledReason = table.Column<string>(type: "text", nullable: true),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedBack = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackagePrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValidityPeriod = table.Column<int>(type: "int", nullable: false),
                    TimeUnit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WorkNature = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedWarehouseManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefereneceNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InvoiceCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceProvince = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceDistrict = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceWards = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    PackageHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("packagedetail_packagehistoryid_serviceid_primary", x => new { x.PackageHistoryId, x.ServiceId });
                    table.ForeignKey(
                        name: "packagedetail_packagehistoryid_foreign",
                        column: x => x.PackageHistoryId,
                        principalTable: "PackageHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "packagedetail_serviceid_foreign",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceFeedBack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedBack = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceimage_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "serviceimage_id_foreign",
                        column: x => x.Id,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivedDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsReceivedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateByCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceNote = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        column: x => x.Id,
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        column: x => x.Id,
                        principalTable: "GoodsIssuedDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentReplacementPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 0, "1f25afc3-f1d2-4d8f-816b-b803b18af7d3", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "admin@elearning.com", true, null, null, null, false, null, "ADMIN@ELEARNING.COM", "admin@elearning.com", "AQAAAAIAAYagAAAAEIOxpvAlk80ZqL/LYuROLFz65a5y1iLek5cxtcEZ3ge+sTLGCKua1UUpGWbzZmsVlA==", null, false, null, null, "fd0ec05e-e488-4ea9-aeef-b275e155112f", "Active", false, new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "admin@elearning.com" });

            migrationBuilder.InsertData(
                table: "Workplace",
                columns: new[] { "id", "Address", "CreatedAt", "District", "Name", "PhoneNumber", "Province", "Status", "UpdatedAt", "Ward", "WorkplaceType" },
                values: new object[,]
                {
                    { new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"), "123 Static St.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Static District", "Static Company 1", "0123456789", "Static Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "12345", "Garage" },
                    { new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb"), "456 Static Ave.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Another District", "Static Company 2", "0987654321", "Another Province", "Inactive", new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "67890", "Warehouse" }
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
                name: "IX_GoodsIssued_GarageId",
                table: "GoodsIssued",
                column: "GarageId");

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
                columns: new[] { "ConditionType", "ConditionValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "packagecondition_packageid_index",
                table: "PackageCondition",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_ServiceId",
                table: "PackageDetail",
                column: "ServiceId");

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
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique",
                table: "PackageHistory",
                columns: new[] { "PackageId", "PackagePrice", "ValidityPeriod", "TimeUnit", "UsageLimit" },
                unique: true);

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
