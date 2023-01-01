using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class InvoiceItemTests
    {
        [Fact]
        public void When_CreateInvoiceItem_Then_ShouldReturnInvoiceLineItem()
        {
            // Arrange
            var quantity = 10;

            // Act
            var result = InvoiceItem.Create(quantity);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateInvoiceItemWithNegativeQuantity_Then_ShouldReturnFailure()
        {
            // Arrange
            var quantity = -15;

            // Act
            var result = InvoiceItem.Create(quantity);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachProductToInvoiceItemWithDrugInstance_Then_ShouldReturnSuccess()
        {
            // Arrange
            var drug = Drug.Create("Paracetamol", 25m).Entity;
            var invoiceItem = InvoiceItem.Create(20).Entity;

            // Act
            var result = invoiceItem.AttachProductToInvoiceItem(drug);

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoiceItem.Product.Should().Be(drug);
            invoiceItem.UnitPrice.Should().Be(drug.Price);
        }

        [Fact]
        public void When_AttachProductToInvoiceItemWithServiceInstance_Then_ShouldReturnSuccess()
        {
            // Arrange
            var service = Service.Create("Examinare RMN", 700m, "Examinare cu Imagistica prin Rezonanta Magnetica").Entity;
            var invoiceItem = InvoiceItem.Create(1).Entity;

            // Act
            var result = invoiceItem.AttachProductToInvoiceItem(service);

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoiceItem.Product.Should().Be(service);
            invoiceItem.UnitPrice.Should().Be(service.Price);
        }

        [Fact]
        public void When_AttachProductToInvoiceItemWithNullProduct_Then_ShouldReturnFailure()
        {
            // Arrange
            var invoiceItem = InvoiceItem.Create(20).Entity;

            // Act
            var result = invoiceItem.AttachProductToInvoiceItem(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            invoiceItem.Product.Should().BeNull();
            invoiceItem.UnitPrice.Should().Be(0);
        }

        [Fact]
        public void When_AttachInvoiceToItem_Then_ShouldReturnSuccess()
        {
            // Arrange
            var invoice = Invoice.Create(DateTime.Now).Entity;
            var invoiceItem = InvoiceItem.Create(10).Entity;

            // Act
            var result = invoiceItem.AttachInvoiceToItem(invoice);

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoiceItem.Invoice.Should().Be(invoice);
        }

        [Fact]
        public void When_AttachInvoiceToItemWithNullInvoice_Then_ShouldReturnFailure()
        {
            // Arrange
            var invoiceItem = InvoiceItem.Create(10).Entity;

            // Act
            var result = invoiceItem.AttachInvoiceToItem(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            invoiceItem.Invoice.Should().BeNull();
        }
    }
}
