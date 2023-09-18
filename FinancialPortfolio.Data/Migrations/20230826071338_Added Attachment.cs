using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AttachmentId",
                table: "Users",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Users_AttachmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Users");
        }
    }
}
