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
                type: "nv3\t16,94\t34,17\t96024255\r\narchar(max)",
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
