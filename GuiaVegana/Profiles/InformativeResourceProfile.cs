using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class InformativeResourceProfile : Profile
    {
        public InformativeResourceProfile() 
        {
            CreateMap<InformativeResource, InformativeResourceDTO>();
            CreateMap<InformativeResource, InformativeResourceToCreateDTO>();
            
        }
    }
}
