using AutoMapper;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Profiles
{
    public class HealthProfessionalProfile : Profile
    {
        public HealthProfessionalProfile()
        {
            CreateMap<HealthProfessional, HealthProfessionalDTO>();
            CreateMap<HealthProfessional, HealthProfessionalToCreateDTO>();
        }
    }
}
