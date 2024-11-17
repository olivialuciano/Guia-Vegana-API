using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class ActivismProfile : Profile
    {
        public ActivismProfile() 
        {
            CreateMap<Activism, ActivismDTO>();
            CreateMap<Activism, ActivismToCreateDTO>();
        }
    }
}
