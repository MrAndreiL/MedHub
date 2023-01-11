using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class DoctorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string CNP { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
