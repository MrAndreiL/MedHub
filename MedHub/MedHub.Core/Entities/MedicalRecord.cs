using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class MedicalRecord
    {
        public Guid Id { get; private set; }
        public Patient Patient { get; private set; } = null!;
        public Doctor Doctor { get; private set; } = null!;
        public string MedicalNote { get; private set; } = null!;
        public DateTime RegistrationDate { get; private set; }

        public static Result<MedicalRecord> Create(string? medicalNote)
        {
            if (string.IsNullOrEmpty(medicalNote))
            {
                return Result<MedicalRecord>.Failure("The medical note cannot be empty.");
            }

            return Result<MedicalRecord>.Success(new MedicalRecord 
            {
                Id = Guid.NewGuid(),
                MedicalNote = medicalNote,
                RegistrationDate = DateTime.Now,
            });
        }

        public Result AttachPatientToMedicalRecord(Patient? patient)
        {
            if (patient == null)
            {
                return Result.Failure("The patient's medical record cannot be null.");
            }

            Patient = patient;

            return Result.Success();
        }

        public Result AttachDoctorToMedicalRecord(Doctor? doctor)
        {
            if (doctor == null)
            {
                return Result.Failure("The doctor that create the medical record should not be null.");
            }

            Doctor = doctor;

            return Result.Success();
        }
    }
}
