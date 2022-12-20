using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class InvoiceTests
    {
        [Fact]
        public void When_CreateInvoice_Then_ShouldReturnSuccess()
        {
            // Arrange
            var issuedTime = DateTime.Now;

            // Act
            var result = Invoice.Create(issuedTime);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Id.Should().NotBeEmpty();
        }

        
        [Fact]
        public void When_AddingSellerToTheInvoice_Then_SellerShouldBeSet()
        {
            // Arrange
            var cabinet = Cabinet.Create("strada Carol 1", "0233741233").Entity;
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddSellerToTheInvoice(cabinet);

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoice.Seller.Should().Be(cabinet);
        }

        [Fact]
        public void When_AddingSellerToTheInvoiceWithNullCabinet_Then_ShouldReturnFailure()
        {
            // Arrange
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddSellerToTheInvoice(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            invoice.Seller.Should().BeNull();
        }

        [Fact]
        public void When_AddBuyerToTheInvoice_Then_ShouldReturnSuccess()
        {
            // Arrange
            var patient = Patient.Create("0518519082", "Ivascu", "Denis", "ivascu.denis@ceva.ro", "0724930493").Entity;
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddBuyerToTheInvoice(patient);

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoice.Buyer.Should().Be(patient);
        }

        [Fact]
        public void When_AddBuyerToTheInvoiceWithNullPatient_Then_ShouldReturnFailure()
        {
            // Arrange
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddBuyerToTheInvoice(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            invoice.Buyer.Should().BeNull();
        }

        [Fact]
        public void When_AddItemsToTheInvoice_ThenShouldReturnSuccess()
        {
            // Arrange
            var invoiceItem1 = InvoiceItem.Create(10).Entity;
            var invoiceItem2 = InvoiceItem.Create(20).Entity;

            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddItemsToTheInvoice(new List<InvoiceItem> { invoiceItem1, invoiceItem2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            invoice.Items.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddItemsToTheInvoiceWithNullInvoiceItemList_ThenShouldReturnFailure()
        {
            // Arrange
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddItemsToTheInvoice(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            invoice.Items.Should().BeEmpty();
        }

        [Fact]
        public void When_AddItemsToTheInvoiceWithEmptyInvoiceItemList_ThenShouldReturnFailure()
        {
            // Arrange
            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = invoice.AddItemsToTheInvoice(new List<InvoiceItem>());

            // Assert
            result.IsFailure.Should().BeTrue();
            invoice.Items.Should().BeEmpty();
        }
    }
}
