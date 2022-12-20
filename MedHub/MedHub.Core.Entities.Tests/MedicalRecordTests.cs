using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class MedicalRecordTests
    {
        [Fact]
        public void When_CreateMedicalRecord_Then_ShouldReturnMedicalRecord()
        {
            // Arrange
            var medicalNote = "Sanatos tun";

            // Act
            var result = MedicalRecord.Create(medicalNote);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateMedicalRecordWithNullMedicalNote_Then_ShouldReturnFailure()
        {
            // Arrange
            
            // Act
            var result = MedicalRecord.Create(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateMedicalRecordWithEmptyMedicalNote_Then_ShouldReturnFailure()
        {
            // Arrange

            // Act
            var result = MedicalRecord.Create("");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachPatientToMedicalRecord_Then_ShouldReturnSuccess()
        {
            // Arrange
            var patient = Patient.Create("1950430000000", "Florin - Marian", "Hazi", "florin@hazi", "0743518272").Entity;
            var medicalRecord = MedicalRecord.Create("Sanatos tun").Entity;

            // Act
            var result = medicalRecord.AttachPatientToMedicalRecord(patient);

            // Assert
            result.IsSuccess.Should().BeTrue();
            medicalRecord.Patient.Should().Be(patient);
        }

        [Fact]
        public void When_AttachPatientToMedicalRecordWithNullPatient_Then_ShouldReturnFailure()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create("Sanatos tun").Entity;

            // Act
            var result = medicalRecord.AttachPatientToMedicalRecord(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            medicalRecord.Patient.Should().BeNull();
        }

        [Fact]
        public void When_AttachDoctorToMedicalRecord_Then_ShouldReturnSuccess()
        {
            // Arrange
            var doctor = Doctor.Create("1950430000000", "Florin - Marian", "Hazi", "florin@hazi", "0764104921").Entity;
            var medicalRecord = MedicalRecord.Create("Sanatos tun").Entity;

            // Act
            var result = medicalRecord.AttachDoctorToMedicalRecord(doctor);

            // Assert
            result.IsSuccess.Should().BeTrue();
            medicalRecord.Doctor.Should().Be(doctor);
        }

        [Fact]
        public void When_AttachDoctorToMedicalRecordWithNullDoctor_Then_ShouldReturnFailure()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create("Sanatos tun").Entity;

            // Act
            var result = medicalRecord.AttachDoctorToMedicalRecord(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            medicalRecord.Doctor.Should().BeNull();
        }
    }
}
