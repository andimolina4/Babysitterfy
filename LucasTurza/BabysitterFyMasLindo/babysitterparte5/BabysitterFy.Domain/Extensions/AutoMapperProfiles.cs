using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;

namespace BabysitterFy.Domain.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BabysitterRegisterDTO, AppUser>();
            CreateMap<BabysitterRegisterDTO, Babysitter>();
            CreateMap<Babysitter, BabysitterDTO>();
            CreateMap<AppUser, UserDTO>();

            CreateMap<ParentRegisterDTO, AppUser>();
            CreateMap<ParentRegisterDTO, Parent>();
            CreateMap<Parent, ParentDTO>();
        }
    }
}
