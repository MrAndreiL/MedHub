using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.PatientCommands
{
    public class CreatePatientCommand : CreatePersonCommand, IRequest<Response<PatientDto>> { }
}
