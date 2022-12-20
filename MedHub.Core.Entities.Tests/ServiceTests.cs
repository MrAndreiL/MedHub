using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void When_CreateService_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Service.Create(sut.Item1, sut.Item2, sut.Item3);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(sut.Item1);
            result.Entity.Description.Should().Be(sut.Item3);
            result.Entity.Price.Should().Be(sut.Item2);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateServiceWithNullName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Service.Create(null, sut.Item2, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateServiceWithEmptyName_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Service.Create("", sut.Item2, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateServiceWithNegativePrice_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Service.Create(sut.Item1, -15m, sut.Item3);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachInvoiceItemToService_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Service.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            var invoiceItem = InvoiceItem.Create(1).Entity;

            // Act
            var result = drug.AttachInvoiceItemToService(invoiceItem);

            // Assert
            result.IsSuccess.Should().BeTrue();
            drug.LineItems.Should().HaveCount(1);
            drug.LineItems.Contains(invoiceItem);
        }

        [Fact]
        public void When_AttachInvoiceItemToServiceWithNullInvoiceItem_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var drug = Service.Create(sut.Item1, sut.Item2, sut.Item3).Entity;

            // Act
            var result = drug.AttachInvoiceItemToService(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            drug.LineItems.Should().BeEmpty();
        }

        Tuple<string, decimal, string> CreateSUT()
        {
            return new Tuple<string, decimal, string>("Examinare RMN", 700m, "Examinare cu Imagistica prin Rezonanta Magnetica");
        }
    }
}
