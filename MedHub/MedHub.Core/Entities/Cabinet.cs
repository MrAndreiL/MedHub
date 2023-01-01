using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Cabinet
    {
        public Guid Id { get; private set; }
        public string Address { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public MedicalSpeciality Speciality { get; private set; } = null!;
        public HashSet<StockItem> DrugStock { get; private set; } = null!;
        public HashSet<Doctor> Doctors { get; private set; } = null!;
        public HashSet<Appointment> CreatedAppointments { get; private set; } = null!;
        public HashSet<Invoice> IssuedInvoices { get; private set; } = null!;

        public static Result<Cabinet> Create(string? address, string? phoneNumber)
        {
            if (string.IsNullOrEmpty(address))
            {
                return Result<Cabinet>.Failure("Cabinet's address cannot be null or empty.");
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Result<Cabinet>.Failure("Cabinet's phone number cannot be null or empty.");
            }

            return Result<Cabinet>.Success(new Cabinet
            {
                Id = Guid.NewGuid(),
                Address = address,
                PhoneNumber = phoneNumber,
                Doctors = new HashSet<Doctor>(),
                DrugStock = new HashSet<StockItem>(),
                CreatedAppointments = new HashSet<Appointment>(),
                IssuedInvoices = new HashSet<Invoice>(),
            });
        }

        public Result AttachSpecialityToCabinet(MedicalSpeciality? medicalSpeciality)
        {
            if (medicalSpeciality == null)
            {
                return Result.Failure("Cabinet's speciality cannot be null.");
            }

            Speciality = medicalSpeciality;
            medicalSpeciality.AddCabinetToMedicalSpeciality(this);

            return Result.Success();
        }

        public Result AddDoctorsToCabinet(List<Doctor>? doctors)
        {
            if (doctors == null)
            {
                return Result.Failure("The doctor list that is added to the cabinet cannot be null.");
            }
            if (!doctors.Any())
            {
                return Result.Failure("The doctor list that is added to the cabinet cannot be empty.");
            }

            doctors.ForEach(doctor =>
            {
                Doctors.Add(doctor);
                doctor.AddCabinetToDoctor(this);
            });

            return Result.Success();
        }

        public Result AddDrugsToCabinet(List<StockItem>? stockItems)
        {
            if (stockItems == null) 
            {
                return Result.Failure("The drug item list cannot be null.");
            }
            if (!stockItems.Any())
            {
                return Result.Failure("The drug item list cannot be empty.");
            }

            stockItems.ForEach(stockItem =>
            {
                DrugStock.Add(stockItem);
                stockItem.AttachCabinetToStockItem(this);
            });

            return Result.Success();
        }

        public Result BindAppointmentToCabinet(Appointment? appointment)
        {
            if (appointment == null)
            {
                return Result.Failure("The appointment that you add to the cabinet must be not null.");
            }

            CreatedAppointments.Add(appointment);

            return Result.Success();
        }

        public Result BindInvoiceToCabinet(Invoice? invoice)
        {
            if (invoice == null)
            {
                return Result.Failure("The invoice that you add to the cabinet must be not null.");
            }

            IssuedInvoices.Add(invoice);

            return Result.Success();
        }
    }
}
