using GuiaVegana.Data;
using GuiaVegana.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [Route("api/Activismos")]
    [ApiController]
    public class ActivismController : ControllerBase
    {
        private readonly IActivismRepository _activismRepository;
        //ir poniendo cada que necesito el repository de cada entidad.
        private GuiaVeganaContext _context;
        public ActivismController(IActivismRepository activismRepository, GuiaVeganaContext context)
        {
            _activismRepository = activismRepository;
            _context = context;
        }


    }
}
