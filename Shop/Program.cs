using AdminAuthorization.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ChamHoiShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            SeedDatabase(app);

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        /// <summary>
        /// </summary>
        /// <param name="app">Ứng dụng WebApplication</param>
        private static void SeedDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ChamHoiShopContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { RoleId = 1, RoleName = "Admin" },
                        new Role { RoleId = 2, RoleName = "Manager" },
                        new Role { RoleId = 3, RoleName = "Customer" }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any(u => u.UserName == "admin"))
                {
                    context.Users.Add(new User
                    {
                        UserName = "admin",
                        Password = "Admin@123", 
                        RoleId = 1, 
                        CreatedDate = DateTime.Now
                    });
                }

                if (!context.Users.Any(u => u.UserName == "manager"))
                {
                    context.Users.Add(new User
                    {
                        UserName = "manager",
                        Password = "Manager@123", 
                        RoleId = 2, 
                        CreatedDate = DateTime.Now
                    });
                }

                if (!context.Users.Any(u => u.UserName == "customer"))
                {
                    context.Users.Add(new User
                    {
                        UserName = "customer",
                        Password = "Customer@123", 
                        RoleId = 3, 
                        CreatedDate = DateTime.Now
                    });
                }

                context.SaveChanges();

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                        new Order
                        {
                            UserID = 1, 
                            TotalPrice = 100,
                            TimeOrder = DateTime.Now.AddDays(-1),
                            Note = "First Order",
                            OrderStatus = true
                        },
                        new Order
                        {
                            UserID = 3, 
                            TotalPrice = 200,
                            TimeOrder = DateTime.Now.AddDays(-10),
                            Note = "Second Order",
                            OrderStatus = true
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
