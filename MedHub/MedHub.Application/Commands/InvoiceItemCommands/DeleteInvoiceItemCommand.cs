using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.InvoiceItemCommands
{
    public class DeleteInvoiceItemCommand : IdCommandQuery, IRequest<Response<InvoiceItemDto>>
    {
        public DeleteInvoiceItemCommand(Guid id) : base(id) { }
    }
}
