using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime IssuedDate { get; set; }
    }
}
