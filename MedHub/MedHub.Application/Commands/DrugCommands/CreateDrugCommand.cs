using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DrugCommands
{
    public class CreateDrugCommand : CreateProductCommand, IRequest<Response<DrugDto>> { }
}
