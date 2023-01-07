using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Response<DoctorDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<DoctorDto>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.DoctorRepository.DeleteAsync(request.DoctorId);
            if (result == null)
            {
                return Response<DoctorDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var doctorDto = MedHubMapper.Mapper.Map<DoctorDto>(result);
            if (doctorDto == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Doctor to DoctorDto.");
            }

            return Response<DoctorDto>.Create(OperationState.Done, doctorDto);
        }
    }
}
