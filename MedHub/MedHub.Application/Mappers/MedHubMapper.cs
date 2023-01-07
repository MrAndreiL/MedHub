using AutoMapper;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class MedHubMapper
    {
        private static Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod != null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
                cfg.AddProfile<AllergenMappingProfile>();
                cfg.AddProfile<AppointmentMappingProfile>();
                cfg.AddProfile<CabinetMappingProfile>();
                cfg.AddProfile<DoctorMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;

        protected MedHubMapper() { }
    }
}
