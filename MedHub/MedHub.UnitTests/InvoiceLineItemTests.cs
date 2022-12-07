using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
