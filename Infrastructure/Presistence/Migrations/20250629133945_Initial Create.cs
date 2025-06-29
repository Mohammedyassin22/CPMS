using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parkingZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZomeNAme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tariffs_parkingZones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "parkingZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tariffs_vehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "vehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumuber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicleOwners_vehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "vehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    OwnerIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicles_vehicleOwners_OwnerIdId",
                        column: x => x.OwnerIdId,
                        principalTable: "vehicleOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parkingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZoneIdId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parkingRecords_parkingZones_ZoneIdId",
                        column: x => x.ZoneIdId,
                        principalTable: "parkingZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parkingRecords_vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(7,3)", nullable: false),
                    ParckingRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoices_parkingRecords_ParckingRecordId",
                        column: x => x.ParckingRecordId,
                        principalTable: "parkingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<int>(type: "int", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_ParckingRecordId",
                table: "invoices",
                column: "ParckingRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parkingRecords_VehicleId",
                table: "parkingRecords",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_parkingRecords_ZoneIdId",
                table: "parkingRecords",
                column: "ZoneIdId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_InvoiceId",
                table: "payments",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_VehicleTypeId",
                table: "tariffs",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_ZoneId",
                table: "tariffs",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleOwners_VehicleTypeId",
                table: "vehicleOwners",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_OwnerIdId",
                table: "vehicles",
                column: "OwnerIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "tariffs");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "parkingRecords");

            migrationBuilder.DropTable(
                name: "parkingZones");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "vehicleOwners");

            migrationBuilder.DropTable(
                name: "vehicleTypes");
        }
    }
}
