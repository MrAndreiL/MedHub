using AutoMapper;
using MedHub.Application.Commands.DrugCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class DrugMappingProfile : Profile
    {
        public DrugMappingProfile()
        {
            CreateMap<Drug, DrugDto>().ReverseMap();
            CreateMap<Drug, CreateDrugCommand>().ReverseMap();
            CreateMap<Drug, UpdateDrugCommand>().ReverseMap();
        }
    }
}
