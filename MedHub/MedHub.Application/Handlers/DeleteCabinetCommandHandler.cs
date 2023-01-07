using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class DeleteCabinetCommandHandler : IRequestHandler<DeleteCabinetCommand, Response<CabinetDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCabinetCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<CabinetDto>> Handle(DeleteCabinetCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.CabinetRepository.DeleteAsync(request.CabinetId);
            if (result == null)
            {
                return Response<CabinetDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var cabinetDto = MedHubMapper.Mapper.Map<CabinetDto>(result);
            if (cabinetDto == null)
            {
                return Response<CabinetDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Cabinet to CabinetDto.");
            }

            return Response<CabinetDto>.Create(OperationState.Done, cabinetDto);
        }
    }
}
