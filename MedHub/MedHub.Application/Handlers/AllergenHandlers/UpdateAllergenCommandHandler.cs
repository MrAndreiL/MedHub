using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.AllergenCommands;

namespace MedHub.Application.Handlers.AllergenHandlers
{
    public class UpdateAllergenCommandHandler : IRequestHandler<UpdateAllergenCommand, Response<AllergenDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateAllergenCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<AllergenDto>> Handle(UpdateAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = MedHubMapper.Mapper.Map<Allergen>(request);
            if (allergenEntity == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateAllergenCommand to Allergen.");
            }

            var result = await unitOfWork.AllergenRepository.UpdateAsync(allergenEntity.Id, allergenEntity);
            if (result == null)
            {
                return Response<AllergenDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var allergenDto = MedHubMapper.Mapper.Map<AllergenDto>(allergenEntity);
            if (allergenDto == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Allergen to AllergenDto.");
            }

            return Response<AllergenDto>.Create(OperationState.Done, allergenDto);
        }
    }
}
