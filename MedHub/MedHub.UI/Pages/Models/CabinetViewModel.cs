using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class CabinetViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = null!;
    }
}
