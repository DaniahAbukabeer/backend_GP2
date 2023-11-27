using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class seedingOneUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Latitude", "Longitude", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, 32.234524, 23.234632000000001, "password12345678", "0791234567", "Test1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
