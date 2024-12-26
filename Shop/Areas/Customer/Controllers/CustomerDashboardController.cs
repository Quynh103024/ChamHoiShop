using AdminAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace Shop.Controllers
{
    public class CustomerDashboardController : Controller
    {
        private readonly ChamHoiShopContext _context;

        public CustomerDashboardController(ChamHoiShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy thông tin người dùng hiện tại
            var userName = HttpContext.Session.GetString("UserName");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null || user.Role.RoleName != "Customer")
            {
                return Unauthorized();
            }

            // Hiển thị danh sách đơn hàng của người dùng
            var orders = _context.Orders.Where(o => o.UserID == user.UserId).ToList();
            return View(orders);
        }
    }
}
