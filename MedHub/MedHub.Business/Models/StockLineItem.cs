using MedHub.Domain.Interfaces;

namespace MedHub.Domain.Models
{
    public class StockLineItem : ILineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
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
