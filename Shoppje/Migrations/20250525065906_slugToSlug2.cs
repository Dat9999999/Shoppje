using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppje.Migrations
{
    /// <inheritdoc />
    public partial class slugToSlug2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Brands",
                newName: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Brands",
                newName: "slug");
        }
    }
}
