using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.InvoiceCommands
{
    public class CreateInvoiceCommand : IRequest<Response<InvoiceDto>>
    {
        public DateTime IssuedDate { get; set; }
    }
}
