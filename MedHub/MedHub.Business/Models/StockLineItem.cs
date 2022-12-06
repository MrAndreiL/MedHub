using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class StockLineItem : ILineItem
    {
        public Guid Id { get; private set; }
        public Drug Drug { get; private set; }
        public int Quantity { get; private set; }
        public Cabinet Cabinet { get; private set; }

        public StockLineItem() : base()
        {
            Id = Guid.NewGuid();
        }
        public void AddDrugAndQuantityToLineItem(Drug drug, int quantity)
        {
            Drug = drug;
            Quantity = quantity;
        }
        public void SetCabinet(Cabinet cabinet)
        {
            Cabinet = cabinet;
        }
    }
}
