using AutoMapper;
using MedHub.Application.Commands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class CabinetMappingProfile : Profile
    {
        public CabinetMappingProfile()
        {
            CreateMap<Cabinet, CabinetDto>().ReverseMap();
            CreateMap<Cabinet, CreateCabinetCommand>().ReverseMap();
            CreateMap<Cabinet, UpdateCabinetCommand>().ReverseMap();
        }
    }
}
