using AutoMapper;
using MedHub.Application.Commands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentCommand>().ReverseMap();
        }
    }
}
