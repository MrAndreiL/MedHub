using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Doctor : Person
    {
        public HashSet<MedicalSpeciality> Specializations { get; private set; } = null!;
        public HashSet<Cabinet> Cabinets { get; private set; } = null!;
        public HashSet<MedicalRecord> MedicalRecordIssued { get; private set; } = null!;
        public HashSet<Appointment> Appointments { get; private set; } = null!;

        public static Result<Doctor> Create(string cNP, string firstName, string lastName, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(cNP))
            {
                return Result<Doctor>.Failure("The doctor's personal numeric code cannot be empty.");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                return Result<Doctor>.Failure("The doctor's first name cannot be empty.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                return Result<Doctor>.Failure("The doctor's last name cannot be empty.");
            }
            if (string.IsNullOrEmpty(email))
            {
                return Result<Doctor>.Failure("The doctor's email cannot be empty.");
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Result<Doctor>.Failure("The doctor's phone number cannot be empty.");
            }

            return Result<Doctor>.Success(new Doctor
            {
                Id = Guid.NewGuid(),
                CNP = cNP,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Specializations = new HashSet<MedicalSpeciality>(),
                Cabinets = new HashSet<Cabinet>(),
                MedicalRecordIssued = new HashSet<MedicalRecord>(),
                Appointments = new HashSet<Appointment>(),
            });
        }

        public Result AddCabinetToDoctor(Cabinet cabinet)
        {
            if (cabinet == null)
            {
                return Result.Failure("Doctor's cabinet cannot be null.");
            }

            Cabinets.Add(cabinet);

            return Result.Success();
        }

        public Result AddSpecializations(List<MedicalSpeciality> specializations)
        {
            if (specializations == null)
            {
                return Result.Failure("The specialization list cannot be null.");
            }
            if (!specializations.Any()) 
            {
                return Result.Failure("The specialization list cannot be empty.");
            }

            specializations.ForEach(medicalSpeciality =>
            {
                Specializations.Add(medicalSpeciality);
                medicalSpeciality.AddDoctorToMedicalSpeciality(this);
            });

            return Result.Success();
        }

        public Result IssueMedicalRecord(MedicalRecord medicalRecord)
        {
            if (medicalRecord == null)
            {
                return Result.Failure("Issued medical record cannot be null.");
            }

            MedicalRecordIssued.Add(medicalRecord);

            return Result.Success();
        }

        public Result AddAppointmentToDoctor(Appointment appointment) 
        {
            if (appointment == null)
            {
                return Result.Failure("The appointment that you add to the doctor cannot be null.");
            }

            Appointments.Add(appointment);

            return Result.Success();
        }
    }
}
