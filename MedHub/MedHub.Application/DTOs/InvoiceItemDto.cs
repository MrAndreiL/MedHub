namespace MedHub.Application.DTOs
{
    public class InvoiceItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
