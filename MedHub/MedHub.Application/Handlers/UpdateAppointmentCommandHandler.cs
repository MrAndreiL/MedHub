using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Response<AppointmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<AppointmentDto>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentEntity = MedHubMapper.Mapper.Map<Appointment>(request);
            if (appointmentEntity == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateAppointmentCommand to Appointment.");
            }

            var result = await unitOfWork.AppointmentRepository.UpdateAsync(appointmentEntity.Id, appointmentEntity);
            if (result == null)
            {
                return Response<AppointmentDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var appointmentDto = MedHubMapper.Mapper.Map<AppointmentDto>(appointmentEntity);
            if (appointmentDto == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Appointment to AppointmentDto.");
            }

            return Response<AppointmentDto>.Create(OperationState.Done, appointmentDto);
        }
    }
}
