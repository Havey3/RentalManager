using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalManager.Data.Migrations
{
    public partial class addingListtoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals");

            migrationBuilder.CreateIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals");

            migrationBuilder.CreateIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals",
                column: "userId",
                unique: true);
        }
    }
}
