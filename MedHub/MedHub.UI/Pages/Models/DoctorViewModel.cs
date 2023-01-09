using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class DoctorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Personal Identification Number")]
        public string CNP { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
