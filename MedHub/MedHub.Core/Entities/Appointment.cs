using MedHub.Core.Helpers;

namespace MedHub.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Cabinet? Cabinet { get; private set; }
        public Patient? Patient { get; private set; }
        public Doctor? Doctor { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string? Comment { get; private set; }

        public static Result<Appointment> Create(DateTime startTime, DateTime endTime, string comment = "Empty.")
        {
            if (endTime < startTime)
            {
                return Result<Appointment>.Failure("The appointment could not end before it starts.");
            }

            return Result<Appointment>.Success(new Appointment
            {
                Id = Guid.NewGuid(),
                StartTime = startTime,
                EndTime = endTime,
                Comment = comment
            });
        }

        public Result AttachCabinetToAppointment(Cabinet? cabinet)
        {
            if (cabinet == null)
            {
                return Result.Failure("The cabinet must not be null when an appointment is created.");
            }

            Cabinet = cabinet;
            cabinet.BindAppointmentToCabinet(this);

            return Result.Success();
        }

        public Result AttachPatientToAppointment(Patient? patient)
        {
            if (patient == null)
            {
                return Result.Failure("The patient must not be null when an appointment is created.");
            }

            Patient = patient;
            patient.AddAppointmentToPatient(this);

            return Result.Success();
        }

        public Result AttachDoctorToAppointment(Doctor? doctor)
        {
            if (doctor == null)
            {
                return Result.Failure("The doctor must not be null when an appointment is created.");
            }

            Doctor = doctor;
            doctor.AddAppointmentToDoctor(this);

            return Result.Success();
        }
    }
}
