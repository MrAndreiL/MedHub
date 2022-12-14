using FluentAssertions;
using MedHub.Domain.Helpers;
using MedHub.Domain.Models;

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
            Result<Cabinet> cabinet = CreateSUTCabinet();
            var invoice = Invoice.Create().Entity;

            invoice.AddSellerToInvoice(cabinet.Entity);

            invoice.Seller.Should().NotBeNull();
            invoice.Seller.Should().Be(cabinet);
        }

        

        [Fact]
        public void When_AddingBuyerToInvoice_Then_BuyerShouldBeSet()
        {

            Result<Patient> patient = Patient.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4);
            var invoice = Invoice.Create().Entity;

            invoice.AddBuyerToInvoice(patient.Entity);

            invoice.Seller.Should().NotBeNull();
            invoice.Seller.Should().Be(patient);
        }
        private static Result<Cabinet> CreateSUTCabinet()
        {
            return Cabinet.Create("strada Carol 1");
        }
        Tuple<string, string, string, string> CreateSUTPatient()
        {
            return new Tuple<string, string, string, string>(
                "1950430000000",
                "Florin - Marian",
                "Hazi",
                "florin@hazi"
                );
        }

    }
}
