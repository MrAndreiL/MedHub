using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class CreateInvoiceItemCommand : CreateLineItemCommand, IRequest<Response<InvoiceItemDto>>
    {
        public decimal UnitPrice { get; set; }
    }
}
