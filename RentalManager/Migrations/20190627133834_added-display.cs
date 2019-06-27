using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalManager.Data.Migrations
{
    public partial class addeddisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rentals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Rentals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRentalsId",
                table: "Rentals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserRentalsId",
                table: "Rentals",
                column: "UserRentalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_UserRentals_UserRentalsId",
                table: "Rentals",
                column: "UserRentalsId",
                principalTable: "UserRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRentals_User_userId",
                table: "UserRentals",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_UserRentals_UserRentalsId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRentals_User_userId",
                table: "UserRentals");

            migrationBuilder.DropIndex(
                name: "IX_UserRentals_userId",
                table: "UserRentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserRentalsId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserRentalsId",
                table: "Rentals");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rentals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Rentals",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
