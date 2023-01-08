using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.CabinetQueries;

namespace MedHub.Application.Handlers.CabinetHandlers
{
    public class GetAllCabinetsQueryHandler : IRequestHandler<GetAllCabinetsQuery, Response<List<CabinetDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCabinetsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<CabinetDto>>> Handle(GetAllCabinetsQuery request, CancellationToken cancellationToken)
        {
            var cabinets = MedHubMapper.Mapper.Map<List<CabinetDto>>(await unitOfWork.CabinetRepository.GetAllAsync());
            if (cabinets == null)
            {
                return Response<List<CabinetDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Cabinet> to List<CabinetDto>.");
            }

            return Response<List<CabinetDto>>.Create(OperationState.Done, cabinets);
        }
    }
}
