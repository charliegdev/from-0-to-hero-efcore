using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToInternetRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ImdbRating",
                table: "Pictures",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.RenameColumn(
                name: "ImdbRating",
                table: "Pictures",
                newName: "InternetRating"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InternetRating",
                table: "Pictures",
                newName: "ImdbRating"
            );

            migrationBuilder.AlterColumn<int>(
                name: "ImdbRating",
                table: "Pictures",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );
        }
    }
}
