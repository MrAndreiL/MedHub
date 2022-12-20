using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Patient : Person
    {
        public HashSet<MedicalRecord> MedicalHistory { get; private set; } = null!;
        public HashSet<Allergen> Allergies { get; private set; } = null!;
        public HashSet<Appointment> Appointments { get; private set; } = null!;

        public static Result<Patient> Create(string cNP, string firstName, string lastName, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(cNP))
            {
                return Result<Patient>.Failure("The patient's personal numeric code cannot be empty.");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                return Result<Patient>.Failure("The patient's first name cannot be empty.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                return Result<Patient>.Failure("The patient's last name cannot be empty.");
            }
            if (string.IsNullOrEmpty(email)) 
            {
                return Result<Patient>.Failure("The patient's email cannot be empty.");
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Result<Patient>.Failure("The patient's phone number cannot be empty.");
            }

            return Result<Patient>.Success(new Patient
            {
                Id = Guid.NewGuid(),
                CNP = cNP,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                MedicalHistory = new HashSet<MedicalRecord>(),
                Allergies = new HashSet<Allergen>(),
                Appointments = new HashSet<Appointment>(),
            });
        }

        public Result AddAllergies(List<Allergen> allergies)
        {
            if (allergies == null) 
            {
                return Result.Failure("Allergies list cannot be null");
            }
            if (!allergies.Any())
            {
                return Result.Failure("Allergies list cannot be empty");
            }

            allergies.ForEach(a =>
            {
                Allergies.Add(a);
                a.AddAffectedPatient(this);
            });

            return Result.Success();
        }

        public Result AddMedicalHistory(List<MedicalRecord> medicalHistory) 
        {
            if (medicalHistory == null) 
            {
                return Result.Failure("Medical history cannot be null.");
            }
            if (!medicalHistory.Any())
            {
                return Result.Failure("Medical history cannot be empty.");
            }

            medicalHistory.ForEach(medicalRecord => {
                MedicalHistory.Add(medicalRecord);
                medicalRecord.AttachPatientToMedicalRecord(this);
            });

            return Result.Success();
        }

        public Result AddAppointmentToPatient(Appointment appointment)
        {
            if (appointment == null)
            {
                return Result.Failure("The appointment that you add from the patient cannot be null.");
            }

            Appointments.Add(appointment);

            return Result.Success();
        }
    }
}
