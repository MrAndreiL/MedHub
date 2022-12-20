using MedHub.Application.Mappers;
using MedHub.Application.Response;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllAllergensQueryHandler : IRequestHandler<GetAllAllergensQuery, List<AllergenResponse>>
    {
        private readonly IRepository<Allergen> repository;

        public GetAllAllergensQueryHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<List<AllergenResponse>> Handle(GetAllAllergensQuery request, CancellationToken cancellationToken)
        {
            return MedHubMapper.Mapper.Map<List<AllergenResponse>>(await repository.GetAllAsync());
        }
    }
}
