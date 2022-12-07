using MedHub.Domain.Helpers;
using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class InvoiceLineItem : ILineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }

        public InvoiceLineItem()
        {
            Id = Guid.NewGuid();
        }
        public void SetInvoiceToInvoiceLineItem(Invoice invoice)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
        }
    }
}
