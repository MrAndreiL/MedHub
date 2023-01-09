using MedHub.Application.DTOs.Base;

namespace MedHub.Application.DTOs
{
    public class InvoiceItemDto : LineItemDto
    {
        public decimal UnitPrice { get; set; }
    }
}
