using MedHub.Application.Response;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteAllergenCommand : IRequest<AllergenResponse>
    {
        public Guid AllergenId { get; }

        public DeleteAllergenCommand(Guid allergenId)
        {
            AllergenId = allergenId;
        }
    }
}
