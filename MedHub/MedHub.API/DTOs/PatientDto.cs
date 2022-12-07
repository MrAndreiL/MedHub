using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class PatientDto : CreatePatientDto
    {
        public Guid Id { get; set; }
        public List<MedicalRecord> MedicalHistory { get; set; }
        public List<Allergen> Allergies { get; set; }

    }
}
