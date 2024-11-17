using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public UserRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
