using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.AllergenQueries
{
    public class GetAllergenByIdQuery : IdCommandQuery, IRequest<Response<AllergenDto>>
    {
        public GetAllergenByIdQuery(Guid id) : base(id) { }
    }
}
