using MedHub.Application.Commands.DoctorCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.DoctorHandlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Response<DoctorDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DoctorDto>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctorEntity = MedHubMapper.Mapper.Map<Doctor>(request);
            if (doctorEntity == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateDoctorCommand to Doctor.");
            }

            var createdDoctor = await unitOfWork.DoctorRepository.AddAsync(doctorEntity);
            await unitOfWork.SaveChangesAsync();

            var createdDoctorDto = MedHubMapper.Mapper.Map<DoctorDto>(createdDoctor);
            if (createdDoctorDto == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Doctor to DoctorDto.");
            }

            return Response<DoctorDto>.Create(OperationState.Done, createdDoctorDto);
        }
    }
}
