using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class AllergenViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Allergen Name")]
        public string Name { get; set; }
    }
}
