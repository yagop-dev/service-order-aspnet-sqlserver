using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleToServiceOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ServiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ServiceOrders");
        }
    }
}
