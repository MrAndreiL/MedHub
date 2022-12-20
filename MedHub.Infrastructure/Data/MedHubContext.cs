using MedHub.Core.Entities;
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

        public MedHubContext(DbContextOptions<MedHubContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        public void Save()
        {
            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Doctor>().HasKey(x => x.Id);
            //modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            //modelBuilder.Entity<StockItem>().HasKey(x => x.Id);
            //modelBuilder.Entity<MedicalRecord>().HasKey(x => x.Id);
            // Some default data

            /*
            var allergen1 = Allergen.Create("Gluten").Entity;
            var allergen2 = Allergen.Create("Lactoza").Entity;

            modelBuilder.Entity<Allergen>().HasData(new List<Allergen> { allergen1, allergen2 });
            */
        }
    }
}
