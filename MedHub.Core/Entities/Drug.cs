using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Drug : Product
    {
        public HashSet<Allergen> Allergens { get; private set; } = null!;

        public static Result<Drug> Create(string name, decimal price, string description = "No Description.")
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Drug>.Failure("Drug name cannot be null or empty.");
            }
            if (price < 0)
            {
                return Result<Drug>.Failure("Drug price cannot be negative.");
            }

            return Result<Drug>.Success(new Drug
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Allergens = new HashSet<Allergen>(),
                LineItems = new HashSet<LineItem>(),
            });
        }

        public Result AddAllergens(List<Allergen> allergens)
        {
            if (allergens == null)
            {
                return Result.Failure("The alergens list cannot be null.");
            }
            if (!allergens.Any())
            {
                return Result.Failure("The alergens list cannot be empty.");
            }
            
            allergens.ForEach(allergen =>
            {
                Allergens.Add(allergen);
                allergen.AddInfestedDrug(this);
            });

            return Result.Success();
        }

        public Result AttachStockItemToDrug(StockItem stockItem)
        {
            if (stockItem == null)
            {
                return Result.Failure("The stock item to which you attach the drug cannot be null.");
            }

            LineItems.Add(stockItem);

            return Result.Success();
        }

        public Result AttachInvoiceItemToDrug(InvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                return Result.Failure("The invoice item to which you attach the drug cannot be null.");
            }

            LineItems.Add(invoiceItem);

            return Result.Success();
        }
    }
}
