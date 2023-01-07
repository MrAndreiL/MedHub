using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class CreateCabinetCommand : IRequest<Response<CabinetDto>>
    {
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
