using Microsoft.AspNetCore.Mvc;

namespace Pratice.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
