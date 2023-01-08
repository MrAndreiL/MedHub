using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.DoctorCommands;

namespace MedHub.Application.Handlers.DoctorHandlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Response<DoctorDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DoctorDto>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctorEntity = MedHubMapper.Mapper.Map<Doctor>(request);
            if (doctorEntity == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateDoctorCommand to Doctor.");
            }

            var result = await unitOfWork.DoctorRepository.UpdateAsync(doctorEntity.Id, doctorEntity);
            if (result == null)
            {
                return Response<DoctorDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var doctorDto = MedHubMapper.Mapper.Map<DoctorDto>(doctorEntity);
            if (doctorDto == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Doctor to DoctorDto.");
            }

            return Response<DoctorDto>.Create(OperationState.Done, doctorDto);
        }
    }
}
