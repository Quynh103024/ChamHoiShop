using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ProductTypeRepository : BaseRepository<Models.Type>, IProductTypeRepository
    {
        private readonly ChamHoiShopContext _db;
        public ProductTypeRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
