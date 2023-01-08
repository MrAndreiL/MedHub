using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Cabinets_SellerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_BuyerId",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Invoices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Invoices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Cabinets_SellerId",
                table: "Invoices",
                column: "SellerId",
                principalTable: "Cabinets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_BuyerId",
                table: "Invoices",
                column: "BuyerId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Cabinets_SellerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_BuyerId",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Cabinets_SellerId",
                table: "Invoices",
                column: "SellerId",
                principalTable: "Cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_BuyerId",
                table: "Invoices",
                column: "BuyerId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
