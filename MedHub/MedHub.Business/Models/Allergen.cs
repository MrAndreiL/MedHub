namespace MedHub.Domain.Models
{
    public class Allergen
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Allergen(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
