using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsApplicationContext context;

        public IProductRepo productRepo { get; }
        public UnitOfWork
        (
            IProductRepo productRepoFromIoc,
            ProductsApplicationContext _context
        )
        {
            productRepo = productRepoFromIoc;
            context = _context;
        }
        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
