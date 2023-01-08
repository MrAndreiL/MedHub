using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetServiceByIdQuery : IdCommandQuery, IRequest<Response<ServiceDto>>
    {
        public GetServiceByIdQuery(Guid id) : base(id) { }
    }
}
