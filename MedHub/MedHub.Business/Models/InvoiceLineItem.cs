namespace MedHub.Domain.Models
{
    public class InvoiceLineItem : LineItem
    {
        public Invoice Invoice { get; private set; }
        public Guid InvoiceId { get; private set; }

        public InvoiceLineItem() : base()
        { }

        public void SetInvoiceToInvoiceLineItem(Invoice invoice)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
        }
    }
}
