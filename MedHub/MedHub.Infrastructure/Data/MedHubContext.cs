using MedHub.Core.Entities;
using MedHub.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedHub.Infrastructure.Data
{
    public class MedHubContext : DbContext
    {
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        public MedHubContext(DbContextOptions<MedHubContext> options) : base(options) { }
    }
}
