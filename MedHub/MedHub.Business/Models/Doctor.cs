using MedHub.Domain.Helpers;
using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class Doctor : IPerson
    {
        public Guid Id { get; private set; }
        public string CNP { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public HashSet<MedicalSpeciality> Specializations { get; private set; } = new HashSet<MedicalSpeciality>();
        public HashSet<Cabinet> Cabinet { get; private set; } = new HashSet<Cabinet>();
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

        public void SetCabinetToDoctor(Cabinet cabinet)
        {
            Cabinet.Add(cabinet);
        }
    }
}