﻿// <auto-generated />
using System;
using MedHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedHub.Infrastructure.Migrations
{
    [DbContext(typeof(MedHubContext))]
    [Migration("20230106080252_ModifiedAppointment")]
    partial class ModifiedAppointment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("AllergenDrug", b =>
                {
                    b.Property<Guid>("AllergensId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InfestedDrugsId")
                        .HasColumnType("TEXT");

                    b.HasKey("AllergensId", "InfestedDrugsId");

                    b.HasIndex("InfestedDrugsId");

                    b.ToTable("AllergenDrug");
                });

            modelBuilder.Entity("AllergenPatient", b =>
                {
                    b.Property<Guid>("AffectedPatientsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AllergiesId")
                        .HasColumnType("TEXT");

                    b.HasKey("AffectedPatientsId", "AllergiesId");

                    b.HasIndex("AllergiesId");

                    b.ToTable("AllergenPatient");
                });

            modelBuilder.Entity("CabinetDoctor", b =>
                {
                    b.Property<Guid>("CabinetsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CabinetsId", "DoctorsId");

                    b.HasIndex("DoctorsId");

                    b.ToTable("CabinetDoctor");
                });

            modelBuilder.Entity("DoctorMedicalSpeciality", b =>
                {
                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SpecializationsId")
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorsId", "SpecializationsId");

                    b.HasIndex("SpecializationsId");

                    b.ToTable("DoctorMedicalSpeciality");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Allergen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CabinetId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Cabinet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MedHub.Core.Entities.LineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("LineItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LineItem");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedHub.Core.Entities.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalNote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("MedHub.Core.Entities.MedicalSpeciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MedicalSpecialities");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedHub.Core.Entities.InvoiceItem", b =>
                {
                    b.HasBaseType("MedHub.Core.Entities.LineItem");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasIndex("InvoiceId");

                    b.HasDiscriminator().HasValue("InvoiceItem");
                });

            modelBuilder.Entity("MedHub.Core.Entities.StockItem", b =>
                {
                    b.HasBaseType("MedHub.Core.Entities.LineItem");

                    b.Property<Guid>("CabinetId")
                        .HasColumnType("TEXT");

                    b.HasIndex("CabinetId");

                    b.HasDiscriminator().HasValue("StockItem");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Drug", b =>
                {
                    b.HasBaseType("MedHub.Core.Entities.Product");

                    b.HasDiscriminator().HasValue("Drug");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Service", b =>
                {
                    b.HasBaseType("MedHub.Core.Entities.Product");

                    b.HasDiscriminator().HasValue("Service");
                });

            modelBuilder.Entity("AllergenDrug", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.Drug", null)
                        .WithMany()
                        .HasForeignKey("InfestedDrugsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllergenPatient", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Patient", null)
                        .WithMany()
                        .HasForeignKey("AffectedPatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CabinetDoctor", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Cabinet", null)
                        .WithMany()
                        .HasForeignKey("CabinetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorMedicalSpeciality", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.MedicalSpeciality", null)
                        .WithMany()
                        .HasForeignKey("SpecializationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedHub.Core.Entities.Appointment", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Cabinet", "Cabinet")
                        .WithMany("CreatedAppointments")
                        .HasForeignKey("CabinetId");

                    b.HasOne("MedHub.Core.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedHub.Core.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Cabinet");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Cabinet", b =>
                {
                    b.HasOne("MedHub.Core.Entities.MedicalSpeciality", "Speciality")
                        .WithMany("Cabinets")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Invoice", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Patient", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.Cabinet", "Seller")
                        .WithMany("IssuedInvoices")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("MedHub.Core.Entities.LineItem", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Product", "Product")
                        .WithMany("LineItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MedHub.Core.Entities.MedicalRecord", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Doctor", "Doctor")
                        .WithMany("MedicalRecordIssued")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHub.Core.Entities.Patient", "Patient")
                        .WithMany("MedicalHistory")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedHub.Core.Entities.InvoiceItem", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Invoice", "Invoice")
                        .WithMany("Items")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("MedHub.Core.Entities.StockItem", b =>
                {
                    b.HasOne("MedHub.Core.Entities.Cabinet", "Cabinet")
                        .WithMany("DrugStock")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Cabinet", b =>
                {
                    b.Navigation("CreatedAppointments");

                    b.Navigation("DrugStock");

                    b.Navigation("IssuedInvoices");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalRecordIssued");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Invoice", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("MedHub.Core.Entities.MedicalSpeciality", b =>
                {
                    b.Navigation("Cabinets");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("MedHub.Core.Entities.Product", b =>
                {
                    b.Navigation("LineItems");
                });
#pragma warning restore 612, 618
        }
    }
}
