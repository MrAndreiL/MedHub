using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class StockStockLineItemTests
    {

        [Fact]
        public void When_CreateStockLineItem_Then_ShouldReturnStockLineItem()
        {
            // Arrange

            // Act
            var result = new StockLineItem();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
