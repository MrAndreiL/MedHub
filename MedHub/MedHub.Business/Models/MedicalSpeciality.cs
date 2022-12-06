using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class MedicalSpeciality
    {
        public Guid Id { get; private set; }
        public string SpecializationName { get; private set; }
        public HashSet<Doctor> Doctors { get; private set; } = new HashSet<Doctor>();
        public static Result<MedicalSpeciality> Create(string specializationName)
        {
            if (String.IsNullOrEmpty(specializationName))
            {
                return Result<MedicalSpeciality>.Failure("The specialization name cannot be empty.");
            }

            var specialization = new MedicalSpeciality
            {
                Id = Guid.NewGuid(),
                SpecializationName = specializationName
            };

            return Result<MedicalSpeciality>.Success(specialization);
        }
    }
}
