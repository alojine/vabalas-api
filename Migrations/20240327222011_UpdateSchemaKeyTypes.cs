using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vabalas_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_UserId1",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserId1",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Reviews",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reviews",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "JobOffers",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Job",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_JobId",
                table: "Reviews",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobId",
                table: "JobOffers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_SenderId",
                table: "JobOffers",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_OwnerId",
                table: "Job",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserId",
                table: "Job",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Users_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_VabalasUsers_OwnerId",
                table: "Job",
                column: "OwnerId",
                principalTable: "VabalasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Job_JobId",
                table: "JobOffers",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_VabalasUsers_SenderId",
                table: "JobOffers",
                column: "SenderId",
                principalTable: "VabalasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Job_JobId",
                table: "Reviews",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_VabalasUsers_AuthorId",
                table: "Reviews",
                column: "AuthorId",
                principalTable: "VabalasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_UserId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_VabalasUsers_OwnerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Job_JobId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_VabalasUsers_SenderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Job_JobId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_VabalasUsers_AuthorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_JobId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_JobId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_SenderId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Job_OwnerId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Reviews",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "JobOffers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Job",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
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
    }
}
