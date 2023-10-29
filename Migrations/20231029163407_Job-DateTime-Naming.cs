using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vabalas_api.Migrations
{
    /// <inheritdoc />
    public partial class JobDateTimeNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAr",
                table: "Job",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "createdAr",
                table: "Job",
                newName: "createdAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Job",
                newName: "updatedAr");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Job",
                newName: "createdAr");
        }
    }
}
