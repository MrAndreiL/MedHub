using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.ServiceCommands;

namespace MedHub.Application.Handlers.ServiceHandlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Response<ServiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<ServiceDto>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.ServiceRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<ServiceDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var serviceDto = MedHubMapper.Mapper.Map<ServiceDto>(result);
            if (serviceDto == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Service to ServiceDto.");
            }

            return Response<ServiceDto>.Create(OperationState.Done, serviceDto);
        }
    }
}
