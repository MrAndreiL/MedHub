using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MedHub.Infrastructure.Data;

namespace MedHub.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MedHubContext context;
        private IRepository<Allergen> allergenRepository;
        private IRepository<Appointment> appointmentRepository;
        private IRepository<Cabinet> cabinetRepository;
        private IRepository<Doctor> doctorRepository;
        private IRepository<Drug> drugRepository;
        private IRepository<InvoiceItem> invoiceItemRepository;
        private IRepository<Invoice> invoiceRepository;
        private IRepository<MedicalRecord> medicalRecordRepository;
        private IRepository<MedicalSpeciality> medicalSpecialityRepository;
        private IRepository<Patient> patientRepository;
        private IRepository<Product> productRepository;
        private IRepository<Service> serviceRepository;
        private IRepository<StockItem> stockItemRepository;

        public UnitOfWork(MedHubContext context)
        {
            this.context = context;
        }

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

        public IRepository<Appointment> AppointmentRepository
        {
            get
            {
                if (appointmentRepository == null)
                {
                    appointmentRepository = new AppointmentRepository(context);
                }
                return appointmentRepository;
            }
        }

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

        public IRepository<InvoiceItem> InvoiceItemRepository
        {
            get
            {
                if (invoiceItemRepository == null)
                {
                    invoiceItemRepository = new InvoiceItemRepository(context);
                }
                return invoiceItemRepository;
            }
        }

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

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }

        public IRepository<Service> ServiceRepository
        {
            get
            {
                if (serviceRepository == null)
                {
                    serviceRepository = new ServiceRepository(context);
                }
                return serviceRepository;
            }
        }

        public IRepository<StockItem> StockItemRepository
        {
            get
            {
                if (stockItemRepository == null)
                {
                    stockItemRepository = new StockItemRepository(context);
                }
                return stockItemRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed) 
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
