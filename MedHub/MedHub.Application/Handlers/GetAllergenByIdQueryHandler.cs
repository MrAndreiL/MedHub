using MedHub.Application.Mappers;
using MedHub.Application.Queries;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;

namespace MedHub.Application.Handlers
{
    public class GetAllergenByIdQueryHandler : IRequestHandler<GetAllergenByIdQuery, Response<AllergenDto>>
    {
        private readonly IRepository<Allergen> repository;

        public GetAllergenByIdQueryHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<AllergenDto>> Handle(GetAllergenByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedAllergen = await repository.FindFirst(allergen => allergen.Id == request.AllergenId);
            if (searchedAllergen == null)
            {
                return Response<AllergenDto>.Create(OperationState.NotFound);
            }

            var allergenDto = MedHubMapper.Mapper.Map<AllergenDto>(searchedAllergen);
            if (allergenDto == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateAllergenCommand to Allergen.");
            }

            return Response<AllergenDto>.Create(OperationState.Done, allergenDto);
        }
    }
}
