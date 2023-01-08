namespace MedHub.Core.Entities
{
    public class LineItem
    {
        public Guid Id { get; protected set; }
        public Product? Product { get; protected set; }
        public int Quantity { get; protected set; }
    }
}
