using MedHub.Domain.Helpers;

namespace MedHub.Domain.Models
{
    public class MedicalRecord
    {
        public Guid Id { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public string MedicalNote { get; private set; }
        public DateTime Date { get; private set; }
        public static Result<MedicalRecord> Create(Doctor doctor, Patient patient, string medicalNote)
        {
            if (String.IsNullOrEmpty(medicalNote))
            {
                return Result<MedicalRecord>.Failure("The medical note cannot be empty.");
            }

            var medicalRecord = new MedicalRecord
            {
                Id = Guid.NewGuid(),
                Doctor= doctor,
                Patient = patient,
                MedicalNote = medicalNote,
                Date = DateTime.Now
            };

            return Result<MedicalRecord>.Success(medicalRecord);
        }
    }
}
