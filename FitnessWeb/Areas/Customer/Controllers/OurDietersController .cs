using Microsoft.AspNetCore.Mvc;

namespace Fitness.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OurDietersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
