using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.AllergenCommands
{
    public class DeleteAllergenCommand : IdDto, IRequest<Response<AllergenDto>>
    {
        public DeleteAllergenCommand(Guid id) : base(id) { }
    }
}
