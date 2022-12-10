
namespace MedHub.Shared.Domain
{
    public class Patient
    {
        public Guid Id { get;  set; }
        public string CNP { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public List<MedicalRecord> MedicalHistory { get;  set; }
        public List<Allergen> Allergies { get;  set; }
    }
}
