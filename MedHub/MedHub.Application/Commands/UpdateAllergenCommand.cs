using MedHub.Application.Response;
using MediatR;

namespace MedHub.Application.Commands
{
    public class UpdateAllergenCommand : IRequest<AllergenResponse>
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
