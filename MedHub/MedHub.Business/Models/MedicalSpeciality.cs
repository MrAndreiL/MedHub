namespace MedHub.Domain.Models
{
    public class MedicalSpeciality
    {
        public Guid Id { get; private set; }
        public string SpecializationName { get; private set; }

        public MedicalSpeciality(string specializationName)
        {
            Id = Guid.NewGuid();
            SpecializationName = specializationName;
        }
    }
}
