namespace MedHub.Domain.Models
{
    public class Drug
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public ICollection<Allergen> Allergens { get; private set; }

        public Drug(string name, string description, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }

        public void AddListOfAllergens(ICollection<Allergen> allergens)
        {
            foreach (var allergen in allergens)
            {
                Allergens.Add(allergen);
            }
        }
    }
}
