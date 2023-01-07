namespace MedHub.Application.DTOs
{
    public class CabinetDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
