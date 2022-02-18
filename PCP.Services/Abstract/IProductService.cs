using PCP.Entities.Dtos;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Services.Abstract
{
    public interface IProductService
    {
        Task<Result<ProductDto>> AddProduct(ProductDto productDto);
        Task<Result<ProductDto>> UpdateProduct(ProductDto productDto);
        Task<Result<ProductDto>> Delete(Guid productId);

        Task<Result<List<ProductDto>>> GetAllColor();
        Task<Result<List<ProductDto>>> GetAllBrand();

        Task<Result<ProductDto>> GetProductsByColor(string color);
        Task<Result<ProductDto>> GetProductsByBrand(string brand);

    }
}
