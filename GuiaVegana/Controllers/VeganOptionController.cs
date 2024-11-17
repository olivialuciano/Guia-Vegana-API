using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class VeganOptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
