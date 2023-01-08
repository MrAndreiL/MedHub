using AutoMapper;
using MedHub.Application.Commands.DoctorCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
        }
    }
}
