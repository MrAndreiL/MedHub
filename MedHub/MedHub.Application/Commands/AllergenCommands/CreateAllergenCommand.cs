using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.AllergenCommands
{
    public class CreateAllergenCommand : IRequest<Response<AllergenDto>>
    {
        public string Name { get; set; } = null!;
    }
}
