using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class UpdateInvoiceItemCommand : IRequest<Response<InvoiceItemDto>>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public UpdateInvoiceItemCommand(CreateInvoiceItemCommand command, Guid invoiceId)
        {
            Id = invoiceId;
            Quantity = command.Quantity;
            UnitPrice = command.UnitPrice;
        }
    }
}
