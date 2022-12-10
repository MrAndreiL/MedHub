using MedHub.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MedHub.Domain.Models
{
    public class StockLineItem : ILineItem
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
        public Cabinet Cabinet { get; set; }
=======
        public Guid Id { get; private set; }
        public Drug Drug { get; private set; }
        public int Quantity { get; private set; }
        public Cabinet Cabinet { get; private set; }
>>>>>>> 2aa811498f7d3498bf46cf9664d47e7dca614533

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
