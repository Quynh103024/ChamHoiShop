using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories 
{ 
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ChamHoiShopContext _db;
        public OrderDetailRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
