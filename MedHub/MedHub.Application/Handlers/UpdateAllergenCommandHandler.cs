using MedHub.Application.Commands;
using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;

namespace MedHub.Application.Handlers
{
    public class UpdateAllergenCommandHandler : IRequestHandler<UpdateAllergenCommand, Response<AllergenDto>>
    {
        private readonly IRepository<Allergen> repository;

        public UpdateAllergenCommandHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<AllergenDto>> Handle(UpdateAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = await repository.FindFirst(allergen => allergen.Id == request.Id);
            if (allergenEntity == null)
            {
                return Response<AllergenDto>.Create(OperationState.NotFound);
            }

            allergenEntity = MedHubMapper.Mapper.Map<Allergen>(request);
            if (allergenEntity == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateAllergenCommand to Allergen.");
            }

            repository.Update(allergenEntity);
            await repository.SaveChangesAsync();

            var allergenDto = MedHubMapper.Mapper.Map<AllergenDto>(allergenEntity);
            if (allergenDto == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Allergen to AllergenDto.");
            }

            return Response<AllergenDto>.Create(OperationState.Done, allergenDto);
        }
    }
}
