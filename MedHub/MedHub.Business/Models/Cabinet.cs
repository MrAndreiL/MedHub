using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Cabinet
    {
        public Guid Id { get; private set; }
        public string Address { get; private set; }
        public List<StockLineItem> DrugsStock { get; private set; } = new List<StockLineItem>();
        public List<Doctor> Doctors { get; private set; } = new List<Doctor>();
        public static Result<Cabinet> Create(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return Result<Cabinet>.Failure("The address cannot be empty.");
            }

            var cabinet = new Cabinet
            {
                Id = Guid.NewGuid(),
                Address = address
            };

            return Result<Cabinet>.Success(cabinet);
        }

        public Result AddDrugsToCabinetStock(List<StockLineItem> drugsPackage)
        {
            if (!drugsPackage.Any())
            {
                return Result.Failure("You should add at least one package to stock!");
            }

            foreach (var item in drugsPackage)
            {
                DrugsStock.Add(item);
                item.SetCabinet(this);
            }

            return Result.Success();
        }
        public Result AddDoctorToCabinet(Doctor doctor)
        {
            if( doctor == null)
            {
                return Result.Failure("Doctor can not be null");
            }
            Doctors.Add(doctor);
            doctor.SetCabinetToDoctor(this);
            return Result.Success();
        }
        public Result AddDoctorsListToCabinet(List<Doctor> doctors)
        {
            if (!doctors.Any())
            {
                return Result.Failure("You should add at least one doctor to the list!");
            }

            foreach (Doctor doctor in doctors)
            {
                Doctors.Add(doctor);
                doctor.SetCabinetToDoctor(this);
            }

            return Result.Success();
        }
    }
}
