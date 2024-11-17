using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class InformativeResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
