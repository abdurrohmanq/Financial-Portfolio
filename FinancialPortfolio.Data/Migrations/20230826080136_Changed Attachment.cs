using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "AttachmentId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "AttachmentId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attachment_AttachmentId",
                table: "Users",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }
    }
}
