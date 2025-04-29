// MappingProfile.cs
using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;

namespace Financial_management_system_in_educational_institutions_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Porosite, PorositeDto>()
                .ForMember(dest => dest.ShkollaEmri,
                           opt => opt.MapFrom(src => src.Shkolla.emriShkolles))
                .ForMember(dest => dest.ProduktiEmri,
                           opt => opt.MapFrom(src => src.Produkti.Emri))
                .ForMember(dest => dest.Statusi,
                           opt => opt.MapFrom(src => src.Statusi)); 
        }
    }
}
