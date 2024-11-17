using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class ActivismRepository : IActivismRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public ActivismRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
