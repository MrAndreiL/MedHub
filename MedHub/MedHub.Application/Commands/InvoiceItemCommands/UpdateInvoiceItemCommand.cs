using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class UpdateInvoiceItemCommand : UpdateLineItemCommand, IRequest<Response<InvoiceItemDto>>
    {
        public decimal UnitPrice { get; set; }

        public UpdateInvoiceItemCommand(CreateInvoiceItemCommand command, Guid invoiceItemId)
        {
            Id = invoiceItemId;
            Quantity = command.Quantity;
            UnitPrice = command.UnitPrice;
        }
    }
}
