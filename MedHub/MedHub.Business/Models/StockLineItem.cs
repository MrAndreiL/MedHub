namespace MedHub.Domain.Models
{
    public class StockLineItem : LineItem
    {
        public Cabinet Cabinet { get; private set; }
        public Guid CabinetId { get; private set; }

        public StockLineItem() : base()
        { }
        public void SetCabinetForStockLineItem(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
            Cabinet = cabinet;
        }
    }
}
