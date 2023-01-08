using MedHub.Application.Commands.MedicalRecordCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.MedicalRecordHandlers
{
    public class CreateMedicalRecordCommandHandler : IRequestHandler<CreateMedicalRecordCommand, Response<MedicalRecordDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateMedicalRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalRecordDto>> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var medicalRecordEntity = MedHubMapper.Mapper.Map<MedicalRecord>(request);
            if (medicalRecordEntity == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateMedicalRecordCommand to MedicalRecord.");
            }

            var createdMedicalRecord = await unitOfWork.MedicalRecordRepository.AddAsync(medicalRecordEntity);
            await unitOfWork.SaveChangesAsync();

            var createdMedicalRecordDto = MedHubMapper.Mapper.Map<MedicalRecordDto>(createdMedicalRecord);
            if (createdMedicalRecordDto == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalRecord to MedicalRecordDto.");
            }

            return Response<MedicalRecordDto>.Create(OperationState.Done, createdMedicalRecordDto);
        }
    }
}
