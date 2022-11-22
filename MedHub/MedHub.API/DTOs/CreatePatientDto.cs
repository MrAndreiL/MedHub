namespace MedHub.API.DTOs
{
    public class CreatePatientDto
    {
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
