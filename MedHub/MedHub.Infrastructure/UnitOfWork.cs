using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories;
using MedHub.Infrastructure.Repositories.Generics;
using MyShop.Infrastructure;

namespace MedHub.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private MedHubContext context;

        public UnitOfWork(MedHubContext context)
        {
            this.context = context;
        }

        private IRepository<Allergen> allergenRepository;
        public IRepository<Allergen> AllergenRepository
        {
            get
            {
                if (allergenRepository == null)
                {
                    allergenRepository = new AllergenRepository(context);
                }

                return allergenRepository;
            }
        }

        private IRepository<Cabinet> cabinetRepository;
        public IRepository<Cabinet> CabinetRepository
        {
            get
            {
                if (cabinetRepository == null)
                {
                    cabinetRepository = new CabinetRepository(context);
                }

                return cabinetRepository;
            }
        }

        private IRepository<Doctor> doctorRepository;
        public IRepository<Doctor> DoctorRepository
        {
            get
            {
                if (doctorRepository == null)
                {
                    doctorRepository = new DoctorRepository(context);
                }

                return doctorRepository;
            }
        }

        private IRepository<Drug> drugRepository;
        public IRepository<Drug> DrugRepository
        {
            get
            {
                if (drugRepository == null)
                {
                    drugRepository = new DrugRepository(context);
                }

                return drugRepository;
            }
        }

        private IRepository<InvoiceLineItem> invoiceLineItemRepository;
        public IRepository<InvoiceLineItem> InvoiceLineItemRepository
        {
            get
            {
                if (invoiceLineItemRepository == null)
                {
                    invoiceLineItemRepository = new InvoiceLineItemRepository(context);
                }

                return invoiceLineItemRepository;
            }
        }

        private IRepository<Invoice> invoiceRepository;
        public IRepository<Invoice> InvoiceRepository
        {
            get
            {
                if (invoiceRepository == null)
                {
                    invoiceRepository = new InvoiceRepository(context);
                }

                return invoiceRepository;
            }
        }

        private IRepository<MedicalRecord> medicalRecordRepository;
        public IRepository<MedicalRecord> MedicalRecordRepository
        {
            get
            {
                if (medicalRecordRepository == null)
                {
                    medicalRecordRepository = new MedicalRecordRepository(context);
                }

                return medicalRecordRepository;
            }
        }

        private IRepository<MedicalSpeciality> medicalSpecialityRepository;
        public IRepository<MedicalSpeciality> MedicalSpecialityRepository
        {
            get
            {
                if (medicalSpecialityRepository == null)
                {
                    medicalSpecialityRepository = new MedicalSpecialityRepository(context);
                }

                return medicalSpecialityRepository;
            }
        }

        private IRepository<Patient> patientRepository;
        public IRepository<Patient> PatientRepository
        {
            get
            {
                if (patientRepository == null)
                {
                    patientRepository = new PatientRepository(context);
                }

                return patientRepository;
            }
        }

        private IRepository<StockLineItem> stockLineItemRepository;
        public IRepository<StockLineItem> StockLineItemRepository
        {
            get
            {
                if (stockLineItemRepository == null)
                {
                    stockLineItemRepository = new StockLineItemRepository(context);
                }

                return stockLineItemRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
