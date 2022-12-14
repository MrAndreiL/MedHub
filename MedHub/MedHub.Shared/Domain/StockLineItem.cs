namespace MedHub.Shared.Domain
{
    public class StockLineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get;  set; }
        public int Quantity { get;  set; }
        public Cabinet Cabinet { get;  set; }

    }
}
