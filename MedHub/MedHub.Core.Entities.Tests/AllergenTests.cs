using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class AllergenTests
    {
        [Fact]
        public void When_CreateAllergen_Then_ShouldReturnAllergen()
        {
            // Arrange
            var allergenName = "Gluten";

            // Act
            var result = Allergen.Create(allergenName);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(allergenName);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateAllergenWithNameNull_Then_ShouldReturnFailure()
        {
            // Arrange
            string allergenName = null;

            // Act
            var result = Allergen.Create(allergenName);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateAllergenWithNameEmpty_Then_ShouldReturnFailure()
        {
            // Arrange
            string allergenName = "";

            // Act
            var result = Allergen.Create(allergenName);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AddAffectedPatientWithNotNullPatient_Then_ShouldReturnSuccess()
        {
            // Arrange
            var patient = Patient.Create("0518519082", "Ivascu", "Denis", "ivascu.denis@ceva.ro", "0724930493").Entity;
            var allergen = Allergen.Create("Gluten").Entity;
            // Act
            var result = allergen.AddAffectedPatient(patient);

            // Assert
            result.IsSuccess.Should().BeTrue();
            allergen.AffectedPatients.Should().HaveCount(1);
        }

        [Fact]
        public void When_AddAffectedPatientWithNullPatient_Then_ShouldReturnFailure()
        {
            // Arrange
            Patient patient = null;
            var allergen = Allergen.Create("Gluten").Entity;

            // Act
            var result = allergen.AddAffectedPatient(patient);

            // Assert
            result.IsFailure.Should().BeTrue();
            allergen.AffectedPatients.Should().BeEmpty();
        }

        [Fact]
        public void When_AddInfestedDrugWithNotNullDrug_Then_ShouldReturnSuccess()
        {
            // Arrange
            var drug = Drug.Create("Paracetamol", 35m).Entity;
            var allergen = Allergen.Create("Gluten").Entity;
            
            // Act
            var result = allergen.AddInfestedDrug(drug);

            // Assert
            result.IsSuccess.Should().BeTrue();
            allergen.InfestedDrugs.Should().HaveCount(1);
        }

        [Fact]
        public void When_AddInfestedDrugWithNullDrug_Then_ShouldReturnFailure()
        {
            // Arrange
            Drug drug = null;
            var allergen = Allergen.Create("Gluten").Entity;
            
            // Act
            var result = allergen.AddInfestedDrug(drug);

            // Assert
            result.IsFailure.Should().BeTrue();
            allergen.InfestedDrugs.Should().BeEmpty();
        }
    }
}
