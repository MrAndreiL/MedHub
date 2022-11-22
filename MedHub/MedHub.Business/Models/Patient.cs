using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Patient : Person
    {
        public ICollection<MedicalRecord> MedicalHistory { get; private set; }
        public ICollection<Allergen> Allergies { get; private set; }

        public Patient(string CNP, string firstName, string lastName, string email) : base(CNP, firstName, lastName, email)
        { }

        public void AddMedicalRecordToMedicalHistory(MedicalRecord medicalRecord)
        {
            MedicalHistory.Add(medicalRecord);
        }

        public Result PushMedicalHistory(ICollection<MedicalRecord> medicalRecordList)
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

        public Result RecordAllergyList(ICollection<Allergen> allergens)
        {
            foreach (var allergen in allergens)
            {
                MarkAllergyForAllergen(allergen);
            }

            return Result.Success();
        }
    }
}
