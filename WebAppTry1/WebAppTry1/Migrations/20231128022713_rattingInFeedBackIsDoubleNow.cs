using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTry1.Migrations
{
    /// <inheritdoc />
    public partial class rattingInFeedBackIsDoubleNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Ratting",
                table: "FeedBacks",
                type: "float",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Ratting",
                table: "FeedBacks",
                type: "real",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 5);
        }
    }
}
