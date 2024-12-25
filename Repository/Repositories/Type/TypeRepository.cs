using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class TypeRepository : BaseRepository<Models.Type>, ITypeRepository
    {
        private readonly ChamHoiShopContext _db;
        public TypeRepository(ChamHoiShopContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
