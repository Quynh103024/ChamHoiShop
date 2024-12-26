using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System.Linq;

namespace Shop.Controllers
{
    public class AuthController : Controller
    {
        private readonly ChamHoiShopContext _context;

        public AuthController(ChamHoiShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("RoleId", user.RoleId);

            if (user.Role.RoleName == "Admin")
                return RedirectToAction("Index", "AdminDashboard");
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}
