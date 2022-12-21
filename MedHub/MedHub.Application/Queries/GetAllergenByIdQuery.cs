using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllergenByIdQuery : IRequest<Response<AllergenDto>>
    {
        public Guid AllergenId { get; }

        public GetAllergenByIdQuery(Guid allergenId)
        {
            AllergenId = allergenId;
        }
    }
}
