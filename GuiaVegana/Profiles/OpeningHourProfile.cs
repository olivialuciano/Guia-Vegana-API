using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class OpeningHourProfile : Profile
    {
        public OpeningHourProfile() 
        {
            CreateMap<OpeningHour, OpeningHourDTO>();
            CreateMap<OpeningHour, OpeningHourToCreateDTO>();
            
        }
    }
}
