using MedHub.Core.Entities;

namespace MedHub.Core.Repositories.Base
{
    public interface IUnitOfWork
    {
        IRepository<Allergen> AllergenRepository { get; }
        IRepository<Appointment> AppointmentRepository { get; }
        IRepository<Cabinet> CabinetRepository { get; }
        IRepository<Doctor> DoctorRepository { get; }
        IRepository<Drug> DrugRepository { get; }
        IRepository<InvoiceItem> InvoiceItemRepository { get; }
        IRepository<Invoice> InvoiceRepository { get; }
        IRepository<MedicalRecord> MedicalRecordRepository { get; }
        IRepository<MedicalSpeciality> MedicalSpecialityRepository { get; }
        IRepository<Patient> PatientRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Service> ServiceRepository { get; }
        IRepository<StockItem> StockItemRepository { get; }
        Task SaveChangesAsync();
    }
}
