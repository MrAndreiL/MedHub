using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteAllergenCommand : IRequest<Response<AllergenDto>>
    {
        public Guid AllergenId { get; }

        public DeleteAllergenCommand(Guid allergenId)
        {
            AllergenId = allergenId;
        }
    }
}
