using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacistName = table.Column<int>(type: "int", nullable: false),
                    RreceiptNum = table.Column<int>(type: "int", nullable: false),
                    NumOfProducts = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReceiptId",
                table: "Products",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_receipts_ReceiptId",
                table: "Products",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_receipts_ReceiptId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReceiptId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Products");
        }
    }
}
