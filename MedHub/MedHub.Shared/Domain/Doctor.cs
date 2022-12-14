namespace MedHub.Shared.Domain
{
    public class Doctor
    {
        public Guid Id { get;  set; }
        public string CNP { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public HashSet<MedicalSpeciality> Specializations { get;  set; }
        public HashSet<Cabinet> Cabinet { get;  set; }
    }
}
