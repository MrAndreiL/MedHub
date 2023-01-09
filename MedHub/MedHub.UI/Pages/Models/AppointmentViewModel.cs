using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string? Comment { get; set; }
    }
}
