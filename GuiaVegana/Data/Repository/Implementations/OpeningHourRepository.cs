using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class OpeningHourRepository : IOpeningHourRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public OpeningHourRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
