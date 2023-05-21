using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.BL
{
    public class ProductAddDto
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Price { get; set; }
        public string Image { get; set; } = String.Empty;
        public IFormFile File { get; set; }
    }
}
