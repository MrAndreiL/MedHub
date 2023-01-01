using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class DoctorTests
    {
        [Fact]
        public void When_CreateDoctor_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5);

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
        public void When_CreateDoctorWithNullCNP_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(null, sut.Item2, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithEmptyCNP_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create("", sut.Item2, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithNullFirstName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, null, sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithEmptyFirstName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, "", sut.Item3, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithNullLastName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, null, sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithEmptyLastName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, "", sut.Item4, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithNullEmail_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, null, sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithEmptyEmail_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, "", sut.Item5);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithNullPhoneNumber_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, null);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDoctorWithEmptyPhoneNumber_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, "");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AddCabinetToDoctor_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;
            var cabinet = Cabinet.Create("Str. Anton Pann, Nr. 17", "0232197544").Entity;

            // Act
            var result = doctor.AddCabinetToDoctor(cabinet);

            // Assert
            result.IsSuccess.Should().BeTrue();
            doctor.Cabinets.Contains(cabinet);
            doctor.Cabinets.Should().HaveCount(1);
        }

        [Fact]
        public void When_AddCabinetToDoctorWithNullCabinet_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = doctor.AddCabinetToDoctor(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            doctor.Cabinets.Should().BeEmpty();
        }

        [Fact]
        public void When_AddSpecializations_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            var medicalSpeciality1 = MedicalSpeciality.Create("Pedriatrie").Entity;
            var medicalSpeciality2 = MedicalSpeciality.Create("Oncologie").Entity;

            // Act
            var result = doctor.AddSpecializations(new List<MedicalSpeciality> { medicalSpeciality1, medicalSpeciality2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            doctor.Specializations.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddSpecializationsWithNullSpecializationsList_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = doctor.AddSpecializations(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            doctor.Specializations.Should().BeEmpty();
        }

        [Fact]
        public void When_AddSpecializationsWithEmptySpecializationsList_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = doctor.AddSpecializations(new List<MedicalSpeciality>());

            // Assert
            result.IsFailure.Should().BeTrue();
            doctor.Specializations.Should().BeEmpty();
        }

        [Fact]
        public void When_IssueMedicalRecord_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            var medicalRecord = MedicalRecord.Create("Rezultat autopsie.. xD").Entity;

            // Act
            var result = doctor.IssueMedicalRecord(medicalRecord);
            
            // Assert
            result.IsSuccess.Should().BeTrue();
            doctor.MedicalRecordIssued.Contains(medicalRecord);
        }

        [Fact]
        public void When_IssueMedicalRecordWithNullMedicalRecord_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = doctor.IssueMedicalRecord(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            doctor.MedicalRecordIssued.Should().BeEmpty();
        }

        [Fact]
        public void When_AddAppointmentToDoctor_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddDays(2);
            var appointment = Appointment.Create(startTime, endTime).Entity;

            // Act
            var result = doctor.AddAppointmentToDoctor(appointment);

            // Assert
            result.IsSuccess.Should().BeTrue();
            doctor.Appointments.Contains(appointment);
        }

        [Fact]
        public void When_AddAppointmentToDoctorWithNullAppointment_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            var result = doctor.AddAppointmentToDoctor(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            doctor.Appointments.Should().BeEmpty();
        }

        /*
        [Fact]
        public void When_AddSpecialization_Then_ShouldSaveSpecialization()
        {
            // Arrange
            var medicalSpeciality = MedicalSpeciality.Create("Pneumologie").Entity;
            var sut = CreateSUT();
            Doctor doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4, sut.Item5).Entity;

            // Act
            doctor.AddSpecialization(medicalSpeciality);

            // Assert
            doctor.Specializations.Contains(medicalSpeciality);
            doctor.Specializations.Count().Should().Be(1);
        }

        */
        /*
        [Fact]
        public void When_SetCabinet_Then_ShouldSaveCabinet()
        {
            // Arrange
            Cabinet cabinet = Cabinet.Create("Iasi, Romania").Entity;
            Tuple<string, string, string, string> sut = CreateSUT();
            Doctor doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4).Entity;

            // Act
            doctor.SetCabinetToDoctor(cabinet);

            // Assert
            doctor.Cabinets.Contains(cabinet);
            doctor.Cabinets.Count().Should().Be(1);
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
