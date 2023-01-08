using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.AllergenCommands
{
    public class DeleteAllergenCommand : IdCommandQuery, IRequest<Response<AllergenDto>>
    {
        public DeleteAllergenCommand(Guid id) : base(id) { }
    }
}
