using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {
        private ChamHoiShopContext _db;

        public ProductRepository(ChamHoiShopContext context) : base(context)
        {
            _db = context;
        }

        public async Task<int> GetArrangeRate(int productId)
        {
            var db = GetByIDAsync(productId).Result;
            int arrangeRate = -1;
            if(db != null)
            {
                int rate = 0;
                int total = 0;
                foreach (var item in db.Reviews)
                {
                    if (item.Rating != null)
                    {
                        total++;
                        rate += (int)item.Rating;
                    }
                }
                arrangeRate = (int)rate / total;
            }
            return arrangeRate;
        }

    }
}
