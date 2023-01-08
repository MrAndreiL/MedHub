using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.AllergenCommands
{
    public class UpdateAllergenCommand : IRequest<Response<AllergenDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public UpdateAllergenCommand(CreateAllergenCommand command, Guid allergenId)
        {
            Id = allergenId;
            Name = command.Name;
        }
    }
}
