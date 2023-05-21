using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApplication.BL;
using System.Net;

namespace ProductsApplication.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Manager")]
    public class ProductsController : ControllerBase
    {
        #region Fields & Constructor
        private readonly IProductManager ProductsManager;
        private readonly IWebHostEnvironment environment;

        public ProductsController(IProductManager _ProductsManager , IWebHostEnvironment _environment)
        {
            ProductsManager = _ProductsManager;
            environment = _environment;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<ProductReadDto>> GetAll()
        {
            var Developers = await ProductsManager.GetAll();
            return Ok(Developers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            ProductReadDto Product = await ProductsManager.GetById(id);
            if (Product is null) return NotFound(new CustomResponse(HttpStatusCode.NotFound, "Invalid Product"));
            return Ok(Product);
        }
        [HttpPost]
        public async Task<ActionResult<CustomResponse>> Add([FromForm] ProductAddDto product)
        {
            if (product.File == null || product.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            string fileName = product.File.FileName;
            string filePath = Path.Combine(environment.WebRootPath, "Uploads", "Products", fileName);


            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await product.File.CopyToAsync(stream);
            }
            product.Image = filePath;
            int newId = await ProductsManager.Add(product);
            return CreatedAtAction
                (
                    nameof(GetById),
                    new { id = newId },
                     "New Product Created Successfully"
                );
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromForm] ProductUpdateDto product)
        {
            if (product.File == null || product.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            string fileName = product.File.FileName;
            string filePath = Path.Combine(environment.WebRootPath, "Uploads", "Products", fileName);


            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await product.File.CopyToAsync(stream);
            }
            product.Image = filePath;
            var isUpdated = await ProductsManager.Update(product);
            if (!isUpdated) return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "Invalid Product Details"));
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await ProductsManager.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
