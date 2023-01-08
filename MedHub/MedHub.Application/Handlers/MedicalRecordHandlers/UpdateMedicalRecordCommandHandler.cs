using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.MedicalRecordCommands;

namespace MedHub.Application.Handlers.MedicalRecordHandlers
{
    public class UpdateMedicalRecordCommandHandler : IRequestHandler<UpdateMedicalRecordCommand, Response<MedicalRecordDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateMedicalRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalRecordDto>> Handle(UpdateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var medicalRecordEntity = MedHubMapper.Mapper.Map<MedicalRecord>(request);
            if (medicalRecordEntity == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateMedicalRecordCommand to MedicalRecord.");
            }

            var result = await unitOfWork.MedicalRecordRepository.UpdateAsync(medicalRecordEntity.Id, medicalRecordEntity);
            if (result == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var medicalRecordDto = MedHubMapper.Mapper.Map<MedicalRecordDto>(medicalRecordEntity);
            if (medicalRecordDto == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalRecord to MedicalRecordDto.");
            }

            return Response<MedicalRecordDto>.Create(OperationState.Done, medicalRecordDto);
        }
    }
}
