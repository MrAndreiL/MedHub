using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class StockItem : LineItem
    {
        public Cabinet Cabinet { get; private set; } = null!;

        public static Result<StockItem> Create(int quantity)
        {
            if (quantity < 0)
            {
                return Result<StockItem>.Failure("The quantity of the product from a stock item cannot be negative.");
            }

            return Result<StockItem>.Success(new StockItem
            {
                Id = Guid.NewGuid(),
                Quantity = quantity,
            });
        }

        public Result AttachCabinetToStockItem(Cabinet? cabinet)
        {
            if (cabinet == null)
            {
                return Result.Failure("The cabinet that you attach to the stock item cannot be null");
            }

            Cabinet = cabinet;

            return Result.Success();
        }

        public Result AttachDrugToStockItem(Drug? drug) { 
            if (drug == null)
            {
                return Result.Failure("The drug that you want to attach to the stock item cannot be null.");
            }

            Product = drug;

            return Result.Success();
        }
    }
}
