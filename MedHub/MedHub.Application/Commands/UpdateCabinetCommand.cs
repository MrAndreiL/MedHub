using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class UpdateCabinetCommand : IRequest<Response<CabinetDto>>
    {
        public Guid Id { get; private set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public UpdateCabinetCommand(CreateCabinetCommand command, Guid cabinetId)
        {
            Id = cabinetId;
            Address = command.Address;
            PhoneNumber = command.PhoneNumber;
        }
    }
}
