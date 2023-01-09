using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Cabinets_CabinetId",
                table: "LineItem");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Cabinets_CabinetId",
                table: "LineItem",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Cabinets_CabinetId",
                table: "LineItem");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Cabinets_CabinetId",
                table: "LineItem",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
