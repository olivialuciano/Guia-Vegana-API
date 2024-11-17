using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class OpeningHourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
