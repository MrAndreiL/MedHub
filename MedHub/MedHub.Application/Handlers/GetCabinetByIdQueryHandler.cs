using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries;

namespace MedHub.Application.Handlers
{
    public class GetCabinetByIdQueryHandler : IRequestHandler<GetCabinetByIdQuery, Response<CabinetDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCabinetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<CabinetDto>> Handle(GetCabinetByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedCabinet = await unitOfWork.CabinetRepository.FindByIdAsync(request.CabinetId);
            if (searchedCabinet == null)
            {
                return Response<CabinetDto>.Create(OperationState.NotFound);
            }

            var cabinetDto = MedHubMapper.Mapper.Map<CabinetDto>(searchedCabinet);
            if (cabinetDto == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Cabinet to CabinetDto.");
            }

            return Response<CabinetDto>.Create(OperationState.Done, cabinetDto);
        }
    }
}
