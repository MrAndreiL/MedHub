using AutoMapper;
using MedHub.Application.Commands.MedicalSpecialityCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class MedicalSpecialityMappingProfile : Profile
    {
        public MedicalSpecialityMappingProfile()
        {
            CreateMap<MedicalSpeciality, MedicalSpecialityDto>().ReverseMap();
            CreateMap<MedicalSpeciality, CreateMedicalSpecialityCommand>().ReverseMap();
            CreateMap<MedicalSpeciality, UpdateMedicalSpecialityCommand>().ReverseMap();
        }
    }
}
