using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class HealthProfessionalRepository : IHealthProfessionalRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public HealthProfessionalRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
