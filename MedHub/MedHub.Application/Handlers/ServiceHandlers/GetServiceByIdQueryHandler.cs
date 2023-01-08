using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;

namespace MedHub.Application.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Response<ServiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedService = await unitOfWork.ServiceRepository.FindByIdAsync(request.Id);
            if (searchedService == null)
            {
                return Response<ServiceDto>.Create(OperationState.NotFound);
            }

            var serviceDto = MedHubMapper.Mapper.Map<ServiceDto>(searchedService);
            if (serviceDto == null)
            {
                return Response<ServiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Service to ServiceDto.");
            }

            return Response<ServiceDto>.Create(OperationState.Done, serviceDto);
        }
    }
}
