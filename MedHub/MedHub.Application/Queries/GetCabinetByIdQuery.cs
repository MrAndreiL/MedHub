using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetCabinetByIdQuery : IRequest<Response<CabinetDto>>
    {
        public Guid CabinetId { get; }

        public GetCabinetByIdQuery(Guid cabinetId)
        {
            CabinetId = cabinetId;
        }
    }
}
