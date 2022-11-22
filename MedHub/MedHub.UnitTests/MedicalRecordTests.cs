
using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class MedicalRecordTests
    {

        [Fact]
        public void When_SettingPatientToMedicalRecord_Then_PatientShouldHaveRecordInMedicalHystory()
        {
            var medicalRecord = new MedicalRecord("some medical note from a doctor");
            var patient = new Patient("6221113017906", "Popescu", "Ion", "popescuion2222@mail.com");
            
            medicalRecord.SetPatientToMedicalRecord(patient);

            patient.MedicalHistory.Should().NotBeEmpty();
            patient.MedicalHistory.Should().Contain(medicalRecord);
        }
        [Fact]
        public void When_SettingDoctorToMedicalRecord_Then_MedicalRecordShouldHaveAnAssignedDoctor()
        {
            var medicalRecord = new MedicalRecord("some medical note from a doctor");
            var doctor = new Doctor("6221113017906", "Popescu", "Ion", "popescuion2222@mail.com");

            medicalRecord.SetDoctorToMedicalRecord(doctor);


            medicalRecord.Doctor.Should().NotBeNull();
            medicalRecord.Doctor.Should().Be(doctor);
            medicalRecord.DoctorId.Should().Be(doctor.Id);
        }
    }
}