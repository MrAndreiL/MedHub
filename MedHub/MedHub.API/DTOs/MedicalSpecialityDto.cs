using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class MedicalSpecialityDto: CreateMedicalSpecialityDto
    {
        public Guid Id { get; set; }
        public List<Doctor> Doctors { get; private set; } = new List<Doctor>();
    }
}
