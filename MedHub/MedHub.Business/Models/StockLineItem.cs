using MedHub.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MedHub.Domain.Models
{
    public class StockLineItem : ILineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
        public Cabinet Cabinet { get; set; }

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
