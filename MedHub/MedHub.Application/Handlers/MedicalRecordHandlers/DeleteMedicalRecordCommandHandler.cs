using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.MedicalRecordCommands;

namespace MedHub.Application.Handlers.MedicalRecordHandlers
{
    public class DeleteMedicalRecordCommandHandler : IRequestHandler<DeleteMedicalRecordCommand, Response<MedicalRecordDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteMedicalRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<MedicalRecordDto>> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.MedicalRecordRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var MedicalRecordDto = MedHubMapper.Mapper.Map<MedicalRecordDto>(result);
            if (MedicalRecordDto == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalRecord to MedicalRecordDto.");
            }

            return Response<MedicalRecordDto>.Create(OperationState.Done, MedicalRecordDto);
        }
    }
}
