using AutoMapper;
using ProductsApplication.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.BL
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductManager(IUnitOfWork _unitOfWork , IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAll()
        {
            var ProductsFromDB = await unitOfWork.productRepo.GetAll();
            return mapper.Map<List<ProductReadDto>>(ProductsFromDB);
        }

        public async Task<ProductReadDto> GetById(int id)
        {
            var ProductFromDB = await unitOfWork.productRepo.GetById(id);
            if (ProductFromDB == null)
                return null;

            return mapper.Map<ProductReadDto>(ProductFromDB);
        }
        public async Task<int> Add(ProductAddDto productDto)
        {

            var newproduct = mapper.Map<Product>(productDto);
            await unitOfWork.productRepo.Add(newproduct);
            await unitOfWork.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            return newproduct.Id;
        }

        public async Task<bool> Update(ProductUpdateDto productDto)
        {
            var ProductFromDB = await unitOfWork.productRepo.GetById(productDto.Id);
            if (ProductFromDB == null)
                return false;

            ProductFromDB.Name = productDto.Name;
            ProductFromDB.Description = productDto.Description;
            ProductFromDB.Price = productDto.Price;
            ProductFromDB.Image = productDto.Image;


            unitOfWork.productRepo.Update(ProductFromDB);

            await unitOfWork.SaveChanges();
            return true;
        }
        public async Task Delete(int id)
        {
            var ProductFromDB = await unitOfWork.productRepo.GetById(id);
            if (ProductFromDB == null)
                return;
            System.IO.File.Delete(ProductFromDB.Image);
            unitOfWork.productRepo.Delete(ProductFromDB);
            await unitOfWork.SaveChanges();
        }
    }
}
