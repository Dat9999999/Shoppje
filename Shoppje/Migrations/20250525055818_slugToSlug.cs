using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppje.Migrations
{
    /// <inheritdoc />
    public partial class slugToSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Categories",
                newName: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Categories",
                newName: "slug");
        }
    }
}
