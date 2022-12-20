using MedHub.Application.Response;
using MediatR;

namespace MedHub.Application.Commands
{
    public class CreateAllergenCommand : IRequest<AllergenResponse>
    {
        public string Name { get; set; }
    }
}
