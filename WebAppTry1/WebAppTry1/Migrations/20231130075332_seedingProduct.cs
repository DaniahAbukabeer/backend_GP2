using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class seedingProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ATCCODE", "Amount", "BarCode", "Country", "Discount", "Discreption", "Dosage", "LocalAgent", "PharmacyId", "PrivatePrice", "Provider", "PublicPrice", "PulbicPriceWTax", "Quantity", "SName", "TName", "UserId", "number" },
                values: new object[] { 3, "12345", 24, "1234567890123", "test country", 0.0, "test discreption", 500.0, "test agent", 3, 2.0, "test provider", 3.0, 3.5, 10, "Scientific name", "Trade name", 1, "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
