using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.AllergenQueries
{
    public class GetAllergenByIdQuery : IdDto, IRequest<Response<AllergenDto>>
    {
        public GetAllergenByIdQuery(Guid id) : base(id) { }
    }
}
