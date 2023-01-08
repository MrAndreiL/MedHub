using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;

namespace MedHub.Application.Handlers.ServiceHandlers
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, Response<List<ServiceDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = MedHubMapper.Mapper.Map<List<ServiceDto>>(await unitOfWork.ServiceRepository.GetAllAsync());
            if (services == null)
            {
                return Response<List<ServiceDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Service> to List<ServiceDto>.");
            }

            return Response<List<ServiceDto>>.Create(OperationState.Done, services);
        }
    }
}
