using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ChamHoiShopContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ChamHoiShopContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> QueryStart()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public async Task<TEntity?> GetByIDAsync<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> GetMaxIdAsync()
        {
            if (await _dbSet.AnyAsync())
            {
                var maxId = await _dbSet.MaxAsync(u => EF.Property<int>(u, "ID"));
                return maxId;
            }
            return 0;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }


        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
