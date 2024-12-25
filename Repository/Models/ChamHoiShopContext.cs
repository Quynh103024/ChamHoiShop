using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;

namespace AdminAuthorization.Models
{
    public class ChamHoiShopContext : DbContext
    {
        public ChamHoiShopContext(DbContextOptions<ChamHoiShopContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"), 
                    RoleId = 1,
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    UserID = 1, 
                    TotalPrice = 100,
                    TimeOrder = DateTime.Now.AddDays(-1),
                    Note = "First Order",
                    OrderStatus = true
                }
            );
        }
    }
}
