using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class DrugTests
    {
        [Fact]
        public void When_CreateDrug_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Drug.Create(sut.Item1, sut.Item2, sut.Item3);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(sut.Item1);
            result.Entity.Description.Should().Be(sut.Item3);
            result.Entity.Price.Should().Be(sut.Item2);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateDrugWithNullName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Drug.Create(null, sut.Item2, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDrugWithEmptyName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Drug.Create("", sut.Item2, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateDrugWithNegativePrice_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Drug.Create(sut.Item1, -15m, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AddAllergens_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            var allergen1 = Allergen.Create("Gluten").Entity;
            var allergen2 = Allergen.Create("Lactate").Entity;

            // Act
            var result = drug.AddAllergens(new List<Allergen> { allergen1, allergen2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            drug.Allergens.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddAllergensWithNullAllergenList_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            // Act
            var result = drug.AddAllergens(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            drug.Allergens.Should().BeEmpty();
        }

        [Fact]
        public void When_AddAllergensWithEmptyAllergenList_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            // Act
            var result = drug.AddAllergens(new List<Allergen>());

            // Assert
            result.IsFailure.Should().BeTrue();
            drug.Allergens.Should().BeEmpty();
        }

        [Fact]
        public void When_AttachStockItemToDrug_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            var stockItem = StockItem.Create(10).Entity;

            // Act
            var result = drug.AttachStockItemToDrug(stockItem);

            // Assert
            result.IsSuccess.Should().BeTrue();
            drug.LineItems.Should().HaveCount(1);
            drug.LineItems.Contains(stockItem);
        }

        [Fact]
        public void When_AttachStockItemToDrugWithNullStockItem_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            // Act
            var result = drug.AttachStockItemToDrug(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            drug.LineItems.Should().BeEmpty();
        }

        [Fact]
        public void When_AttachInvoiceItemToDrug_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            var invoiceItem = InvoiceItem.Create(10).Entity;

            // Act
            var result = drug.AttachInvoiceItemToDrug(invoiceItem);

            // Assert
            result.IsSuccess.Should().BeTrue();
            drug.LineItems.Should().HaveCount(1);
            drug.LineItems.Contains(invoiceItem);
        }

        [Fact]
        public void When_AttachInvoiceItemToDrugWithNullInvoiceItem_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Drug.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            // Act
            var result = drug.AttachInvoiceItemToDrug(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            drug.LineItems.Should().BeEmpty();
        }

        /*
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
        */

        private static Tuple<string, decimal, string> CreateSUT()
        {
            return new Tuple<string, decimal, string>("Algocalmin", 20m, "Amelioreaza durerea de cap");
        }
    }
}
