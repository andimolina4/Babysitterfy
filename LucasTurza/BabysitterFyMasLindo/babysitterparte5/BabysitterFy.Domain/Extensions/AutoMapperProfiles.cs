using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;

namespace BabysitterFy.Domain.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDTO, AppUser>();
            CreateMap<RegisterDTO, Babysitter>();
            CreateMap<Babysitter, BabysitterDTO>();
            CreateMap<AppUser, UserDTO>();
        }
    }
}
