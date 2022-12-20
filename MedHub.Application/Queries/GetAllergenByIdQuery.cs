using MedHub.Application.Response;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllergenByIdQuery : IRequest<AllergenResponse>
    {
        public GetAllergenByIdQuery(Guid allergenId)
        {
            AllergenId = allergenId;
        }

        public Guid AllergenId { get; }
    }
}
