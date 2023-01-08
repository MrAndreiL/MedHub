using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetAllServicesQuery : IRequest<Response<List<ServiceDto>>>
    {
    }
}
