using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetInvoiceByIdQuery : IdDto, IRequest<Response<InvoiceDto>>
    {
        public GetInvoiceByIdQuery(Guid id) : base(id) { }
    }
}
