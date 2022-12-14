using MedHub.Domain.Helpers;
using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class Patient : IPerson
    {

        public Guid Id { get; private set; }
        public string CNP { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public List<MedicalRecord> MedicalHistory { get; private set; }
        public List<Allergen> Allergies { get; private set; }
        public static Result<Patient> Create(string cNP, string firstName, string lastName, string email)
        {
            if (String.IsNullOrEmpty(cNP))
            {
                return Result<Patient>.Failure("The personal numeric code cannot be empty.");
            }
            if (String.IsNullOrEmpty(firstName))
            {
                return Result<Patient>.Failure("The first name cannot be empty.");
            }
            if (String.IsNullOrEmpty(lastName))
            {
                return Result<Patient>.Failure("The last name cannot be empty.");
            }
            if (String.IsNullOrEmpty(email))
            {
                return Result<Patient>.Failure("The email cannot be empty.");
            }

            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                CNP = cNP,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            return Result<Patient>.Success(patient);
        }
        public void AddMedicalRecordToMedicalHistory(MedicalRecord medicalRecord)
        {
            MedicalHistory.Add(medicalRecord);
        }
        public Result PushMedicalHistory(List<MedicalRecord> medicalRecordList)
        {
            foreach (var medicalRecord in medicalRecordList)
            {
                AddMedicalRecordToMedicalHistory(medicalRecord);
            }

            return Result.Success();
        }
        public void MarkAllergyForAllergen(Allergen allergen)
        {
            Allergies.Add(allergen);
        }
        public Result RecordAllergyList(List<Allergen> allergens)
        {
            foreach (var allergen in allergens)
            {
                MarkAllergyForAllergen(allergen);
            }

            return Result.Success();
        }
    }
}
