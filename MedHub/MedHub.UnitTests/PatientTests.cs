using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class PatientTests
    {
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
        Tuple<string, string, string, string> CreateSUT()
        {
            return new Tuple<string, string, string, string>(
                "1950430000000",
                "Florin - Marian",
                "Hazi",
                "florin@hazi"
                );
        }
    }
}
