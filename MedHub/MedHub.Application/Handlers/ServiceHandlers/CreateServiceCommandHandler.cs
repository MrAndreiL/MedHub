using MedHub.Application.Commands.ServiceCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Response<ServiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceEntity = MedHubMapper.Mapper.Map<Service>(request);
            if (serviceEntity == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateServiceCommand to Service.");
            }

            var createdService = await unitOfWork.ServiceRepository.AddAsync(serviceEntity);
            await unitOfWork.SaveChangesAsync();

            var createdServiceDto = MedHubMapper.Mapper.Map<ServiceDto>(createdService);
            if (createdServiceDto == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Service to ServiceDto.");
            }

            return Response<ServiceDto>.Create(OperationState.Done, createdServiceDto);
        }
    }
}
