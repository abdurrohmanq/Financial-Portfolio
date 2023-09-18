using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Taxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "IncomeTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Incomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Debts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "IncomeTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Assets");
        }
    }
}
