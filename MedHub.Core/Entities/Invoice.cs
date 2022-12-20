using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Cabinet Seller { get; private set; } = null!;
        public Patient Buyer { get; private set; } = null!;
        public DateTime IssuedDate { get; private set; }
        public HashSet<InvoiceItem> Items { get; private set; } = null!;
        public decimal Total => Items.Sum(item => item.UnitPrice * item.Quantity);

        public static Result<Invoice> Create(DateTime issuedDate)
        {
            return Result<Invoice>.Success(new Invoice
            {
                Id = Guid.NewGuid(),
                IssuedDate = issuedDate,
                Items = new HashSet<InvoiceItem>(),
            });
        }

        public Result AddSellerToTheInvoice(Cabinet seller)
        {
            if (seller == null)
            {
                return Result.Failure("The seller cabinet cannot be null.");
            }

            Seller = seller;

            return Result.Success();
        }

        public Result AddBuyerToTheInvoice(Patient buyer)
        {
            if (buyer == null)
            {
                return Result.Failure("The buyer patient cannot be null.");
            }

            Buyer = buyer;

            return Result.Success();
        }

        public Result AddItemsToTheInvoice(List<InvoiceItem> invoiceItems)
        {
            if (invoiceItems == null)
            {
                return Result.Failure("The invoice item list that you add to the invoice cannot be null.");
            }
            if (!invoiceItems.Any())
            {
                return Result.Failure("The invoice item list that you add to the invoice cannot be empty.");
            }

            invoiceItems.ForEach(invoiceItem =>
            {
                Items.Add(invoiceItem);
                invoiceItem.AttachInvoiceToItem(this);
            });

            return Result.Success();
        }
    }
}
