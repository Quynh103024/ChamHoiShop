using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> QueryStart();
        IQueryable<TEntity> Get();
        Task<TEntity?> GetByIDAsync<TKey>(TKey id);
        Task<List<TEntity>> GetAllAsync();
        Task<int> GetMaxIdAsync();
        void Update(TEntity entity);
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task SaveAsync();
    }
}
