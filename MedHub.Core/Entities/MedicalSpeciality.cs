using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class MedicalSpeciality
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public HashSet<Doctor> Doctors { get; private set; } = null!;
        public HashSet<Cabinet> Cabinets { get; private set; } = null!;

        public static Result<MedicalSpeciality> Create(string specializationName)
        {
            if (string.IsNullOrEmpty(specializationName))
            {
                return Result<MedicalSpeciality>.Failure("The specialization name cannot be null or empty.");
            }

            return Result<MedicalSpeciality>.Success(new MedicalSpeciality
            {
                Id = Guid.NewGuid(),
                Name = specializationName,
                Doctors = new HashSet<Doctor>(),
                Cabinets = new HashSet<Cabinet>(),
            });
        }

        public Result AddDoctorToMedicalSpeciality(Doctor doctor)
        {
            if (doctor == null)
            {
                return Result.Failure("The doctor that you add to specialization cannot be null.");
            }

            Doctors.Add(doctor);

            return Result.Success();
        }

        public Result AddCabinetToMedicalSpeciality(Cabinet cabinet) 
        {
            if (cabinet == null)
            {
                return Result.Failure("The cabinet whose specialization you want to add cannot be null.");
            }
            
            Cabinets.Add(cabinet);

            return Result.Success();
        }
    }
}
