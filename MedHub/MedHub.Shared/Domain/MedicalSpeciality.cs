namespace MedHub.Shared.Domain
{
    public class MedicalSpeciality
    {
        public Guid Id { get; set; }
        public string SpecializationName { get; set; }
        public HashSet<Doctor> Doctors { get; set; }
    }
}
