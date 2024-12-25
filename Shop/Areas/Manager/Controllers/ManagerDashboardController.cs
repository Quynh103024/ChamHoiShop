using AdminAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;   

namespace Shop.Controllers
{
    public class ManagerDashboardController : Controller
    {
        private readonly ChamHoiShopContext _context;

        public ManagerDashboardController(ChamHoiShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Kiểm tra vai trò Manager
            var userName = HttpContext.Session.GetString("UserName");
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserName == userName);

            if (user == null || user.Role.RoleName != "Manager")
            {
                return Unauthorized();
            }

            // Hiển thị danh sách đơn hàng
            var orders = _context.Orders.Include(o => o.User).ToList();
            return View(orders);
        }
    }
}
