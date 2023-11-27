using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class fixingModels : Migration
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
                name: "UserProductProductId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProductUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProductProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProductUserId",
                table: "Products",
                type: "int",
                nullable: true);

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
                name: "ProductUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.UsersId, x.productsId });
                    table.ForeignKey(
                        name: "FK_ProductUser_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProductUserId_UserProductProductId",
                table: "Users",
                columns: new[] { "UserProductUserId", "UserProductProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserProductUserId_UserProductProductId",
                table: "Products",
                columns: new[] { "UserProductUserId", "UserProductProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_PharmacyId",
                table: "FeedBack",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProduct_ProductId",
                table: "PharmacyProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_productsId",
                table: "ProductUser",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserProduct_UserProductUserId_UserProductProductId",
                table: "Products",
                columns: new[] { "UserProductUserId", "UserProductProductId" },
                principalTable: "UserProduct",
                principalColumns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProduct_UserProductUserId_UserProductProductId",
                table: "Users",
                columns: new[] { "UserProductUserId", "UserProductProductId" },
                principalTable: "UserProduct",
                principalColumns: new[] { "UserId", "ProductId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserProduct_UserProductUserId_UserProductProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProduct_UserProductUserId_UserProductProductId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "PharmacyProduct");

            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.DropTable(
                name: "UserProduct");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserProductUserId_UserProductProductId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserProductUserId_UserProductProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserProductProductId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProductUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProductProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserProductUserId",
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
