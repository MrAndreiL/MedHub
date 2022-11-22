using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Cabinet
    {
        public Guid Id { get; private set; }
        public string Address { get; private set; }
        public ICollection<StockLineItem> DrugsStock { get; private set; }
        public ICollection<Doctor> Doctors { get; private set; }

        public Cabinet(string address)
        {
            Id = Guid.NewGuid();
            Address = address;
            DrugsStock = new List<StockLineItem>();
            Doctors = new List<Doctor>();
        }

        public Result AddDrugsToCabinetStock(ICollection<StockLineItem> drugsPackage)
        {
            if (!drugsPackage.Any())
            {
                return Result.Failure("You should add at least one package to stock!");
            }

            foreach (var item in drugsPackage)
            {
                DrugsStock.Add(item);
                item.SetCabinetForStockLineItem(this);
            }

            return Result.Success();
        }

        public void AddDoctorToCabinet(Doctor doctor)
        {
            Doctors.Add(doctor);
            doctor.SetCabinetToDoctor(this);
        }

        public Result AddDoctorsListToCabinet(ICollection<Doctor> doctors)
        {
            if (!doctors.Any())
            {
                return Result.Failure("You should add at least one doctor to the list!");
            }

            foreach (Doctor doctor in doctors)
            {
                AddDoctorToCabinet(doctor);
            }

            return Result.Success();
        }
    }
}
