using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class LineItemTests
    {

        [Fact]
        public void When_CreateLineItem_Then_ShouldReturnLineItem()
        {
            // Arrange

            // Act
            var result = new LineItem();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
