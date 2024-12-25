using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ChamHoiShopContext _db;
        public ReviewRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
