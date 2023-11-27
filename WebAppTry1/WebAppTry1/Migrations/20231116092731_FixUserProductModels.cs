using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class FixUserProductModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBackModelPharmacyModel");

            migrationBuilder.DropTable(
                name: "PharmacyModelProductModel");

            migrationBuilder.DropTable(
                name: "FeedBackModel");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    Statues = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ratting = table.Column<float>(type: "real", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => new { x.UserId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_FeedBack_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedBack_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyProduct",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProduct", x => new { x.PharmacyId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PharmacyProduct_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProduct",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProduct", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_UserProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProduct_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_PharmacyId",
                table: "FeedBack",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProduct_ProductId",
                table: "PharmacyProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_ProductId",
                table: "UserProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "PharmacyProduct");

            migrationBuilder.DropTable(
                name: "UserProduct");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "FeedBackModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratting = table.Column<float>(type: "real", maxLength: 5, nullable: false),
                    Statues = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyModelProductModel",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyModelProductModel", x => new { x.PharmacyId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PharmacyModelProductModel_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyModelProductModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedBackModelPharmacyModel",
                columns: table => new
                {
                    FeedBackId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackModelPharmacyModel", x => new { x.FeedBackId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_FeedBackModelPharmacyModel_FeedBackModel_FeedBackId",
                        column: x => x.FeedBackId,
                        principalTable: "FeedBackModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedBackModelPharmacyModel_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBackModelPharmacyModel_PharmacyId",
                table: "FeedBackModelPharmacyModel",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyModelProductModel_ProductId",
                table: "PharmacyModelProductModel",
                column: "ProductId");
        }
    }
}
