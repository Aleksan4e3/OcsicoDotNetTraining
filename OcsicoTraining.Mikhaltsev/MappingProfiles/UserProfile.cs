using AutoMapper;
using EntityModels.Identity;
using ViewModels;

namespace MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>();
        }
    }
}
