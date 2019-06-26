using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalManager.Data.Migrations
{
    public partial class softdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAvailable",
                table: "Rentals",
                newName: "isArchived");

            migrationBuilder.AddColumn<bool>(
                name: "isArchived",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isArchived",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "isArchived",
                table: "Rentals",
                newName: "isAvailable");
        }
    }
}
