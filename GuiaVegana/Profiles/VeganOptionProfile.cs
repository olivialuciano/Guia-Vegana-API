using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class VeganOptionProfile : Profile
    {
        public VeganOptionProfile() 
        {
            CreateMap<VeganOption, VeganOptionDTO>();
            CreateMap<VeganOption, VeganOptionToCreateDTO>();
            
        }
    }
}
