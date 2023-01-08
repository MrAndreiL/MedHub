using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.CabinetQueries
{
    public class GetCabinetByIdQuery : IdCommandQuery, IRequest<Response<CabinetDto>>
    {
        public GetCabinetByIdQuery(Guid id): base(id) { }
    }
}
