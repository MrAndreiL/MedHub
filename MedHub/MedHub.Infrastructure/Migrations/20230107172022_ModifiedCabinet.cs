using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCabinet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinets_MedicalSpecialities_SpecialityId",
                table: "Cabinets");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecialityId",
                table: "Cabinets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinets_MedicalSpecialities_SpecialityId",
                table: "Cabinets",
                column: "SpecialityId",
                principalTable: "MedicalSpecialities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinets_MedicalSpecialities_SpecialityId",
                table: "Cabinets");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecialityId",
                table: "Cabinets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinets_MedicalSpecialities_SpecialityId",
                table: "Cabinets",
                column: "SpecialityId",
                principalTable: "MedicalSpecialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
