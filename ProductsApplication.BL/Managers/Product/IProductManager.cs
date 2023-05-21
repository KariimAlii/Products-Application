using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.BL
{
    public interface IProductManager
    {
        Task<IEnumerable<ProductReadDto>> GetAll();
        Task<ProductReadDto> GetById(int id);
        Task<int> Add(ProductAddDto productDto);
        Task<bool> Update(ProductUpdateDto productDto);
        Task Delete(int id);
    }
}
