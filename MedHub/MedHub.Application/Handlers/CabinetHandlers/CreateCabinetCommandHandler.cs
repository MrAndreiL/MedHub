using MedHub.Application.Commands.CabinetCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.CabinetHandlers
{
    public class CreateCabinetCommandHandler : IRequestHandler<CreateCabinetCommand, Response<CabinetDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCabinetCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<CabinetDto>> Handle(CreateCabinetCommand request, CancellationToken cancellationToken)
        {
            var cabinetEntity = MedHubMapper.Mapper.Map<Cabinet>(request);
            if (cabinetEntity == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateCabinetCommand to Cabinet.");
            }

            var createdCabinet = await unitOfWork.CabinetRepository.AddAsync(cabinetEntity);
            await unitOfWork.SaveChangesAsync();

            var createdCabinetDto = MedHubMapper.Mapper.Map<CabinetDto>(createdCabinet);
            if (createdCabinetDto == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Cabinet to CabinetDto.");
            }

            return Response<CabinetDto>.Create(OperationState.Done, createdCabinetDto);
        }
    }
}
