using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ChamHoiShopContext _db;
        public OrderRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
