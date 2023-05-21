using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.DAL
{
    public class ProductsApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products => Set<Product>();
        public ProductsApplicationContext(DbContextOptions<ProductsApplicationContext> options) : base(options)
        {
               
        }
    }
}
