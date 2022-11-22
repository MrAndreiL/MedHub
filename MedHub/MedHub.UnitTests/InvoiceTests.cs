using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class InvoiceTests
    {
        [Fact]
        public void When_AddingProductsToInvoice_Then_ShouldReturnSucces()
        {
            var invoice = new Invoice();
            var drug1 = new Drug("paracetamol", "anti febra", 10);
            var drug2 = new Drug("sumedon", "anti virus", 20);

            var invoiceLineItems = new List<InvoiceLineItem>()
            {
               new InvoiceLineItem(),
               new InvoiceLineItem(),
            };

            invoiceLineItems[0].AddDrugAndQuantityToLineItem(drug1, 100);
            invoiceLineItems[1].AddDrugAndQuantityToLineItem(drug2, 100);


            var result = invoice.AddProductsToInvoice(invoiceLineItems);
            var resultFail = invoice.AddProductsToInvoice(new List<InvoiceLineItem>());

            invoiceLineItems[0].Should().NotBeNull();
            invoiceLineItems[0].Drug.Should().Be(drug1);
            invoiceLineItems[0].DrugId.Should().Be(drug1.Id);
            invoiceLineItems[0].Quantity.Should().Be(100);

            invoiceLineItems[0].Invoice.Should().NotBeNull();
            invoiceLineItems[0].Invoice.Should().Be(invoice);
            invoiceLineItems[0].InvoiceId.Should().Be(invoice.Id);

            result.IsSuccess.Should().Be(true);
            resultFail.IsSuccess.Should().Be(false);
        }
    }
}
