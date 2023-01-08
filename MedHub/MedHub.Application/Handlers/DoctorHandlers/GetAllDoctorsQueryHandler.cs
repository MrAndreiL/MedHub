using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.DoctorQueries;

namespace MedHub.Application.Handlers.DoctorHandlers
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, Response<List<DoctorDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<DoctorDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = MedHubMapper.Mapper.Map<List<DoctorDto>>(await unitOfWork.DoctorRepository.GetAllAsync());
            if (doctors == null)
            {
                return Response<List<DoctorDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Doctor> to List<DoctorDto>.");
            }

            return Response<List<DoctorDto>>.Create(OperationState.Done, doctors);
        }
    }
}
