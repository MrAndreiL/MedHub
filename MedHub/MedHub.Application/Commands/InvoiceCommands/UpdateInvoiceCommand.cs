using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceCommands
{
    public class UpdateInvoiceCommand : IRequest<Response<InvoiceDto>>
    {
        public Guid Id { get; set; }
        public DateTime IssuedDate { get; set; }

        public UpdateInvoiceCommand(CreateInvoiceCommand command, Guid invoiceId)
        {
            Id = invoiceId;
            IssuedDate = command.IssuedDate;
        }
    }
}
