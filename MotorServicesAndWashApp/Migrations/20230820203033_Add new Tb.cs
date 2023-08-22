using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorServicesAndWashApp.Migrations
{
    public partial class AddnewTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts");

            migrationBuilder.AlterColumn<int>(
                name: "ProvincesId",
                table: "Districts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictsId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DayOfWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarDays = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeeks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenter",
                columns: table => new
                {
                    ServiceCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotlineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvincesId = table.Column<int>(type: "int", nullable: true),
                    DistrictsId = table.Column<int>(type: "int", nullable: true),
                    CitiesId = table.Column<int>(type: "int", nullable: true),
                    VehicleTypesVehicleTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenter", x => x.ServiceCenterId);
                    table.ForeignKey(
                        name: "FK_ServiceCenter_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "CitiesId");
                    table.ForeignKey(
                        name: "FK_ServiceCenter_Districts_DistrictsId",
                        column: x => x.DistrictsId,
                        principalTable: "Districts",
                        principalColumn: "DistrictsId");
                    table.ForeignKey(
                        name: "FK_ServiceCenter_Provinces_ProvincesId",
                        column: x => x.ProvincesId,
                        principalTable: "Provinces",
                        principalColumn: "ProvincesId");
                    table.ForeignKey(
                        name: "FK_ServiceCenter_VehicleTypes_VehicleTypesVehicleTypeId",
                        column: x => x.VehicleTypesVehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "DaysOfClose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCenterId = table.Column<int>(type: "int", nullable: true),
                    dayOfWeeksModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfClose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysOfClose_DayOfWeeks_dayOfWeeksModelId",
                        column: x => x.dayOfWeeksModelId,
                        principalTable: "DayOfWeeks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DaysOfClose_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenterLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenterLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCenterLogin_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypesVehicleTypeId = table.Column<int>(type: "int", nullable: true),
                    ServiceCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceVehicles_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId");
                    table.ForeignKey(
                        name: "FK_ServiceVehicles_VehicleTypes_VehicleTypesVehicleTypeId",
                        column: x => x.VehicleTypesVehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysOfClose_dayOfWeeksModelId",
                table: "DaysOfClose",
                column: "dayOfWeeksModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysOfClose_ServiceCenterId",
                table: "DaysOfClose",
                column: "ServiceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_CitiesId",
                table: "ServiceCenter",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_DistrictsId",
                table: "ServiceCenter",
                column: "DistrictsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_ProvincesId",
                table: "ServiceCenter",
                column: "ProvincesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_VehicleTypesVehicleTypeId",
                table: "ServiceCenter",
                column: "VehicleTypesVehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenterLogin_ServiceCenterId",
                table: "ServiceCenterLogin",
                column: "ServiceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceVehicles_ServiceCenterId",
                table: "ServiceVehicles",
                column: "ServiceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceVehicles_VehicleTypesVehicleTypeId",
                table: "ServiceVehicles",
                column: "VehicleTypesVehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities",
                column: "DistrictsId",
                principalTable: "Districts",
                principalColumn: "DistrictsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts",
                column: "ProvincesId",
                principalTable: "Provinces",
                principalColumn: "ProvincesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts");

            migrationBuilder.DropTable(
                name: "DaysOfClose");

            migrationBuilder.DropTable(
                name: "ServiceCenterLogin");

            migrationBuilder.DropTable(
                name: "ServiceVehicles");

            migrationBuilder.DropTable(
                name: "DayOfWeeks");

            migrationBuilder.DropTable(
                name: "ServiceCenter");

            migrationBuilder.AlterColumn<int>(
                name: "ProvincesId",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictsId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities",
                column: "DistrictsId",
                principalTable: "Districts",
                principalColumn: "DistrictsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts",
                column: "ProvincesId",
                principalTable: "Provinces",
                principalColumn: "ProvincesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
