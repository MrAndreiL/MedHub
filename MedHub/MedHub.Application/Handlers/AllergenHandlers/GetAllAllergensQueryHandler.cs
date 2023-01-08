using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.AllergenQueries;

namespace MedHub.Application.Handlers.AllergenHandlers
{
    public class GetAllAllergensQueryHandler : IRequestHandler<GetAllAllergensQuery, Response<List<AllergenDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllAllergensQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<AllergenDto>>> Handle(GetAllAllergensQuery request, CancellationToken cancellationToken)
        {
            var allergens = MedHubMapper.Mapper.Map<List<AllergenDto>>(await unitOfWork.AllergenRepository.GetAllAsync());
            if (allergens == null)
            {
                return Response<List<AllergenDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Allergen> to List<AllergenDto>.");
            }

            return Response<List<AllergenDto>>.Create(OperationState.Done, allergens);
        }
    }
}
