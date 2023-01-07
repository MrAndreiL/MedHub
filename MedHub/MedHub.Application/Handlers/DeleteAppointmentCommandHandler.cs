using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Response<AppointmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<AppointmentDto>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.AppointmentRepository.DeleteAsync(request.AppointmentId);
            if (result == null)
            {
                return Response<AppointmentDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var appointmentDto = MedHubMapper.Mapper.Map<AppointmentDto>(result);
            if (appointmentDto == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Appointment to AppointmentDto.");
            }

            return Response<AppointmentDto>.Create(OperationState.Done, appointmentDto);
        }
    }
}
