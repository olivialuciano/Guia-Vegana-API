using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class VeganOptionRepository : IVeganOptionRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public VeganOptionRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
