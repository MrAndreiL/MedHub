namespace MedHub.Domain.Models
{
    public class MedicalRecord
    {
        public Guid Id { get; private set; }
        public Patient Patient { get; private set; }
        public Guid PatientId { get; private set; }
        public string MedicalNote { get; private set; }
        public Doctor Doctor { get; private set; }
        public Guid DoctorId { get; private set; }
        public DateTime Date { get; private set; }

        public MedicalRecord(string medicalNote, DateTime date)
        {
            Id = Guid.NewGuid();
            MedicalNote = medicalNote;
            Date = date;
        }

        public void SetPatientToMedicalRecord(Patient patient)
        {
            PatientId = patient.Id;
            Patient = patient;
            patient.AddMedicalRecordToMedicalHistory(this);
        }

        public void SetDoctorToMedicalRecord(Doctor doctor)
        {
            DoctorId = doctor.Id;
            Doctor = doctor;
        }
    }
}
