using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries;

namespace MedHub.Application.Handlers
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Response<DoctorDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDoctorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DoctorDto>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedDoctor = await unitOfWork.DoctorRepository.FindByIdAsync(request.DoctorId);
            if (searchedDoctor == null)
            {
                return Response<DoctorDto>.Create(OperationState.NotFound);
            }

            var doctorDto = MedHubMapper.Mapper.Map<DoctorDto>(searchedDoctor);
            if (doctorDto == null)
            {
                return Response<DoctorDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Doctor to DoctorDto.");
            }

            return Response<DoctorDto>.Create(OperationState.Done, doctorDto);
        }
    }
}
