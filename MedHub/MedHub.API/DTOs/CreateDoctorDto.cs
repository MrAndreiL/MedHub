using MedHub.Domain.Models;

namespace MedHub.API.DTOs
{
    public class CreateDoctorDto
    {
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
