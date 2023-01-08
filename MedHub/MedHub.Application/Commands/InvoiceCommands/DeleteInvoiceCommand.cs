using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.InvoiceCommands
{
    public class DeleteInvoiceCommand : IdCommandQuery, IRequest<Response<InvoiceDto>>
    {
        public DeleteInvoiceCommand(Guid id) : base(id) { }
    }
}
