using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries;

namespace MedHub.Application.Handlers
{
    public class GetAllergenByIdQueryHandler : IRequestHandler<GetAllergenByIdQuery, Response<AllergenDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllergenByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<AllergenDto>> Handle(GetAllergenByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedAllergen = await unitOfWork.AllergenRepository.FindByIdAsync(request.AllergenId);
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
