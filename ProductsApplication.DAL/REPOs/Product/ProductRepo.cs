using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.DAL
{
    public class ProductRepo : GenericRepository<Product> , IProductRepo
    {
        private readonly ProductsApplicationContext context;

        public ProductRepo(ProductsApplicationContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
