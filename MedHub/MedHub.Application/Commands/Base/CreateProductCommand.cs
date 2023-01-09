namespace MedHub.Application.Commands.Base
{
    public class CreateProductCommand
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
