using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class AppointmentTests
    {
        [Fact]
        public void When_CreateAppointment_Then_ShouldReturnAppointment()
        {
            // Arrange
            var sut = CreateSUT();
            
            // Act
            var result = Appointment.Create(sut.Item1, sut.Item2);
            
            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.StartTime.Should().Be(sut.Item1);
            result.Entity.EndTime.Should().Be(sut.Item2);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateAppointmentWithEndTimeLessThanStartTime_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Appointment.Create(sut.Item2, sut.Item1);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachCabinetToAppointment_Then_ShouldReturnSuccess()
        {
            // Arrange
            var cabinet = Cabinet.Create("Str. Anton Pann, Nr. 17", "0233616322").Entity;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachCabinetToAppointment(cabinet);

            // Assert
            result.IsSuccess.Should().BeTrue();
            appointment.Cabinet.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachCabinetToAppointmentWithNullCabinet_Then_ShouldReturnFailure()
        {
            // Arrange
            Cabinet? cabinet = null;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachCabinetToAppointment(cabinet);

            // Assert
            result.IsFailure.Should().BeTrue();
            appointment.Cabinet.Should().BeNull();
        }

        [Fact]
        public void When_AttachPatientToAppointment_Then_ShouldReturnSuccess()
        {
            // Arrange
            var patient = Patient.Create("0518519082", "Ivascu", "Denis", "ivascu.denis@ceva.ro", "0724930493").Entity;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachPatientToAppointment(patient);

            // Assert
            result.IsSuccess.Should().BeTrue();
            appointment.Patient.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachPatientToAppointmentWithNullPatient_Then_ShouldReturnFailure()
        {
            // Arrange
            Patient? patient = null;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachPatientToAppointment(patient);

            // Assert
            result.IsFailure.Should().BeTrue();
            appointment.Patient.Should().BeNull();
        }

        [Fact]
        public void When_AttachDoctorToAppointment_Then_ShouldReturnSuccess()
        {
            // Arrange
            var doctor = Doctor.Create("1613634245", "Popescu", "Ionut", "popescu.ionut@ceva.ro", "0765718759").Entity;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachDoctorToAppointment(doctor);

            // Assert
            result.IsSuccess.Should().BeTrue();
            appointment.Doctor.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachDoctorToAppointmentWithNullDoctor_Then_ShouldReturnFailure()
        {
            // Arrange
            Doctor? doctor = null;

            var sut = CreateSUT();
            var appointment = Appointment.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = appointment.AttachDoctorToAppointment(doctor);

            // Assert
            result.IsFailure.Should().BeTrue();
            appointment.Doctor.Should().BeNull();
        }

        private static Tuple<DateTime, DateTime> CreateSUT()
        {
            return new Tuple<DateTime, DateTime>(DateTime.Now, DateTime.Now.AddDays(2));
        }
    }
}
