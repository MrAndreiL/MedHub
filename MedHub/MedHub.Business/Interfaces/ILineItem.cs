using MedHub.Domain.Models;

namespace MedHub.Domain.Interfaces
{
    public interface ILineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public void AddDrugAndQuantityToLineItem(Drug drug, int quantity)
        {
            DrugId = drug.Id;
            Drug = drug;
            Quantity = quantity;
        }
    }
}
