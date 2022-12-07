using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.UnitTests
{
    public class InvoiceTests
    {
        [Fact]
        public void When_CreateInvoice_Then_ShouldReturnInvoice()
        {
            // Arrange

            // Act
            var result = Invoice.Create();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Id.Should().NotBeEmpty();
        }
        [Fact]
        public void When_AddingSellerToInvoice_Then_SellerShouldBeSet()
        {
            var cabinet = Cabinet.Create("strada Carol 1");
            var result = Invoice.Create();

            result.Entity.AddSellerToInvoice(cabinet.Entity);

            cabinet.Entity.S

        }

    }
}
