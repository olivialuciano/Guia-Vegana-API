using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile() 
        {
            CreateMap<Business, BusinessDTO>();
            CreateMap<Business, BusinessToCreateDTO>();
        
        }
    }
}
