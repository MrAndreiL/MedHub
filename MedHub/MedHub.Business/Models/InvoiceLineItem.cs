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
        public Invoice Invoice { get; private set; }
        public Guid InvoiceId { get; private set; }
        public static Result<InvoiceLineItem> Create()
        {
            var invoiceLineItem = new InvoiceLineItem
            {
                Id = Guid.NewGuid()
            };

            return Result<InvoiceLineItem>.Success(invoiceLineItem);
        }
        public void SetInvoiceToInvoiceLineItem(Invoice invoice)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
        }
    }
}
