using MedHub.Application.Commands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers
{
    public class CreateAllergenCommandHandler : IRequestHandler<CreateAllergenCommand, Response<AllergenDto>>
    {
        private readonly IRepository<Allergen> repository;

        public CreateAllergenCommandHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<AllergenDto>> Handle(CreateAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = MedHubMapper.Mapper.Map<Allergen>(request);
            if (allergenEntity == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateAllergenCommand to Allergen.");
            }

            var createdAllergen = await repository.AddAsync(allergenEntity);
            await repository.SaveChangesAsync();

            var createdAllergenDto = MedHubMapper.Mapper.Map<AllergenDto>(createdAllergen);
            if (createdAllergenDto == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Allergen to AllergenDto.");
            }

            return Response<AllergenDto>.Create(OperationState.Done, createdAllergenDto);
        }
    }
}
