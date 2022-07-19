using AutoMapper;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;

namespace BabysitterfyApp.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateBabySitterDTO, BabySitter>();
            CreateMap<UpdateBabySitterDTO, BabySitter>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
