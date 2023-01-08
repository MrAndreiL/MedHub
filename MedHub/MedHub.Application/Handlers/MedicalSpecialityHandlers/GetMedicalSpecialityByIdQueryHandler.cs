using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalSpecialityQueries;

namespace MedHub.Application.Handlers.MedicalSpecialityHandlers
{
    public class GetMedicalSpecialityByIdQueryHandler : IRequestHandler<GetMedicalSpecialityByIdQuery, Response<MedicalSpecialityDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMedicalSpecialityByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalSpecialityDto>> Handle(GetMedicalSpecialityByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedMedicalSpeciality = await unitOfWork.MedicalSpecialityRepository.FindByIdAsync(request.Id);
            if (searchedMedicalSpeciality == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.NotFound);
            }

            var medicalSpecialityDto = MedHubMapper.Mapper.Map<MedicalSpecialityDto>(searchedMedicalSpeciality);
            if (medicalSpecialityDto == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalSpeciality to MedicalSpecialityDto.");
            }

            return Response<MedicalSpecialityDto>.Create(OperationState.Done, medicalSpecialityDto);
        }
    }
}
