namespace MedHub.Shared.Domain
{
    public class Drug
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Allergen> Allergens { get; set; }
    }
}
