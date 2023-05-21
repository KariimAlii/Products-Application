using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.DAL
{
    public interface IUnitOfWork
    {
        public IProductRepo productRepo { get; }
        Task<int> SaveChanges();
    }
}
