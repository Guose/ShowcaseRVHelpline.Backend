using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    IsExteriorCleaned = table.Column<bool>(type: "bit", nullable: false),
                    IsInteriorCleaned = table.Column<bool>(type: "bit", nullable: false),
                    IsSignalsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsAwningChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsSlideoutChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMicrowaveChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsRefrigeratorFreezerChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsStoveAndOvenChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsFurnaceChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsHotwaterChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsACChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsTiresChecked = table.Column<bool>(type: "bit", nullable: false),
                    FuelLevel = table.Column<int>(type: "int", nullable: false),
                    BlackWater = table.Column<int>(type: "int", nullable: false),
                    GrayWater = table.Column<int>(type: "int", nullable: false),
                    Propane = table.Column<int>(type: "int", nullable: false),
                    IsRenterTrained = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealershipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    IsExteriorCleaned = table.Column<bool>(type: "bit", nullable: false),
                    IsInteriorCleaned = table.Column<bool>(type: "bit", nullable: false),
                    IsSignalsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsAwningChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsSlideoutChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMicrowaveChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsRefrigeratorFreezerChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsStoveAndOvenChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsFurnaceChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsHotwaterChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsACChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsTiresChecked = table.Column<bool>(type: "bit", nullable: false),
                    FuelLevel = table.Column<int>(type: "int", nullable: false),
                    BlackWater = table.Column<int>(type: "int", nullable: false),
                    GrayWater = table.Column<int>(type: "int", nullable: false),
                    Propane = table.Column<int>(type: "int", nullable: false),
                    IsCheckInComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsInsuranceClaim = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceClaimDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceClaimPhotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotosReturn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetailPrice = table.Column<double>(type: "float", nullable: false),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPercent = table.Column<double>(type: "float", nullable: false),
                    GrossProfitPercent = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionType = table.Column<byte>(type: "tinyint", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<byte>(type: "tinyint", nullable: false),
                    Permssions = table.Column<byte>(type: "tinyint", nullable: false),
                    IsRemembered = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "KnowledgeBaseLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagsId = table.Column<int>(type: "int", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoDIY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBaseLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeBaseLibraries_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionType = table.Column<byte>(type: "tinyint", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealershipContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealershipContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealershipContacts_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealershipContacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RVRenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRepeatRenter = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RVRenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RVRenter_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsW9OnFile = table.Column<bool>(type: "bit", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technician_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "KnowledgeBaseTags",
                columns: table => new
                {
                    KnowledgeBaseId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBaseTags", x => new { x.KnowledgeBaseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_KnowledgeBaseTags_KnowledgeBaseLibraries_KnowledgeBaseId",
                        column: x => x.KnowledgeBaseId,
                        principalTable: "KnowledgeBaseLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeBaseTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<byte>(type: "tinyint", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odometer = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasGenerator = table.Column<bool>(type: "bit", nullable: false),
                    GeneratorDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratorHours = table.Column<int>(type: "int", nullable: false),
                    HasSlideout = table.Column<bool>(type: "bit", nullable: false),
                    SlideoutDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPropane = table.Column<bool>(type: "bit", nullable: false),
                    PropaneDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasFurnace = table.Column<bool>(type: "bit", nullable: false),
                    FurnaceDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasWaterHeater = table.Column<bool>(type: "bit", nullable: false),
                    WaterHeaterDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRange = table.Column<bool>(type: "bit", nullable: false),
                    RangeDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRefrigerator = table.Column<bool>(type: "bit", nullable: false),
                    RefrigeratorDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTV = table.Column<bool>(type: "bit", nullable: false),
                    TVDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasMicrowave = table.Column<bool>(type: "bit", nullable: false),
                    HasCDPlayer = table.Column<bool>(type: "bit", nullable: false),
                    HasDVDPlayer = table.Column<bool>(type: "bit", nullable: false),
                    HasAwning = table.Column<bool>(type: "bit", nullable: false),
                    HasRearVisionCamera = table.Column<bool>(type: "bit", nullable: false),
                    HasRoofAC = table.Column<bool>(type: "bit", nullable: false),
                    HasInteriorShower = table.Column<bool>(type: "bit", nullable: false),
                    HasExteriorShower = table.Column<bool>(type: "bit", nullable: false),
                    HasiPodDocking = table.Column<bool>(type: "bit", nullable: false),
                    HasNavigation = table.Column<bool>(type: "bit", nullable: false),
                    Sleeps = table.Column<int>(type: "int", nullable: false),
                    SeatbeltsQty = table.Column<int>(type: "int", nullable: false),
                    HasFireExtingusher = table.Column<bool>(type: "bit", nullable: false),
                    HasSnowChains = table.Column<bool>(type: "bit", nullable: false),
                    HasFireplace = table.Column<bool>(type: "bit", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerVehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RVRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RVRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RVRentals_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RVRentals_CustomerVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RVRentals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RVRentals_RVRenter_RenterId",
                        column: x => x.RenterId,
                        principalTable: "RVRenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RVRentals_Returns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRvRenters",
                columns: table => new
                {
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RentalStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRvRenters", x => new { x.RenterId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleRvRenters_CustomerVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleRvRenters_RVRenter_RenterId",
                        column: x => x.RenterId,
                        principalTable: "RVRenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCaseCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceKType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KnowledgeBaseLibraryId = table.Column<int>(type: "int", nullable: false),
                    ServiceCaseId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCaseCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCaseCalls_KnowledgeBaseLibraries_KnowledgeBaseLibraryId",
                        column: x => x.KnowledgeBaseLibraryId,
                        principalTable: "KnowledgeBaseLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedServiceCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallType = table.Column<byte>(type: "tinyint", nullable: true),
                    OpenedBy = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sev = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerVehicleId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    ServiceCaseCallId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCases_CustomerVehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceCases_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceCases_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCases_ServiceCaseCalls_ServiceCaseCallId",
                        column: x => x.ServiceCaseCallId,
                        principalTable: "ServiceCaseCalls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceCases_Technician_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCaseTags",
                columns: table => new
                {
                    ServiceCaseId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCaseTags", x => new { x.ServiceCaseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ServiceCaseTags_ServiceCases_ServiceCaseId",
                        column: x => x.ServiceCaseId,
                        principalTable: "RelatedServiceCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCaseTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SubscriptionId",
                table: "Customers",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVehicles_CustomerId",
                table: "CustomerVehicles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipContacts_DealershipId",
                table: "DealershipContacts",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipContacts_UserId",
                table: "DealershipContacts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBaseLibraries_TagsId",
                table: "KnowledgeBaseLibraries",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBaseTags_TagId",
                table: "KnowledgeBaseTags",
                column: "TagId");

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
                name: "IX_RVRentals_CheckoutId",
                table: "RVRentals",
                column: "CheckoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_EmployeeId",
                table: "RVRentals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_RenterId",
                table: "RVRentals",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_ReturnId",
                table: "RVRentals",
                column: "ReturnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_VehicleId",
                table: "RVRentals",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RVRenter_UserId",
                table: "RVRenter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCaseCalls_KnowledgeBaseLibraryId",
                table: "ServiceCaseCalls",
                column: "KnowledgeBaseLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCaseCalls_ServiceCaseId",
                table: "ServiceCaseCalls",
                column: "ServiceCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_CustomerId",
                table: "RelatedServiceCases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_CustomerVehicleId",
                table: "RelatedServiceCases",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_EmployeeId",
                table: "RelatedServiceCases",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_ServiceCaseCallId",
                table: "RelatedServiceCases",
                column: "ServiceCaseCallId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_TechnicianId",
                table: "RelatedServiceCases",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCaseTags_TagId",
                table: "ServiceCaseTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_UserId",
                table: "Technician",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "IX_VehicleRvRenters_VehicleId",
                table: "VehicleRvRenters",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCaseCalls_ServiceCases_ServiceCaseId",
                table: "ServiceCaseCalls",
                column: "ServiceCaseId",
                principalTable: "RelatedServiceCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Technician_Users_UserId",
                table: "Technician");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerVehicles_Customers_CustomerId",
                table: "CustomerVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCases_Customers_CustomerId",
                table: "RelatedServiceCases");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeBaseLibraries_Tags_TagsId",
                table: "KnowledgeBaseLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCalls_KnowledgeBaseLibraries_KnowledgeBaseLibraryId",
                table: "ServiceCaseCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCases_CustomerVehicles_CustomerVehicleId",
                table: "RelatedServiceCases");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCases_Employees_EmployeeId",
                table: "RelatedServiceCases");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCalls_ServiceCases_ServiceCaseId",
                table: "ServiceCaseCalls");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "DealershipContacts");

            migrationBuilder.DropTable(
                name: "KnowledgeBaseTags");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RVRentals");

            migrationBuilder.DropTable(
                name: "ServiceCaseTags");

            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VehicleRvRenters");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RVRenter");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "KnowledgeBaseLibraries");

            migrationBuilder.DropTable(
                name: "CustomerVehicles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RelatedServiceCases");

            migrationBuilder.DropTable(
                name: "ServiceCaseCalls");

            migrationBuilder.DropTable(
                name: "Technician");
        }
    }
}
