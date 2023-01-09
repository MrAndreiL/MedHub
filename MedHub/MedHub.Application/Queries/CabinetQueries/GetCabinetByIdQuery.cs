using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.CabinetQueries
{
    public class GetCabinetByIdQuery : IdDto, IRequest<Response<CabinetDto>>
    {
        public GetCabinetByIdQuery(Guid id): base(id) { }
    }
}
