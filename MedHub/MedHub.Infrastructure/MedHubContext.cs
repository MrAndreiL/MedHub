using MedHub.Domain.Models;
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
        public DbSet<MedicalSpeciality> MedicalSpecialities => Set<MedicalSpeciality>();

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MedHubApp.db");
        }
    }
}
