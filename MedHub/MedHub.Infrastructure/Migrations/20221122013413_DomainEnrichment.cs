using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainEnrichment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Cabinets_CabinetId",
                table: "Drugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Invoices_InvoiceId",
                table: "Drugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_CabinetId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_InvoiceId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Invoices",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                newName: "IX_Invoices_SellerId");

            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CabinetId",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Allergens",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DrugId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicalNote = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CabinetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DrugId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLineItems_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockLineItems_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BuyerId",
                table: "Invoices",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_PatientId",
                table: "Allergens",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_DrugId",
                table: "InvoiceLineItems",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceId",
                table: "InvoiceLineItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLineItems_CabinetId",
                table: "StockLineItems",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLineItems_DrugId",
                table: "StockLineItems",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_CabinetId",
                table: "Doctors",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_CabinetId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Cabinets_SellerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_BuyerId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "StockLineItems");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BuyerId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_PatientId",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Allergens");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Invoices",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SellerId",
                table: "Invoices",
                newName: "IX_Invoices_PatientId");

            migrationBuilder.AddColumn<Guid>(
                name: "CabinetId",
                table: "Drugs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Drugs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_CabinetId",
                table: "Drugs",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_InvoiceId",
                table: "Drugs",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Cabinets_CabinetId",
                table: "Drugs",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Invoices_InvoiceId",
                table: "Drugs",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
