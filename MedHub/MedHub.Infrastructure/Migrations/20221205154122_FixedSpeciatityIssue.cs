using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedSpeciatityIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalSpecializations_Doctors_DoctorId",
                table: "MedicalSpecializations");

            migrationBuilder.DropIndex(
                name: "IX_MedicalSpecializations_DoctorId",
                table: "MedicalSpecializations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicalSpecializations");

            migrationBuilder.CreateTable(
                name: "DoctorMedicalSpeciality",
                columns: table => new
                {
                    DoctorsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpecializationsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalSpeciality", x => new { x.DoctorsId, x.SpecializationsId });
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpeciality_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpeciality_MedicalSpecializations_SpecializationsId",
                        column: x => x.SpecializationsId,
                        principalTable: "MedicalSpecializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpeciality_SpecializationsId",
                table: "DoctorMedicalSpeciality",
                column: "SpecializationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorMedicalSpeciality");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "MedicalSpecializations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSpecializations_DoctorId",
                table: "MedicalSpecializations",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalSpecializations_Doctors_DoctorId",
                table: "MedicalSpecializations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
