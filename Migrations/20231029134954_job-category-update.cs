using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vabalas_api.Migrations
{
    /// <inheritdoc />
    public partial class jobcategoryupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Job");
        }
    }
}
