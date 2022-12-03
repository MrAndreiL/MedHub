using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Drug
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public ICollection<Allergen> Allergens { get; private set; }
        public static Result<Drug> Create(string name, string description, double price)
        {
            if (String.IsNullOrEmpty(name))
            {
                return Result<Drug>.Failure("The name cannot be empty.");
            }

            var drug = new Drug
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price
            };

            return Result<Drug>.Success(drug);
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
