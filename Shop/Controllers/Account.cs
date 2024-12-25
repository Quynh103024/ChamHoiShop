using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
