using MedHub.Domain.Helpers;
using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class Doctor : IPerson
    {
        public Guid Id { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<MedicalSpeciality> Specializations { get; private set; }
        public Cabinet Cabinet { get; private set; }
        public Guid CabinetId { get; private set; }
        public static Result<Doctor> Create(string cNP, string firstName, string lastName, string email)
        {
            if (String.IsNullOrEmpty(cNP))
            {
                return Result<Doctor>.Failure("The personal numeric code cannot be empty.");
            }
            if (String.IsNullOrEmpty(firstName))
            {
                return Result<Doctor>.Failure("The first name cannot be empty.");
            }
            if (String.IsNullOrEmpty(lastName))
            {
                return Result<Doctor>.Failure("The last name cannot be empty.");
            }
            if (String.IsNullOrEmpty(email))
            {
                return Result<Doctor>.Failure("The email cannot be empty.");
            }

            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),
                CNP = cNP,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            return Result<Doctor>.Success(doctor);
        }

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
