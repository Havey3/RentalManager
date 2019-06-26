using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalManager.Data.Migrations
{
    public partial class updatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Rentals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Rentals",
                nullable: false,
                defaultValue: 0);
        }
    }
}
