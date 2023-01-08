using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.MedicalSpecialityCommands;

namespace MedHub.Application.Handlers.MedicalSpecialityHandlers
{
    public class UpdateMedicalSpecialityCommandHandler : IRequestHandler<UpdateMedicalSpecialityCommand, Response<MedicalSpecialityDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateMedicalSpecialityCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalSpecialityDto>> Handle(UpdateMedicalSpecialityCommand request, CancellationToken cancellationToken)
        {
            var medicalSpecialityEntity = MedHubMapper.Mapper.Map<MedicalSpeciality>(request);
            if (medicalSpecialityEntity == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateMedicalSpecialityCommand to MedicalSpeciality.");
            }

            var result = await unitOfWork.MedicalSpecialityRepository.UpdateAsync(medicalSpecialityEntity.Id, medicalSpecialityEntity);
            if (result == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var medicalSpecialityDto = MedHubMapper.Mapper.Map<MedicalSpecialityDto>(medicalSpecialityEntity);
            if (medicalSpecialityDto == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalSpeciality to MedicalSpecialityDto.");
            }

            return Response<MedicalSpecialityDto>.Create(OperationState.Done, medicalSpecialityDto);
        }
    }
}
