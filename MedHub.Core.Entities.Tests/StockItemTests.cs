using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class StockItemTests
    {
        [Fact]
        public void When_CreateStockItem_Then_ShouldReturnStockLineItem()
        {
            // Arrange
            var quantity = 10;

            // Act
            var result = StockItem.Create(quantity);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateStockItemWithNegativeQuantity_Then_ShouldReturnFailure()
        {
            // Arrange
            var quantity = -15;

            // Act
            var result = StockItem.Create(quantity);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachDrugToStockItem_Then_ShouldReturnSuccess()
        {
            // Arrange
            var drug = Drug.Create("Paracetamol", 25m).Entity;
            var stockItem = StockItem.Create(20).Entity;

            // Act
            var result = stockItem.AttachDrugToStockItem(drug);

            // Assert
            result.IsSuccess.Should().BeTrue();
            stockItem.Product.Should().Be(drug);
        }

        [Fact]
        public void When_AttachDrugToStockItemWithNullDrug_Then_ShouldReturnFailure()
        {
            // Arrange
            var stockItem = StockItem.Create(20).Entity;

            // Act
            var result = stockItem.AttachDrugToStockItem(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            stockItem.Product.Should().BeNull();
        }

        [Fact]
        public void When_AttachCabinetToStockItem_Then_ShouldReturnSuccess()
        {
            // Arrange
            var cabinet = Cabinet.Create("Str. Anton Pann, Nr. 17", "0233750159").Entity;
            var stockItem = StockItem.Create(10).Entity;

            // Act
            var result = stockItem.AttachCabinetToStockItem(cabinet);

            // Assert
            result.IsSuccess.Should().BeTrue();
            stockItem.Cabinet.Should().Be(cabinet);
        }

        [Fact]
        public void When_AttachCabinetToStockItemWithNullCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var stockItem = StockItem.Create(10).Entity;

            // Act
            var result = stockItem.AttachCabinetToStockItem(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            stockItem.Cabinet.Should().BeNull();
        }
    }
}
