using MedHub.Core.Entities.Base;
using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class InvoiceItem : LineItem
    {
        public decimal UnitPrice { get; private set; }
        public Invoice? Invoice { get; private set; }

        public static Result<InvoiceItem> Create(int quantity)
        {
            if (quantity < 0)
            {
                return Result<InvoiceItem>.Failure("The quantity of the product from a invoice item cannot be negative.");
            }

            return Result<InvoiceItem>.Success(new InvoiceItem
            {
                Id = Guid.NewGuid(),
                Quantity = quantity,
            });
        }

        public Result AttachProductToInvoiceItem(Product? product)
        {
            if (product == null)
            {
                return Result.Failure("The product that you add to the invoice item cannot be null.");
            }

            Product = product;
            UnitPrice = product.Price;
            if (product is Service)
            {
                ((Service)product).AttachInvoiceItemToService(this);
            }
            else if (product is Drug)
            {
                ((Drug)product).AttachInvoiceItemToDrug(this);
            }

            return Result.Success();
        }

        public Result AttachInvoiceToItem(Invoice? invoice)
        {
            if (invoice == null)
            {
                return Result.Failure("The invoice cannot be null.");
            }

            Invoice = invoice;

            return Result.Success();
        }
    }
}
