using Microsoft.AspNetCore.Mvc;

namespace Fitness.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TrainersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
