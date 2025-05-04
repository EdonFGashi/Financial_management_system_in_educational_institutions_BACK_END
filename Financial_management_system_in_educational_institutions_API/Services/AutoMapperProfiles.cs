using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Financial_management_system_in_educational_institutions_API.DTOs;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IdentityUser, RegisterUserCredentials>();

            CreateMap<IdentityUser, UsersDTO>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
