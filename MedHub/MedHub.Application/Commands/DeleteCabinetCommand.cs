using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteCabinetCommand : IRequest<Response<CabinetDto>>
    {
        public Guid CabinetId { get; }

        public DeleteCabinetCommand(Guid cabinetId)
        {
            CabinetId = cabinetId;
        }
    }
}
