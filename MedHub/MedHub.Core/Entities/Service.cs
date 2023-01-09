using MedHub.Core.Entities.Base;
using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Service : Product
    {
        public static Result<Service> Create(string? name, decimal price, string description = "No Description.")
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Service>.Failure("The service name cannot be null or empty.");
            }
            if (price < 0)
            {
                return Result<Service>.Failure("The service price cannot be negative.");
            }

            return Result<Service>.Success(new Service
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Description = description,
                LineItems = new HashSet<LineItem>(),
            });
        }

        public Result AttachInvoiceItemToService(InvoiceItem? invoiceItem)
        {
            if (invoiceItem == null)
            {
                return Result.Failure("The invoice item to which you attach the service cannot be null.");
            }

            LineItems.Add(invoiceItem);

            return Result.Success();
        }
    }
}
