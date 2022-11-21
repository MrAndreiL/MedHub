using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Patient Patient { get; private set; }
        public Guid PatientId { get; private set; }
        public List<Drug> Drugs { get; private set; }
        //Aici cred ca trebuie adaugat ceva ca la partial (fiecare Drug sa aiba o cantitate)
        public double Price => Drugs.Sum(drug => drug.Price);

        public Invoice()
        {
            Id = Guid.NewGuid();
        }

        public void AddPatientToInvoice(Patient patient)
        {
            Patient = patient;
            PatientId = patient.Id;
        }

        public Result AddDrugsListToInvoice(List<Drug> drugs)
        {
            if (!drugs.Any())
            {
                return Result.Failure("Drugs should not be empty!");
            }

            drugs.ForEach(drug =>
            {
                // cred ca ar trebui adaugata aici si in obiectul de tip Drug o referinta la invoice-ul asta
                Drugs.Add(drug);
            });

            return Result.Success();
        }
    }
}
