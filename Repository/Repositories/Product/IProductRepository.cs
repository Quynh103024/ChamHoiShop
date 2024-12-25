﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<int> GetArrangeRate(int productId);
    }
}
