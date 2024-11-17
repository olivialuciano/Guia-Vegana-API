using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class HealthProfessionalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
