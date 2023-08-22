using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorServicesAndWashApp.Migrations
{
    public partial class Change_UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "city",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "homeTown",
                table: "UserDetails");

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvincesId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "homeTown",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

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
    }
}
