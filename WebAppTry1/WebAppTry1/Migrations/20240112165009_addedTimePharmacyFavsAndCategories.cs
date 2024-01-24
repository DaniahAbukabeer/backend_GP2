using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class addedTimePharmacyFavsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsProducts_ReceiptInfo_ReceiptId",
                table: "ReceiptsProducts");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "UserProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "ReceiptsProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingTime",
                table: "Pharmacies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Open24Hours",
                table: "Pharmacies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningTime",
                table: "Pharmacies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsProducts_ReceiptInfo_ReceiptId",
                table: "ReceiptsProducts",
                column: "ReceiptId",
                principalTable: "ReceiptInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsProducts_ReceiptInfo_ReceiptId",
                table: "ReceiptsProducts");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "UserProduct");

            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Open24Hours",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Pharmacies");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "ReceiptsProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsProducts_ReceiptInfo_ReceiptId",
                table: "ReceiptsProducts",
                column: "ReceiptId",
                principalTable: "ReceiptInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
