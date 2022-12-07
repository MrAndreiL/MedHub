using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class DrugTests
    {
        [Fact]
        public void When_CreateDrug_Then_ShouldReturnDrug()
        {
            // Arrange
            Tuple<string, string, double> sut = CreateSUT();

            // Act
            var result = Drug.Create(sut.Item1, sut.Item2, sut.Item3);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(sut.Item1);
            result.Entity.Description.Should().Be(sut.Item2);
            result.Entity.Price.Should().Be(sut.Item3);
            result.Entity.Id.Should().NotBeEmpty();
        }

        public void When_AddAllergens_Then_ShouldUpdateAllergensList()
        {
            // Arrange
            Tuple<string, string, double> sut = CreateSUT();
            Drug drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;
            Allergen allergen = Allergen.Create("Gluten").Entity;
            HashSet<Allergen> allergens = new HashSet<Allergen>
            {
                allergen
            };

            // Act
            drug.AddListOfAllergens(allergens);

            // Assert
            drug.Allergens.Should().Contain(allergens);
            drug.Allergens.Count().Should().Be(1);

        }
        Tuple<string, string, double> CreateSUT()
        {
            return new Tuple<string, string, double>("Algocalmin", "Amelioreaza durerea de cap", 10);
        }
    }
}
