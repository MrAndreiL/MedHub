using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Allergen
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public static Result<Allergen> Create(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return Result<Allergen>.Failure("The name cannot be empty.");
            }

            var allergen = new Allergen
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return Result<Allergen>.Success(allergen);
        }
    }
}
