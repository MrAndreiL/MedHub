using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Doctor : Person
    {
        public ICollection<MedicalSpeciality> Specializations { get; private set; }
        public Cabinet Cabinet { get; private set; }
        public Guid CabinetId { get; private set; }

        public Doctor(string CNP, string firstName, string lastName, string email) : base(CNP, firstName, lastName, email)
        { }

        public void AddSpecialization(MedicalSpeciality medicalSpeciality)
        {
            Specializations.Add(medicalSpeciality);
        }

        public Result AddSpecializations(ICollection<MedicalSpeciality> specializationsList)
        {
            if (!specializationsList.Any())
            {
                return Result.Failure("The list of specialization cannot be empty!");
            }

            foreach (var specialization in specializationsList)
            {
                AddSpecialization(specialization);
            }

            return Result.Success();
        }

        public void SetCabinetToDoctor(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
            Cabinet = cabinet;
        }
    }
}
