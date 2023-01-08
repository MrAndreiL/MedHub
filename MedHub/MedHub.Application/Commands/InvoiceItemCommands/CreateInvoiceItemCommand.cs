using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class CreateInvoiceItemCommand : IRequest<Response<InvoiceItemDto>>
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
