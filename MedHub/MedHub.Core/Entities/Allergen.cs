using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Allergen
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public HashSet<Patient> AffectedPatients { get; private set; } = null!;
        public HashSet<Drug> InfestedDrugs { get; private set; } = null!;

        public static Result<Allergen> Create(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Allergen>.Failure("Allergen name cannot be empty.");
            }

            return Result<Allergen>.Success(new Allergen
            {
                Id = Guid.NewGuid(),
                Name = name,
                AffectedPatients = new HashSet<Patient>(),
                InfestedDrugs = new HashSet<Drug>()
            });
        }

        public Result AddAffectedPatient(Patient? patient) 
        {
            if (patient == null)
            {
                return Result.Failure($"The patient that is affected by {this.Name} allergen cannot be null.");
            }
            
            AffectedPatients.Add(patient);

            return Result.Success();
        }

        public Result AddInfestedDrug(Drug? drug)
        {
            if (drug == null)
            {
                return Result.Failure($"The drug that contain {this.Name} allergen cannot be null");
            }

            InfestedDrugs.Add(drug);

            return Result.Success();
        }
    }
}
