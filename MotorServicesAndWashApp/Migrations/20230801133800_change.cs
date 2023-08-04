using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorServicesAndWashApp.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ProviceId",
                table: "Districts");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictsId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "ProviceId",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
