using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DoctorCommands
{
    public class CreateDoctorCommand : CreatePersonCommand, IRequest<Response<DoctorDto>> { }
}
