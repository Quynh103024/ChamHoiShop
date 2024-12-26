using Microsoft.AspNetCore.Mvc;
using AdminAuthorization.Models;
namespace Repository.Models


namespace AdminAuthorization.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ChamHoiShopContext _context;

        public AdminDashboardController(ChamHoiShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Kiểm tra quyền Admin
            var userName = HttpContext.Session.GetString("UserName");
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.UserName == userName);

            if (user == null || user.Role.RoleName != "Admin")
            {
                return Unauthorized(); // Nếu không phải Admin, trả về lỗi 401
            }

            // Truyền dữ liệu mẫu cho View
            ViewBag.TotalUsers = _context.Users.Count();
            ViewBag.AdminUsers = _context.Users.Count(u => u.Role.RoleName == "Admin");

            return View();
        }
    }
}
