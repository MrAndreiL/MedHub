using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class InvoiceLineItemTests
    {

        [Fact]
        public void When_CreateInvoiceLineItem_Then_ShouldReturnInvoiceLineItem()
        {
            // Arrange

            // Act
            var result = new InvoiceLineItem();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
