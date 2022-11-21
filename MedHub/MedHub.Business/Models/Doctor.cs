using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Doctor : Person
    {
        public List<MedicalSpeciality> SpecializationsList { get; private set; }

        public Doctor(string firstName, string lastName, string email) : base(firstName, lastName, email)
        { }

        public Result AddSpecialization(List<MedicalSpeciality> specializationsList)
        {
            if (!specializationsList.Any())
            {
                return Result.Failure("The list of specialization cannot be empty!");
            }

            specializationsList.ForEach(se =>
            {
                SpecializationsList.Add(se);
            });

            return Result.Success();
        }
    }
}
