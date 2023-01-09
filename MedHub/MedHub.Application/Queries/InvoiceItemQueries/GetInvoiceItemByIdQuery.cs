using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceItemQueries
{
    public class GetInvoiceItemByIdQuery : IdDto, IRequest<Response<InvoiceItemDto>>
    {
        public GetInvoiceItemByIdQuery(Guid id) : base(id) { }
    }
}
