using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetServiceByIdQuery : IdDto, IRequest<Response<ServiceDto>>
    {
        public GetServiceByIdQuery(Guid id) : base(id) { }
    }
}
