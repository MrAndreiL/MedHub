using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.IntegrationTests
{
    public class AllergensTests
    {
        [Fact]
        public void When_CreateAllergen_Then_ShouldReturnAllergen()
        {
            // Arrange
            Tuple<string> sut = CreateSUT();

            // Act
            var result = Allergen.Create(sut.Item1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(sut.Item1);
            result.Entity.Id.Should().NotBeEmpty();
        }
        private Tuple<string> CreateSUT()
        {
            Tuple<string> sut = new Tuple<string>("Gluten");

            return sut;
        }
    }
}
