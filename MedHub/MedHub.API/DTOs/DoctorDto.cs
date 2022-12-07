using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class DoctorDto : CreateDoctorDto
    {
        public Guid Id { get; set; }
        public HashSet<MedicalSpeciality> Specializations { get; set; } = new HashSet<MedicalSpeciality>();
        public HashSet<Cabinet> Cabinets { get; set; } = new HashSet<Cabinet>();
    }
}
