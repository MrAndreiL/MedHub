using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.MedicalSpecialityCommands;

namespace MedHub.Application.Handlers.MedicalSpecialityHandlers
{
    public class DeleteMedicalSpecialityCommandHandler : IRequestHandler<DeleteMedicalSpecialityCommand, Response<MedicalSpecialityDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteMedicalSpecialityCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<MedicalSpecialityDto>> Handle(DeleteMedicalSpecialityCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.MedicalSpecialityRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var MedicalSpecialityDto = MedHubMapper.Mapper.Map<MedicalSpecialityDto>(result);
            if (MedicalSpecialityDto == null)
            {
                return Response<MedicalSpecialityDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalSpeciality to MedicalSpecialityDto.");
            }

            return Response<MedicalSpecialityDto>.Create(OperationState.Done, MedicalSpecialityDto);
        }
    }
}
