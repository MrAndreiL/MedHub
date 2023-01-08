using MedHub.Application.Commands.AppointmentCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.AppointmentHandlers
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Response<AppointmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<AppointmentDto>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentEntity = MedHubMapper.Mapper.Map<Appointment>(request);
            if (appointmentEntity == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateAppointmentCommand to Appointment.");
            }

            var createdAppointment = await unitOfWork.AppointmentRepository.AddAsync(appointmentEntity);
            await unitOfWork.SaveChangesAsync();

            var createdAppointmentDto = MedHubMapper.Mapper.Map<AppointmentDto>(createdAppointment);
            if (createdAppointmentDto == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Appointment to AppointmentDto.");
            }

            return Response<AppointmentDto>.Create(OperationState.Done, createdAppointmentDto);
        }
    }
}
