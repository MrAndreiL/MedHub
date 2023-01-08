using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetInvoiceByIdQuery : IdCommandQuery, IRequest<Response<InvoiceDto>>
    {
        public GetInvoiceByIdQuery(Guid id) : base(id) { }
    }
}
