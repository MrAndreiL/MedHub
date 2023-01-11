﻿using MedHub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHub.Infrastructure
{
    public class MedHubContext : DbContext
    {
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<Drug> Drugs => Set<Drug>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Cabinet> Cabinets => Set<Cabinet>();
        public DbSet<Allergen> Allergens => Set<Allergen>();
        public DbSet<MedicalSpeciality> MedicalSpecializations => Set<MedicalSpeciality>();
        public DbSet<InvoiceLineItem> InvoiceLineItems => Set<InvoiceLineItem>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<StockLineItem> StockLineItems => Set<StockLineItem>();
        public MedHubContext(DbContextOptions<MedHubContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        public void Save()
        {
            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(x => x.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<StockLineItem>().HasKey(x => x.Id);
            modelBuilder.Entity<MedicalRecord>().HasKey(x => x.Id);
            // Some default data
        }
    }
}