using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceCommands
{
    public class DeleteInvoiceCommand : IdDto, IRequest<Response<InvoiceDto>>
    {
        public DeleteInvoiceCommand(Guid id) : base(id) { }
    }
}
