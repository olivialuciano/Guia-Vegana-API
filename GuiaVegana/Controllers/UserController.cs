using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
