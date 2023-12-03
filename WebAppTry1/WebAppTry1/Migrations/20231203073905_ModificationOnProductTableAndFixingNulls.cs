using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class ModificationOnProductTableAndFixingNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                table: "ReceiptsProducts");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discreption",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LocalAgent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PrivatePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PulbicPriceWTax",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptNumber",
                table: "ReceiptsProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "Products",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Discreption",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocalAgent",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PrivatePrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PulbicPriceWTax",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "number",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ATCCODE", "Amount", "BarCode", "Country", "Discount", "Discreption", "Dosage", "LocalAgent", "PharmacyId", "PrivatePrice", "Provider", "PublicPrice", "PulbicPriceWTax", "Quantity", "SName", "TName", "UserId", "number" },
                values: new object[] { 3, "12345", 24, "1234567890123", "test country", 0.0, "test discreption", 500.0, "test agent", 3, 2.0, "test provider", 3.0, 3.5, 10, "Scientific name", "Trade name", 1, "12345" });
        }
    }
}
