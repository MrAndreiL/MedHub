using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class MedicalSpecialityTests
    {
        [Fact]
        public void When_CreateMedicalSpeciality_Then_ShouldReturnMedicalSpeciality()
        {
            // Arrange
            var specializare = "Pneumologie";

            // Act
            var result = MedicalSpeciality.Create(specializare);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(specializare);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateMedicalSpecialityWithNullSpecializationName_Then_ShouldReturnFailure()
        {
            // Arrange

            // Act
            var result = MedicalSpeciality.Create(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateMedicalSpecialityWithEmptySpecializationName_Then_ShouldReturnFailure()
        {
            // Arrange

            // Act
            var result = MedicalSpeciality.Create("");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AddDoctorToMedicalSpeciality_Then_ShouldReturnSuccess()
        {
            // Arrange
            var doctor = Doctor.Create("1950430000000", "Florin - Marian", "Hazi", "florin@hazi", "0764104921").Entity;
            var medicalSpeciality = MedicalSpeciality.Create("Pneumologie").Entity;

            // Act
            var result = medicalSpeciality.AddDoctorToMedicalSpeciality(doctor);

            // Assert
            result.IsSuccess.Should().BeTrue();
            medicalSpeciality.Doctors.Contains(doctor);
        }

        [Fact]
        public void When_AddDoctorToMedicalSpecialityWithNullDoctor_Then_ShouldReturnFailure()
        {
            // Arrange
            var medicalSpeciality = MedicalSpeciality.Create("Pneumologie").Entity;

            // Act
            var result = medicalSpeciality.AddDoctorToMedicalSpeciality(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            medicalSpeciality.Doctors.Should().BeEmpty();
        }

        [Fact]
        public void When_AddCabinetToMedicalSpeciality_Then_ShouldReturnSuccess()
        {
            // Arrange
            var cabinet = Cabinet.Create("Str. Anton Pann, Nr. 17", "0233178492").Entity;
            var medicalSpeciality = MedicalSpeciality.Create("Pneumologie").Entity;

            // Act
            var result = medicalSpeciality.AddCabinetToMedicalSpeciality(cabinet);

            // Assert
            result.IsSuccess.Should().BeTrue();
            medicalSpeciality.Cabinets.Contains(cabinet);
        }

        [Fact]
        public void When_AddCabinetToMedicalSpecialityWithNullCabinet_Then_ShouldReturnFailure()
        {
            // Arrange
            var medicalSpeciality = MedicalSpeciality.Create("Pneumologie").Entity;

            // Act
            var result = medicalSpeciality.AddCabinetToMedicalSpeciality(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            medicalSpeciality.Cabinets.Should().BeEmpty();
        }
    }
}
