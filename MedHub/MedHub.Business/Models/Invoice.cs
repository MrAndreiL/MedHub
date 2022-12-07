using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Cabinet Seller { get; private set; }
        public Patient Buyer { get; private set; }
        public List<InvoiceLineItem> Products { get; set; } = new List<InvoiceLineItem>();
        public double Total => Products.Sum(product => product.Drug.Price * product.Quantity);
        public static Result<Invoice> Create()
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Products = new List<InvoiceLineItem>()
            };

            return Result<Invoice>.Success(invoice);
        }

        public void AddSellerToInvoice(Cabinet cabinet)
        {
            Seller = cabinet;
        }

        public void AddBuyerToInvoice(Patient patient)
        {
            Buyer = patient;
        }

        public Result AddProductsToInvoice(ICollection<InvoiceLineItem> drugsPackage)
        {
            if (!drugsPackage.Any())
            {
                return Result.Failure("Invoice drugs list should not be empty!");
            }

            foreach (var item in drugsPackage)
            {
                Products.Add(item);
                item.SetInvoiceToInvoiceLineItem(this);
            }

            return Result.Success();
        }
    }
}
