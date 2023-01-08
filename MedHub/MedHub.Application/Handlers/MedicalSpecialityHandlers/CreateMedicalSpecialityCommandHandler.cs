using MedHub.Application.Commands.MedicalSpecialityCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.MedicalSpecialityHandlers
{
    public class CreateMedicalSpecialityCommandHandler : IRequestHandler<CreateMedicalSpecialityCommand, Response<MedicalSpecialityDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateMedicalSpecialityCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalSpecialityDto>> Handle(CreateMedicalSpecialityCommand request, CancellationToken cancellationToken)
        {
            var medicalSpecialityEntity = MedHubMapper.Mapper.Map<MedicalSpeciality>(request);
            if (medicalSpecialityEntity == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateMedicalSpecialityCommand to MedicalSpeciality.");
            }

            var createdMedicalSpeciality = await unitOfWork.MedicalSpecialityRepository.AddAsync(medicalSpecialityEntity);
            await unitOfWork.SaveChangesAsync();

            var createdMedicalSpecialityDto = MedHubMapper.Mapper.Map<MedicalSpecialityDto>(createdMedicalSpeciality);
            if (createdMedicalSpecialityDto == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalSpeciality to MedicalSpecialityDto.");
            }

            return Response<MedicalSpecialityDto>.Create(OperationState.Done, createdMedicalSpecialityDto);
        }
    }
}
