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

        public void PushMedicalHistory(ICollection<MedicalRecord> medicalRecordList)
        {
            foreach (var medicalRecord in medicalRecordList)
            {
                AddMedicalRecordToMedicalHistory(medicalRecord);
            }
        }

        public void MarkAllergyForAllergen(Allergen allergen)
        {
            Allergies.Add(allergen);
        }

        public void RecordAllergyList(ICollection<Allergen> allergens)
        {
            foreach (var allergen in allergens)
            {
                MarkAllergyForAllergen(allergen);
            }
        }
    }
}
