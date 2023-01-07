using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class UpdateCabinetCommandHandler : IRequestHandler<UpdateCabinetCommand, Response<CabinetDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCabinetCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<CabinetDto>> Handle(UpdateCabinetCommand request, CancellationToken cancellationToken)
        {
            var cabinetEntity = MedHubMapper.Mapper.Map<Cabinet>(request);
            if (cabinetEntity == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateCabinetCommand to Cabinet.");
            }

            var result = await unitOfWork.CabinetRepository.UpdateAsync(cabinetEntity.Id, cabinetEntity);
            if (result == null)
            {
                return Response<CabinetDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var cabinetDto = MedHubMapper.Mapper.Map<CabinetDto>(cabinetEntity);
            if (cabinetDto == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Cabinet to CabinetDto.");
            }

            return Response<CabinetDto>.Create(OperationState.Done, cabinetDto);
        }
    }
}
