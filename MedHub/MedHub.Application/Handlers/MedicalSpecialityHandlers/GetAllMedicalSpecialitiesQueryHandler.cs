using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalSpecialityQueries;

namespace MedHub.Application.Handlers.MedicalSpecialityHandlers
{
    public class GetAllMedicalSpecialitiesQueryHandler : IRequestHandler<GetAllMedicalSpecialitiesQuery, Response<List<MedicalSpecialityDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllMedicalSpecialitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<MedicalSpecialityDto>>> Handle(GetAllMedicalSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            var medicalSpecialitys = MedHubMapper.Mapper.Map<List<MedicalSpecialityDto>>(await unitOfWork.MedicalSpecialityRepository.GetAllAsync());
            if (medicalSpecialitys == null)
            {
                return Response<List<MedicalSpecialityDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<MedicalSpeciality> to List<MedicalSpecialityDto>.");
            }

            return Response<List<MedicalSpecialityDto>>.Create(OperationState.Done, medicalSpecialitys);
        }
    }
}
