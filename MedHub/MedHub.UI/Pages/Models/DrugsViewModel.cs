using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class DrugsViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
