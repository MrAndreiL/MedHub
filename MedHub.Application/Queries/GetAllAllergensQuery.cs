using MedHub.Application.Response;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllAllergensQuery : IRequest<List<AllergenResponse>>
    {
    }
}
