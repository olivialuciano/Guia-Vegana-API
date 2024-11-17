using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserToCreateDTO>();

        }
    }
}
