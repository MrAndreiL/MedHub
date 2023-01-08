using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceItemQueries
{
    public class GetAllInvoiceItemsQuery : IRequest<Response<List<InvoiceItemDto>>>
    {
    }
}
