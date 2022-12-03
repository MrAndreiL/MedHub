using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class MedicalRecordDto
    {
        public Guid Id { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public string MedicalNote { get; set; }
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
