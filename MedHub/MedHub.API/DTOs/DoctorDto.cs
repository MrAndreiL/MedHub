using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class DoctorDto : CreateDoctorDto
    {
        public Guid Id { get; set; }
        public HashSet<MedicalSpeciality> Specializations { get; set; }
        public HashSet<Cabinet> Cabinet { get; set; }
    }
}
