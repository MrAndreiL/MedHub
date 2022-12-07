using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Allergen> AllergenRepository { get; }
        IRepository<Cabinet> CabinetRepository { get; }
        IRepository<Doctor> DoctorRepository { get; }
        IRepository<Drug> DrugRepository { get; }
        IRepository<InvoiceLineItem> InvoiceLineItemRepository { get; }
        IRepository<Invoice> InvoiceRepository { get; }
        IRepository<MedicalRecord> MedicalRecordRepository { get; }
        IRepository<MedicalSpeciality> MedicalSpecialityRepository { get; }
        IRepository<Patient> PatientRepository { get; }
        IRepository<StockLineItem> StockLineItemRepository { get; }
        void SaveChanges();
    }
}
