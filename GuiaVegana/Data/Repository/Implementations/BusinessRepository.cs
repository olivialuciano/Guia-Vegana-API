using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class BusinessRepository : IBusinessRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public BusinessRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
