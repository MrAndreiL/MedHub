namespace MedHub.Application.DTOs
{
    public class MedicalRecordDto
    {
        public Guid Id { get; set; }
        public string MedicalNote { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
    }
}
