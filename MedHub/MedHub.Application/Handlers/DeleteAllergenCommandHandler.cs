using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class DeleteAllergenCommandHandler : IRequestHandler<DeleteAllergenCommand, Response<AllergenDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteAllergenCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<AllergenDto>> Handle(DeleteAllergenCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.AllergenRepository.DeleteAsync(request.AllergenId);
            if (result == null)
            {
                return Response<AllergenDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var allergenDto = MedHubMapper.Mapper.Map<AllergenDto>(result);
            if (allergenDto == null)
            {
                return Response<AllergenDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Allergen to AllergenDto.");
            }

            return Response<AllergenDto>.Create(OperationState.Done, allergenDto);
        }
    }
}
