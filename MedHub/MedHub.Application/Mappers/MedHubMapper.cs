using AutoMapper;

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
                cfg.AddProfile<DrugMappingProfile>();
                cfg.AddProfile<InvoiceMappingProfile>();
                cfg.AddProfile<InvoiceItemMappingProfile>();
                cfg.AddProfile<MedicalRecordMappingProfile>();
                cfg.AddProfile<MedicalSpecialityMappingProfile>();
                cfg.AddProfile<PatientMappingProfile>();
                cfg.AddProfile<ServiceMappingProfile>();
                cfg.AddProfile<StockItemMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;

        protected MedHubMapper() { }
    }
}
