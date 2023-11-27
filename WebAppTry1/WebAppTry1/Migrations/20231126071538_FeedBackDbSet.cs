using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class FeedBackDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Pharmacies_PharmacyId",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Users_UserId",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_receipts_ReceiptId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReceiptId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "FeedBack",
                newName: "FeedBacks");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBack_PharmacyId",
                table: "FeedBacks",
                newName: "IX_FeedBacks_PharmacyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks",
                columns: new[] { "UserId", "PharmacyId" });

            migrationBuilder.CreateTable(
                name: "ReceiptInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PharmacistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptsProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptsProducts", x => new { x.Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ReceiptsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptsProducts_ReceiptInfo_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "ReceiptInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptsProducts_ProductId",
                table: "ReceiptsProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptsProducts_ReceiptId",
                table: "ReceiptsProducts",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Pharmacies_PharmacyId",
                table: "FeedBacks",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Pharmacies_PharmacyId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks");

            migrationBuilder.DropTable(
                name: "ReceiptsProducts");

            migrationBuilder.DropTable(
                name: "ReceiptInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks");

            migrationBuilder.RenameTable(
                name: "FeedBacks",
                newName: "FeedBack");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBacks_PharmacyId",
                table: "FeedBack",
                newName: "IX_FeedBack_PharmacyId");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack",
                columns: new[] { "UserId", "PharmacyId" });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfProducts = table.Column<int>(type: "int", nullable: false),
                    PharmacistName = table.Column<int>(type: "int", nullable: false),
                    RreceiptNum = table.Column<int>(type: "int", nullable: false),
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
                name: "FK_FeedBack_Pharmacies_PharmacyId",
                table: "FeedBack",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Users_UserId",
                table: "FeedBack",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_receipts_ReceiptId",
                table: "Products",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id");
        }
    }
}
