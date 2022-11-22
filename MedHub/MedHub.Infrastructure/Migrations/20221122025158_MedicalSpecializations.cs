using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MedicalSpecializations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalSpecialities_Doctors_DoctorId",
                table: "MedicalSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalSpecialities",
                table: "MedicalSpecialities");

            migrationBuilder.RenameTable(
                name: "MedicalSpecialities",
                newName: "MedicalSpecializations");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalSpecialities_DoctorId",
                table: "MedicalSpecializations",
                newName: "IX_MedicalSpecializations_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalSpecializations",
                table: "MedicalSpecializations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalSpecializations_Doctors_DoctorId",
                table: "MedicalSpecializations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalSpecializations_Doctors_DoctorId",
                table: "MedicalSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalSpecializations",
                table: "MedicalSpecializations");

            migrationBuilder.RenameTable(
                name: "MedicalSpecializations",
                newName: "MedicalSpecialities");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalSpecializations_DoctorId",
                table: "MedicalSpecialities",
                newName: "IX_MedicalSpecialities_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalSpecialities",
                table: "MedicalSpecialities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalSpecialities_Doctors_DoctorId",
                table: "MedicalSpecialities",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
