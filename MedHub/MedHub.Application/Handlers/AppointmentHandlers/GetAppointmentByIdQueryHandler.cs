using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.AppointmentQueries;

namespace MedHub.Application.Handlers.AppointmentHandlers
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Response<AppointmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAppointmentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<AppointmentDto>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedAppointment = await unitOfWork.AppointmentRepository.FindByIdAsync(request.Id);
            if (searchedAppointment == null)
            {
                return Response<AppointmentDto>.Create(OperationState.NotFound);
            }

            var appointmentDto = MedHubMapper.Mapper.Map<AppointmentDto>(searchedAppointment);
            if (appointmentDto == null)
            {
                return Response<AppointmentDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Appointment to AppointmentDto.");
            }

            return Response<AppointmentDto>.Create(OperationState.Done, appointmentDto);
        }
    }
}
