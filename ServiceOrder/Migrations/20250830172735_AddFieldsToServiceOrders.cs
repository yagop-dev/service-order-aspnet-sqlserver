using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToServiceOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "ServiceOrders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ServiceOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "ServiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ServiceOrders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ServiceOrders");
        }
    }
}
