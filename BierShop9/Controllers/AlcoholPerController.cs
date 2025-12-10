using Microsoft.AspNetCore.Mvc;

namespace BierShop9.Controllers
{
    public class AlcoholPerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
