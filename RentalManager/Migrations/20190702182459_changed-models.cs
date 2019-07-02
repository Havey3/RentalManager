using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalManager.Data.Migrations
{
    public partial class changedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_User_UserId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_UserRentals_UserRentalsId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserRentalsId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserRentalsId",
                table: "Rentals");

            migrationBuilder.CreateIndex(
                name: "IX_UserRentals_rentalId",
                table: "UserRentals",
                column: "rentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRentals_Rentals_rentalId",
                table: "UserRentals",
                column: "rentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRentals_Rentals_rentalId",
                table: "UserRentals");

            migrationBuilder.DropIndex(
                name: "IX_UserRentals_rentalId",
                table: "UserRentals");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rentals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRentalsId",
                table: "Rentals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserRentalsId",
                table: "Rentals",
                column: "UserRentalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_User_UserId",
                table: "Rentals",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_UserRentals_UserRentalsId",
                table: "Rentals",
                column: "UserRentalsId",
                principalTable: "UserRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
