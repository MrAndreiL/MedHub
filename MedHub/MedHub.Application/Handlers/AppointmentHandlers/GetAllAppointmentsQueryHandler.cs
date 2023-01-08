using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Application.Queries.AppointmentQueries;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.AppointmentHandlers
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, Response<List<AppointmentDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllAppointmentsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<List<AppointmentDto>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = MedHubMapper.Mapper.Map<List<AppointmentDto>>(await unitOfWork.AppointmentRepository.GetAllAsync());
            if (appointments == null)
            {
                return Response<List<AppointmentDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Appointment> to List<AppointmentDto>.");
            }

            return Response<List<AppointmentDto>>.Create(OperationState.Done, appointments);
        }
    }
}
