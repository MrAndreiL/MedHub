using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class DeleteInvoiceItemCommand : IdDto, IRequest<Response<InvoiceItemDto>>
    {
        public DeleteInvoiceItemCommand(Guid id) : base(id) { }
    }
}
