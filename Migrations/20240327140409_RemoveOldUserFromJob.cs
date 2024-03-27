using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vabalas_api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldUserFromJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_UserId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserId",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Job",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserId1",
                table: "Job",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Users_UserId1",
                table: "Job",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_UserId1",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserId1",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Job",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserId",
                table: "Job",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Users_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
