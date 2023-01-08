using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.AllergenQueries
{
    public class GetAllAllergensQuery : IRequest<Response<List<AllergenDto>>>
    {
    }
}
