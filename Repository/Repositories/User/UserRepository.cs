using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private readonly ChamHoiShopContext _db;

        public UserRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        private DateTime GetVietNamTime()
        {
            var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
        }

        public async Task<User?> GetLoginAsync(string username, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
        
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public void Update(User entity)
        {
            _db.Users.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SavePasswordResetTokenAsync(string email, string token)
        {
            var user = await FindByEmailAsync(email);
            if (user != null)
            {
                user.ResetToken = token;
                user.ResetTokenExpires = GetVietNamTime().AddHours(1);
                _db.Users.Update(user);
                SaveAsync();
            }
        }

        public async Task<User?> GetUserByResetTokenAsync(string token)
        {
            var currentTime = GetVietNamTime();
            return await _db.Users.FirstOrDefaultAsync(u => u.ResetToken == token && u.ResetTokenExpires > currentTime);
        }

        public async Task<bool> ResetPasswordAsync(string token, string email, string newPassword)
        {
            var user = GetUserByResetTokenAsync(token).Result;
            if(user != null)
            {
                user.Password = newPassword;
                user.ResetToken = null;
                user.ResetTokenExpires = null;
                _db.Users.Update(user);
                SaveAsync();
                return true;
            }
            return false;
        }
    }
}
