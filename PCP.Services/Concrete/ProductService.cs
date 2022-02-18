using AutoMapper;
using PCP.Data.Concrete.UnitOfWork;
using PCP.Entities.Concrete;
using PCP.Entities.Dtos;
using PCP.Services.Abstract;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ProductDto>> AddProduct(ProductDto productDto)
        {
            Result<ProductDto> result = new Result<ProductDto>();
            var product = _mapper.Map<Product>(productDto);
            //category.CreatedByName = createdByName;
            //category.ModifiedByName = createdByName;
            var addedProduct = await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            result.Success = true;
            result.Data = _mapper.Map<ProductDto>(addedProduct);
            return result;
        }

        public Task<Result<ProductDto>> Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ProductDto>>> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ProductDto>>> GetAllColor()
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDto>> GetProductsByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDto>> GetProductsByColor(string color)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
