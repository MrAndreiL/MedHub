namespace MedHub.Application.DTOs
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Comment { get; set; }
    }
}
