using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Technicians_TechnicianId",
                table: "ServiceOrders");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Technicians_TechnicianId",
                table: "ServiceOrders",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Technicians_TechnicianId",
                table: "ServiceOrders");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Technicians_TechnicianId",
                table: "ServiceOrders",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }
    }
}
