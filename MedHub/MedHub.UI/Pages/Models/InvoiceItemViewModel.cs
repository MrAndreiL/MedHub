using System.ComponentModel.DataAnnotations;

namespace MedHub.UI.Pages.Models
{
    public class InvoiceItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
