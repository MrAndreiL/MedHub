namespace MedHub.Core.Entities.Base
{
    public abstract class LineItem
    {
        public Guid Id { get; protected set; }
        public Product? Product { get; protected set; }
        public int Quantity { get; protected set; }
    }
}
