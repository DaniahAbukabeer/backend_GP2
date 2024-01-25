using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class modifiedRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratting",
                table: "Pharmacies");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Pharmacies",
                newName: "Phonenumber");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Pharmacies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Pharmacies");

            migrationBuilder.RenameColumn(
                name: "Phonenumber",
                table: "Pharmacies",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<float>(
                name: "Ratting",
                table: "Pharmacies",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
