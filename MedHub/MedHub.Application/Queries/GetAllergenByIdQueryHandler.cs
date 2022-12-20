using MedHub.Application.Mappers;
using MedHub.Application.Response;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllergenByIdQueryHandler : IRequestHandler<GetAllergenByIdQuery, AllergenResponse>
    {
        private readonly IRepository<Allergen> repository;

        public GetAllergenByIdQueryHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<AllergenResponse> Handle(GetAllergenByIdQuery request, CancellationToken cancellationToken)
        {
            var result = MedHubMapper.Mapper.Map<AllergenResponse>(await repository.GetByIdAsync(request.AllergenId));
            return result;
        }
    }
}
