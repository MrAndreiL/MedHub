namespace MedHub.Domain.Models
{
    public class LineItem
    {
        public Guid Id { get; private set; }
        public Drug Drug { get; private set; }
        public Guid DrugId { get; private set; }
        public int Quantity { get; private set; }

        public LineItem()
        {
            Id = Guid.NewGuid();
        }

        public void AddDrugAndQuantityToLineItem(Drug drug, int quantity)
        {
            DrugId = drug.Id;
            Drug = drug;
            Quantity = quantity;
        }
    }
}
