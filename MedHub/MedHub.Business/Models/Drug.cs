using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Drug
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public List<Allergen> Allergens { get; private set; }
        //Curency ?

        public Drug(string name, string description, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }

        public Result AddListOfAllergens(List<Allergen> allergens)
        {
            if (!allergens.Any())
            {
                return Result.Failure("Allergens list should not be empty!");
            }

            allergens.ForEach(a =>
            {
                Allergens.Add(a);
            });

            return Result.Success();
        }
    }
}
