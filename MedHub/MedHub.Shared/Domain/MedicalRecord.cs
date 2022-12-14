namespace MedHub.Shared.Domain
{
    public class MedicalRecord
    {
        public Guid Id { get;  set; }
        public Patient Patient { get;  set; }
        public Guid PatientId { get; set; }
        public string MedicalNote { get; set; }
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
