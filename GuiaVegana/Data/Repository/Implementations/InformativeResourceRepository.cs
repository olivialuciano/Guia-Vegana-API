using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class InformativeResourceRepository : IInformativeResourceRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public InformativeResourceRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
