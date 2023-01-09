namespace MedHub.Application.DTOs.Base
{
    public abstract class LineItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
