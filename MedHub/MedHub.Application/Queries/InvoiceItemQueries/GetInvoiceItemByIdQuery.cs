using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.InvoiceItemQueries
{
    public class GetInvoiceItemByIdQuery : IdCommandQuery, IRequest<Response<InvoiceItemDto>>
    {
        public GetInvoiceItemByIdQuery(Guid id) : base(id) { }
    }
}
