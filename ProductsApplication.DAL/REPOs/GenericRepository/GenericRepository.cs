using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly ProductsApplicationContext context;

        public GenericRepository(ProductsApplicationContext _context)
        {
            context = _context;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            // Only in case you use .AsNoTracking() ====> context.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        #endregion
    }
}
