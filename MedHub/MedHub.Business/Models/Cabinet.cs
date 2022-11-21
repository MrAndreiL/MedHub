using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Cabinet
    {
        public Guid Id { get; private set; }
        public string Address { get; private set; }
        public List<Drug> Drugs { get; private set; }

        public Cabinet(string address)
        {
            Id = Guid.NewGuid();
            Address = address;
        }

        public Result AddDrugsToCabinetStock(List<Drug> drugs)
        {
            if (!drugs.Any())
            {
                return Result.Failure("You cannot add 0 drugs to cabinet stock!");
            }

            drugs.ForEach(drug =>
            {
                Drugs.Add(drug);
            });

            return Result.Success();
        }
    }
}
