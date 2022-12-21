using MedHub.Application.Mappers;
using MedHub.Application.Queries;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;

namespace MedHub.Application.Handlers
{
    public class GetAllAllergensQueryHandler : IRequestHandler<GetAllAllergensQuery, Response<List<AllergenDto>>>
    {
        private readonly IRepository<Allergen> repository;

        public GetAllAllergensQueryHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<List<AllergenDto>>> Handle(GetAllAllergensQuery request, CancellationToken cancellationToken)
        {
            var allergens = MedHubMapper.Mapper.Map<List<AllergenDto>>(await repository.GetAllAsync());
            if (allergens == null)
            {
                return Response<List<AllergenDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Allergen> to List<AllergenDto>.");
            }

            return Response<List<AllergenDto>>.Create(OperationState.Done, allergens);
        }
    }
}
