using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.ServiceCommands;

namespace MedHub.Application.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Response<ServiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceEntity = MedHubMapper.Mapper.Map<Service>(request);
            if (serviceEntity == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateServiceCommand to Service.");
            }

            var result = await unitOfWork.ServiceRepository.UpdateAsync(serviceEntity.Id, serviceEntity);
            if (result == null)
            {
                return Response<ServiceDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var serviceDto = MedHubMapper.Mapper.Map<ServiceDto>(serviceEntity);
            if (serviceDto == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Service to ServiceDto.");
            }

            return Response<ServiceDto>.Create(OperationState.Done, serviceDto);
        }
    }
}
