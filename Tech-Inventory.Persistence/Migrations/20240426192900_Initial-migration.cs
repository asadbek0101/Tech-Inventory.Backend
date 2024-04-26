using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tech_Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectClassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectClassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectClassTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectClasses_ObjectClassTypes_ObjectClassTypeId",
                        column: x => x.ObjectClassTypeId,
                        principalTable: "ObjectClassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberOfOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberOfOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberOfOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obyekts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    ObjectClassId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfOrderId = table.Column<int>(type: "integer", nullable: false),
                    ObjectClassTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Home = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    ConnectionType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obyekts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obyekts_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obyekts_NumberOfOrders_NumberOfOrderId",
                        column: x => x.NumberOfOrderId,
                        principalTable: "NumberOfOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obyekts_ObjectClassTypes_ObjectClassTypeId",
                        column: x => x.ObjectClassTypeId,
                        principalTable: "ObjectClassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obyekts_ObjectClasses_ObjectClassId",
                        column: x => x.ObjectClassId,
                        principalTable: "ObjectClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obyekts_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obyekts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Akumalators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Power = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akumalators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Akumalators_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    OriginalFileName = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<string>(type: "text", nullable: false),
                    fileType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avtomats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avtomats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avtomats_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avtomats_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    CabelTypeId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Meter = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CabelType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cabels_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FTTXs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfPort = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTTXs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FTTXs_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FTTXs_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPONs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    NumberOfPort = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPONs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPONs_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPONs_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSMs_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projectors_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projectors_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NumberOfFibers = table.Column<string>(type: "text", nullable: false),
                    TypeOfAdapter = table.Column<string>(type: "text", nullable: false),
                    CountOfPorts = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    RackType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racks_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    ShelfType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelves_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sockets_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sockets_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeedCheckings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedCheckings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeedCheckings_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeedCheckings_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stabilizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Power = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stabilizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stabilizers_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stabilizers_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stanchions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    StanchionTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanchions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stanchions_Models_StanchionTypeId",
                        column: x => x.StanchionTypeId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stanchions_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SvetoforDetectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountOfPorts = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    SvetaforType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvetoforDetectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SvetoforDetectors_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SvetoforDetectors_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Switches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountOfPorts = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    SwitchType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Switches_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Switches_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerminalServers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalServers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminalServers_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminalServers_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObyektId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Power = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ups_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ups_Obyekts_ObyektId",
                        column: x => x.ObyektId,
                        principalTable: "Obyekts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "6f818156-70d6-4ffa-a3f2-4326e2a7c3a9", "asad@gmail.com", false, false, null, "ASAD@GMAIL.COM", "ASADBEK", "AQAAAAIAAYagAAAAEF/8/nOtbJR7ht53qMFkhTw4LiLGZSg20X5hpeD7K2AABrbFD6EBVL+IsQxV4001Cg==", "998996906901", false, "59848032-3aee-4319-a058-0caedf3d933e", false, "Asadbek" });

            migrationBuilder.InsertData(
                table: "ObjectClassTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ijtimoiy obyektlar" },
                    { 2, "PDD" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Image", "Info", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(572), null, null, "test", "Qoraqalpog‘iston Respublikasi", null, null },
                    { 2, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(582), null, null, "test", "Andijon viloyati", null, null },
                    { 3, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(584), null, null, "test", "Buxoro viloyati", null, null },
                    { 4, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(585), null, null, "test", "Jizzax viloyati", null, null },
                    { 5, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(588), null, null, "test", "Qashqadaryo viloyati", null, null },
                    { 6, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(589), null, null, "test", "Navoiy viloyati", null, null },
                    { 7, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(591), null, null, "test", "Namangan viloyati", null, null },
                    { 8, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(592), null, null, "test", "Samarqand viloyati", null, null },
                    { 9, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(594), null, null, "test", "Surxondaryo viloyati", null, null },
                    { 10, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(595), null, null, "test", "Sirdaryo viloyati", null, null },
                    { 11, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(596), null, null, "test", "Toshkent viloyati", null, null },
                    { 12, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(597), null, null, "test", "Farg‘ona viloyati", null, null },
                    { 13, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(598), null, null, "test", "Xorazm viloyati", null, null },
                    { 14, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(600), null, null, "test", "Toshkent shahri", null, null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Image", "Info", "Name", "RegionId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(699), null, null, "test", "Nukus shahri", 1, null, null },
                    { 2, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(710), null, null, "test", "Amudaryo tumani", 1, null, null },
                    { 3, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(711), null, null, "test", "Beruniy tumani", 1, null, null },
                    { 4, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(712), null, null, "test", "Kegeyli tumani", 1, null, null },
                    { 5, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(715), null, null, "test", "Qanliko‘l tumani", 1, null, null },
                    { 6, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(716), null, null, "test", "Qorao‘zak tumani", 1, null, null },
                    { 7, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(717), null, null, "test", "Qo‘ng‘irot tumani", 1, null, null },
                    { 8, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(718), null, null, "test", "Mo‘ynoq tumani", 1, null, null },
                    { 9, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(720), null, null, "test", "Nukus tumani", 1, null, null },
                    { 10, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(721), null, null, "test", "Taxiatosh tumani", 1, null, null },
                    { 11, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(722), null, null, "test", "Taxtako‘pir tumani", 1, null, null },
                    { 12, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(723), null, null, "test", "To‘rtko‘l tumani", 1, null, null },
                    { 13, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(725), null, null, "test", "Xo‘jayli tumani", 1, null, null },
                    { 14, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(729), null, null, "test", "Chimboy tumani", 1, null, null },
                    { 15, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(730), null, null, "test", "Sho‘manoy tumani", 1, null, null },
                    { 16, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(745), null, null, "test", "Ellikqal’a tumani", 1, null, null },
                    { 17, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(746), null, null, "test", "Andijon shahri", 2, null, null },
                    { 18, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(747), null, null, "test", "Xonabod shahri", 2, null, null },
                    { 19, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(748), null, null, "test", "Andijon tumani", 2, null, null },
                    { 20, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(750), null, null, "test", "Asaka tumani", 2, null, null },
                    { 21, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(751), null, null, "test", "Baliqchi tumani", 2, null, null },
                    { 22, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(752), null, null, "test", "Bo‘z tumani", 2, null, null },
                    { 23, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(753), null, null, "test", "Buloqboshi tumani", 2, null, null },
                    { 24, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(754), null, null, "test", "Jalaquduq tumani", 2, null, null },
                    { 25, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(756), null, null, "test", "Izboskan tumani", 2, null, null },
                    { 26, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(757), null, null, "test", "Qo‘rg‘ontepa tumani", 2, null, null },
                    { 27, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(758), null, null, "test", "Marhamat tumani.", 2, null, null },
                    { 28, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(759), null, null, "test", "Oltinko‘l tumani", 2, null, null },
                    { 29, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(761), null, null, "test", "Paxtaobod tumani", 2, null, null },
                    { 30, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(763), null, null, "test", "Ulug‘nor tumani", 2, null, null },
                    { 31, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(764), null, null, "test", "Xo‘jaobod tumani", 2, null, null },
                    { 32, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(766), null, null, "test", "Shahrixon tumani", 2, null, null },
                    { 33, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(767), null, null, "test", "Buxoro shahri", 3, null, null },
                    { 34, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(768), null, null, "test", "Kogon shahri", 3, null, null },
                    { 35, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(770), null, null, "test", "Buxoro tumani", 3, null, null },
                    { 36, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(771), null, null, "test", "Vobkent tumani", 3, null, null },
                    { 37, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(772), null, null, "test", "Jondor tumani", 3, null, null },
                    { 38, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(773), null, null, "test", "Kogon tumani", 3, null, null },
                    { 39, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(775), null, null, "test", "Olot tumani", 3, null, null },
                    { 40, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(776), null, null, "test", "Peshku tumani", 3, null, null },
                    { 41, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(778), null, null, "test", "Romitan tumani", 3, null, null },
                    { 42, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(797), null, null, "test", "Shofirkon tumani", 3, null, null },
                    { 43, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(799), null, null, "test", "Qorovulbozor tumani", 3, null, null },
                    { 44, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(800), null, null, "test", "Qorako‘l tumani", 3, null, null },
                    { 45, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(803), null, null, "test", "G‘ijduvon tumani", 3, null, null },
                    { 46, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(804), null, null, "test", "Jizzax shahri", 4, null, null },
                    { 47, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(805), null, null, "test", "Arnasoy tumani", 4, null, null },
                    { 48, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(806), null, null, "test", "Baxmal tumani", 4, null, null },
                    { 49, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(808), null, null, "test", "Do‘stlik tumani", 4, null, null },
                    { 50, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(809), null, null, "test", "Zarbdor tumani", 4, null, null },
                    { 51, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(810), null, null, "test", "Zafarobod tumani", 4, null, null },
                    { 52, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(811), null, null, "test", "Zomin tumani", 4, null, null },
                    { 53, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(813), null, null, "test", "Mirzacho‘l tumani", 4, null, null },
                    { 54, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(814), null, null, "test", "Paxtakor tumani", 4, null, null },
                    { 55, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(815), null, null, "test", "Forish tumani", 4, null, null },
                    { 56, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(816), null, null, "test", "Sharof Rashidov tumani", 4, null, null },
                    { 57, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(820), null, null, "test", "G‘allaorol tumani", 4, null, null },
                    { 58, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(821), null, null, "test", "Yangiobod tumani", 4, null, null },
                    { 59, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(822), null, null, "test", "Qarshi shahri", 5, null, null },
                    { 60, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(823), null, null, "test", "Shahrisabz shahri", 5, null, null },
                    { 61, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(825), null, null, "test", "Dehqonobod tumani", 5, null, null },
                    { 62, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(826), null, null, "test", "Kasbi tumani", 5, null, null },
                    { 63, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(827), null, null, "test", "Kitob tumani", 5, null, null },
                    { 64, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(828), null, null, "test", "Koson tumani", 5, null, null },
                    { 65, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(830), null, null, "test", "Mirishkor tumani", 5, null, null },
                    { 66, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(832), null, null, "test", "Muborak tumani", 5, null, null },
                    { 67, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(833), null, null, "test", "Nishon tumani", 5, null, null },
                    { 68, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(834), null, null, "test", "Chiroqchi tumani", 5, null, null },
                    { 69, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(835), null, null, "test", "Shahrisabz tumani", 5, null, null },
                    { 70, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(836), null, null, "test", "Yakkabog‘ tumani", 5, null, null },
                    { 71, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(837), null, null, "test", "Qamashi tumani", 5, null, null },
                    { 72, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(839), null, null, "test", "Qarshi tumani", 5, null, null },
                    { 73, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(840), null, null, "test", "G‘uzor tumani", 5, null, null },
                    { 74, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(841), null, null, "test", "Navoiy shahri", 6, null, null },
                    { 75, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(842), null, null, "test", "Zarafshon shahri", 6, null, null },
                    { 76, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(843), null, null, "test", "Karmana tumani", 6, null, null },
                    { 77, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(844), null, null, "test", "Konimex tumani", 6, null, null },
                    { 78, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(846), null, null, "test", "Navbahor tumani", 6, null, null },
                    { 79, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(848), null, null, "test", "Nurota tumani", 6, null, null },
                    { 80, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(849), null, null, "test", "Tomdi tumani", 6, null, null },
                    { 81, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(851), null, null, "test", "Uchquduq tumani", 6, null, null },
                    { 82, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(852), null, null, "test", "Xatirchi tumani", 6, null, null },
                    { 83, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(853), null, null, "test", "Qiziltepa tumani", 6, null, null },
                    { 84, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(854), null, null, "test", "Namangan shahri", 7, null, null },
                    { 85, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(856), null, null, "test", "Kosonsoy tumani", 7, null, null },
                    { 86, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(857), null, null, "test", "Mingbuloq tumani", 7, null, null },
                    { 87, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(858), null, null, "test", "Namangan tumani", 7, null, null },
                    { 88, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(859), null, null, "test", "Norin tumani", 7, null, null },
                    { 89, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(865), null, null, "test", "Pop tumani", 7, null, null },
                    { 90, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(867), null, null, "test", "To‘raqo‘rg‘on tumani", 7, null, null },
                    { 91, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(868), null, null, "test", "Uychi tumani", 7, null, null },
                    { 92, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(869), null, null, "test", "Uchqo‘rg‘on tumani", 7, null, null },
                    { 93, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(871), null, null, "test", "Chortoq tumani", 7, null, null },
                    { 94, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(872), null, null, "test", "Chust tumani", 7, null, null },
                    { 95, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(874), null, null, "test", "Yangiqo‘rg‘on tumani", 7, null, null },
                    { 96, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(875), null, null, "test", "Samarqand shahri", 8, null, null },
                    { 97, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(877), null, null, "test", "Kattaqo‘rg‘on shahri", 8, null, null },
                    { 98, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(878), null, null, "test", "Bulung‘ur tumani", 8, null, null },
                    { 99, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(879), null, null, "test", "Jomboy tumani", 8, null, null },
                    { 100, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(880), null, null, "test", "Ishtixon tumani", 8, null, null },
                    { 101, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(883), null, null, "test", "Kattaqo‘rg‘on tumani", 8, null, null },
                    { 102, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(885), null, null, "test", "Narpay tumani", 8, null, null },
                    { 103, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(886), null, null, "test", "Nurobod tumani", 8, null, null },
                    { 104, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(887), null, null, "test", "Oqdaryo tumani", 8, null, null },
                    { 105, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(888), null, null, "test", "Payariq tumani", 8, null, null },
                    { 106, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(890), null, null, "test", "Pastdarg‘om tumani", 8, null, null },
                    { 107, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(891), null, null, "test", "Paxtachi tumani", 8, null, null },
                    { 108, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(892), null, null, "test", "Samarqand tumani", 8, null, null },
                    { 109, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(893), null, null, "test", "Toyloq tumani", 8, null, null },
                    { 110, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(895), null, null, "test", "Urgut tumani", 8, null, null },
                    { 111, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(896), null, null, "test", "Qo‘shrabot tumani", 8, null, null },
                    { 112, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(897), null, null, "test", "Termiz shahri", 9, null, null },
                    { 113, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(898), null, null, "test", "Angor tumani", 9, null, null },
                    { 114, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(899), null, null, "test", "Boysun tumani", 9, null, null },
                    { 115, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(914), null, null, "test", "Denov tumani", 9, null, null },
                    { 116, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(915), null, null, "test", "Jarqo‘rg‘on tumani", 9, null, null },
                    { 117, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(916), null, null, "test", "Muzrobod tumani", 9, null, null },
                    { 118, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(917), null, null, "test", "Oltinsoy tumani", 9, null, null },
                    { 119, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(918), null, null, "test", "Sariosiyo tumani", 9, null, null },
                    { 120, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(919), null, null, "test", "Termiz tumani", 9, null, null },
                    { 121, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(921), null, null, "test", "Uzun tumani", 9, null, null },
                    { 122, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(922), null, null, "test", "Sherobod tumani", 9, null, null },
                    { 123, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(924), null, null, "test", "Sho‘rchi tumani", 9, null, null },
                    { 124, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(925), null, null, "test", "Qiziriq tumani", 9, null, null },
                    { 125, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(930), null, null, "test", "Qumqo‘rg‘on tumani", 9, null, null },
                    { 126, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(931), null, null, "test", "Guliston shahri", 10, null, null },
                    { 127, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(933), null, null, "test", "Yangiyer shahri", 10, null, null },
                    { 128, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(934), null, null, "test", "Shirin shahri", 10, null, null },
                    { 129, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(936), null, null, "test", "Boyovut tumani", 10, null, null },
                    { 130, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(937), null, null, "test", "Guliston tumani", 10, null, null },
                    { 131, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(938), null, null, "test", "Mirzaobod tumani", 10, null, null },
                    { 132, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(939), null, null, "test", "Oqoltin tumani", 10, null, null },
                    { 133, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(941), null, null, "test", "Sardoba tumani", 10, null, null },
                    { 134, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(943), null, null, "test", "Sayxunobod tumani", 10, null, null },
                    { 135, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(944), null, null, "test", "Sirdaryo tumani", 10, null, null },
                    { 136, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(945), null, null, "test", "Xovos tumani", 10, null, null },
                    { 137, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(947), null, null, "test", "Nurafshon shahri", 11, null, null },
                    { 138, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(948), null, null, "test", "Angren shahri", 11, null, null },
                    { 139, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(950), null, null, "test", "Bekobod shahri", 11, null, null },
                    { 140, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(951), null, null, "test", "Olmaliq shahri", 11, null, null },
                    { 141, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(953), null, null, "test", "Ohangaron shahri", 11, null, null },
                    { 142, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(954), null, null, "test", "Chirchiq shahri", 11, null, null },
                    { 143, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(955), null, null, "test", "Yangiyo‘l shahri", 11, null, null },
                    { 144, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(958), null, null, "test", "Bekobod tumani", 11, null, null },
                    { 145, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(959), null, null, "test", "Bo‘ka tumani", 11, null, null },
                    { 146, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(960), null, null, "test", "Bo‘stonliq tumani", 11, null, null },
                    { 147, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(961), null, null, "test", "Zangiota tumani", 11, null, null },
                    { 148, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(963), null, null, "test", "Qibray tumani", 11, null, null },
                    { 149, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(964), null, null, "test", "Quyichirchiq tumani", 11, null, null },
                    { 150, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(965), null, null, "test", "Oqqo‘rg‘on tumani", 11, null, null },
                    { 151, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(966), null, null, "test", "Ohangaron tumani", 11, null, null },
                    { 152, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(967), null, null, "test", "Parkent tumani", 11, null, null },
                    { 153, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(969), null, null, "test", "Piskent tumani", 11, null, null },
                    { 154, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(970), null, null, "test", "Toshkent tumani", 11, null, null },
                    { 155, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(971), null, null, "test", "O‘rtachirchiq tumani", 11, null, null },
                    { 156, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(972), null, null, "test", "Chinoz tumani", 11, null, null },
                    { 157, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(974), null, null, "test", "21. Yuqorichirchiq tumani", 11, null, null },
                    { 158, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(976), null, null, "test", "22. Yangiyo‘l tumani", 11, null, null },
                    { 159, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(977), null, null, "test", "Farg‘ona shahri", 12, null, null },
                    { 160, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(978), null, null, "test", "Marg‘ilon shahri", 12, null, null },
                    { 161, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(980), null, null, "test", "Quvasoy shahri", 12, null, null },
                    { 162, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(981), null, null, "test", "Qo‘qon shahri", 12, null, null },
                    { 163, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(982), null, null, "test", "Beshariq tumani", 12, null, null },
                    { 164, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(984), null, null, "test", "Bog‘dod tumani", 12, null, null },
                    { 165, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(985), null, null, "test", "Buvayda tumani", 12, null, null },
                    { 166, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(988), null, null, "test", "Dang‘ara tumani", 12, null, null },
                    { 167, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(989), null, null, "test", "Yozyovon tumani", 12, null, null },
                    { 168, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(990), null, null, "test", "Quva tumani", 12, null, null },
                    { 169, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(992), null, null, "test", "Qo‘shtepa tumani", 12, null, null },
                    { 170, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(993), null, null, "test", "Oltiariq tumani", 12, null, null },
                    { 171, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(995), null, null, "test", "Rishton tumani", 12, null, null },
                    { 172, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(996), null, null, "test", "So‘x tumani", 12, null, null },
                    { 173, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(998), null, null, "test", "Toshloq tumani", 12, null, null },
                    { 174, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(999), null, null, "test", "O‘zbekiston tumani", 12, null, null },
                    { 175, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1000), null, null, "test", "Uchko‘prik tumani", 12, null, null },
                    { 176, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1001), null, null, "test", "Farg‘ona tumani", 12, null, null },
                    { 177, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1003), null, null, "test", "Furqat tumani", 12, null, null },
                    { 178, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1005), null, null, "test", "Urganch shahri", 13, null, null },
                    { 179, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1006), null, null, "test", "Xiva shahri", 13, null, null },
                    { 180, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1007), null, null, "test", "Bog‘ot tumani", 13, null, null },
                    { 181, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1008), null, null, "test", "Gurlan tumani", 13, null, null },
                    { 182, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1009), null, null, "test", "Urganch tumani", 13, null, null },
                    { 183, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1010), null, null, "test", "Xiva tumani", 13, null, null },
                    { 184, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1012), null, null, "test", "Xonqa tumani", 13, null, null },
                    { 185, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1014), null, null, "test", "Hazorasp tumani", 13, null, null },
                    { 186, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1015), null, null, "test", "Shovot tumani", 13, null, null },
                    { 187, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1016), null, null, "test", "Yangiariq tumani", 13, null, null },
                    { 188, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1034), null, null, "test", "Yangibozor tumani", 13, null, null },
                    { 189, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1035), null, null, "test", "Qo‘shko‘pir tumani", 13, null, null },
                    { 190, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1036), null, null, "test", "Bektemir tumani", 14, null, null },
                    { 191, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1038), null, null, "test", "Mirzo Ulug‘bek tumani", 14, null, null },
                    { 192, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1039), null, null, "test", "Mirobod tumani", 14, null, null },
                    { 193, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1041), null, null, "test", "Olmazor tumani", 14, null, null },
                    { 194, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1042), null, null, "test", "Sirg‘ali tumani", 14, null, null },
                    { 195, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1043), null, null, "test", "Uchtepa tumani", 14, null, null },
                    { 196, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1044), null, null, "test", "Chilonzor tumani", 14, null, null },
                    { 197, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1046), null, null, "test", "Shayxontohur tumani", 14, null, null },
                    { 198, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1047), null, null, "test", "Yunusobod tumani", 14, null, null },
                    { 199, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1048), null, null, "test", "Yakkasaroy tumani", 14, null, null },
                    { 200, 1, new DateTime(2024, 4, 26, 19, 28, 59, 518, DateTimeKind.Utc).AddTicks(1050), null, null, "test", "Yashnobod tumani", 14, null, null }
                });

            migrationBuilder.InsertData(
                table: "ObjectClasses",
                columns: new[] { "Id", "Name", "ObjectClassTypeId" },
                values: new object[,]
                {
                    { 1, "Maktab", 1 },
                    { 2, "Bog'cha", 1 },
                    { 3, "Magazin", 1 },
                    { 4, "OTM", 1 },
                    { 5, "Supermarket", 1 },
                    { 6, "Masjid", 1 },
                    { 7, "Istirohat bo'gi", 1 },
                    { 8, "Jamoat maskanlari", 1 },
                    { 9, "Chorraxa", 2 },
                    { 10, "Radar", 2 },
                    { 11, "3.27 yo'l beligisi", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akumalators_ObyektId",
                table: "Akumalators",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ObyektId",
                table: "Attachments",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Avtomats_ModelId",
                table: "Avtomats",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Avtomats_ObyektId",
                table: "Avtomats",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabels_ModelId",
                table: "Cabels",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabels_ObyektId",
                table: "Cabels",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_ModelId",
                table: "Cameras",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_ObyektId",
                table: "Cameras",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FTTXs_ModelId",
                table: "FTTXs",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FTTXs_ObyektId",
                table: "FTTXs",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_GPONs_ModelId",
                table: "GPONs",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GPONs_ObyektId",
                table: "GPONs",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_GSMs_ObyektId",
                table: "GSMs",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberOfOrders_ProjectId",
                table: "NumberOfOrders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectClasses_ObjectClassTypeId",
                table: "ObjectClasses",
                column: "ObjectClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_DistrictId",
                table: "Obyekts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_NumberOfOrderId",
                table: "Obyekts",
                column: "NumberOfOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_ObjectClassId",
                table: "Obyekts",
                column: "ObjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_ObjectClassTypeId",
                table: "Obyekts",
                column: "ObjectClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_ProjectId",
                table: "Obyekts",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Obyekts_RegionId",
                table: "Obyekts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projectors_ModelId",
                table: "Projectors",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projectors_ObyektId",
                table: "Projectors",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_ObyektId",
                table: "Racks",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_ObyektId",
                table: "Shelves",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_ModelId",
                table: "Sockets",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_ObyektId",
                table: "Sockets",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeedCheckings_ModelId",
                table: "SpeedCheckings",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeedCheckings_ObyektId",
                table: "SpeedCheckings",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Stabilizers_ModelId",
                table: "Stabilizers",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stabilizers_ObyektId",
                table: "Stabilizers",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Stanchions_ObyektId",
                table: "Stanchions",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Stanchions_StanchionTypeId",
                table: "Stanchions",
                column: "StanchionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SvetoforDetectors_ModelId",
                table: "SvetoforDetectors",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SvetoforDetectors_ObyektId",
                table: "SvetoforDetectors",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Switches_ModelId",
                table: "Switches",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Switches_ObyektId",
                table: "Switches",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalServers_ModelId",
                table: "TerminalServers",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalServers_ObyektId",
                table: "TerminalServers",
                column: "ObyektId");

            migrationBuilder.CreateIndex(
                name: "IX_Ups_ModelId",
                table: "Ups",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ups_ObyektId",
                table: "Ups",
                column: "ObyektId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akumalators");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Avtomats");

            migrationBuilder.DropTable(
                name: "Cabels");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "FTTXs");

            migrationBuilder.DropTable(
                name: "GPONs");

            migrationBuilder.DropTable(
                name: "GSMs");

            migrationBuilder.DropTable(
                name: "Projectors");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Sockets");

            migrationBuilder.DropTable(
                name: "SpeedCheckings");

            migrationBuilder.DropTable(
                name: "Stabilizers");

            migrationBuilder.DropTable(
                name: "Stanchions");

            migrationBuilder.DropTable(
                name: "SvetoforDetectors");

            migrationBuilder.DropTable(
                name: "Switches");

            migrationBuilder.DropTable(
                name: "TerminalServers");

            migrationBuilder.DropTable(
                name: "Ups");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Obyekts");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "NumberOfOrders");

            migrationBuilder.DropTable(
                name: "ObjectClasses");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ObjectClassTypes");
        }
    }
}
