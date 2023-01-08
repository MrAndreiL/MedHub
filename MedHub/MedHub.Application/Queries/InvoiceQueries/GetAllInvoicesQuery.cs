using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetAllInvoicesQuery : IRequest<Response<List<InvoiceDto>>>
    {
    }
}
