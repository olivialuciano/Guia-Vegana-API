using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
