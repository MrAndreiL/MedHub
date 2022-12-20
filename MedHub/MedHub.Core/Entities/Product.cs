namespace MedHub.Core.Entities
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; } = null!;
        public string? Description { get; protected set; }
        public decimal Price { get; protected set; }
        public HashSet<LineItem> LineItems { get; protected set; } = null!;
    }
}
