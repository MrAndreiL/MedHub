using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class PatientTests
    {
        [Fact]
        public void When_CreatePatient_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.CNP.Should().Be(sut.Item1);
            result.Entity.FirstName.Should().Be(sut.Item2);
            result.Entity.LastName.Should().Be(sut.Item3);
            result.Entity.Email.Should().Be(sut.Item4);
            result.Entity.PhoneNumber.Should().Be(sut.Item5);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreatePatientWithNullCNP_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(null, sut.Item2, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithEmptyCNP_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create("", sut.Item2, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithNullFirstName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, null, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithEmptyFirstName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, "", sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithNullLastName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, null, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithEmptyLastName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, "", sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithNullEmail_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, null, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithEmptyEmail_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, "", sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithNullPhoneNumber_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, null);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreatePatientWithEmptyPhoneNumber_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, "");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AddAllergies_Then_ShouldReturnSuccess()
        {
            // Arrange
            var allergy1 = Allergen.Create("Gluten").Entity;
            var allergy2 = Allergen.Create("PrafDeZana").Entity;

            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddAllergies(new List<Allergen> { allergy1, allergy2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            patient.Allergies.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddAllergiesWithNullAllergies_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddAllergies(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            patient.Allergies.Should().BeEmpty();
        }

        [Fact]
        public void When_AddAllergiesWithEmptyAllergies_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddAllergies(new List<Allergen>());

            // Assert
            result.IsFailure.Should().BeTrue();
            patient.Allergies.Should().BeEmpty();
        }

        [Fact]
        public void When_AddMedicalHistory_Then_ShouldReturnSuccess()
        {
            // Arrange
            var medicalRecord1 = MedicalRecord.Create("Dermatita, necesita tratament imediat.").Entity;
            var medicalRecord2 = MedicalRecord.Create("Sanatos tun.").Entity;

            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddMedicalHistory(new List<MedicalRecord> { medicalRecord1, medicalRecord2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            patient.MedicalHistory.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddMedicalHistoryWithNullMedicalHistory_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddMedicalHistory(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            patient.MedicalHistory.Should().BeEmpty();
        }

        [Fact]
        public void When_AddMedicalHistoryWithEmptyMedicalHistory_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = patient.AddMedicalHistory(new List<MedicalRecord>());

            // Assert
            result.IsFailure.Should().BeTrue();
            patient.MedicalHistory.Should().BeEmpty();
        }

        [Fact]
        public void When_AddAppointmentToPatient_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            var appointment = Appointment.Create(DateTime.Now, DateTime.Now.AddDays(2), "Dupa accidentare resimt spasme articulare.").Entity;

            // Act
            var result = patient.AddAppointmentToPatient(appointment);

            // Assert
            result.IsSuccess.Should().BeTrue();
            patient.Appointments.Contains(appointment);
        }

        [Fact]
        public void When_AddAppointmentToPatientWithNullAppointment_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;
            // Act
            var result = patient.AddAppointmentToPatient(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            patient.Appointments.Should().BeEmpty();
        }

        /*
        [Fact]
        public void When_CreatePatient_Then_ShouldReturnPatient()
        {
            // Arrange
            Tuple<string, string, string, string> sut = CreateSUT();

            // Act
            var result = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.CNP.Should().Be(sut.Item1);
            result.Entity.FirstName.Should().Be(sut.Item2);
            result.Entity.LastName.Should().Be(sut.Item3);
            result.Entity.Email.Should().Be(sut.Item4);
            result.Entity.Id.Should().NotBeEmpty();
        }
        */

        private static Tuple<string, string, string, string, string> CreateSUT()
        {
            return new Tuple<string, string, string, string, string>(
                "1950430000000",
                "Florin - Marian",
                "Hazi",
                "florin@hazi",
                "0746928291"
            );
        }
    }
}
