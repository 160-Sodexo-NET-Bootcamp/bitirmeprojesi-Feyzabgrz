using PCP.Entities.Dtos;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Result<CategoryDto>> AddCategory(CategoryDto categoryDto);
        Task<Result<CategoryDto>> UpdateCategory(CategoryDto categoryDto);

        /*Sadece o kişinin eklediği kayıt silinebilmeli*/
        Task<Result<CategoryDto>> Delete(Guid categoryId);
      //  Task<Result<CategoryDto>> Get(Guid categoryId);
        Task<Result<CategoryDto>> GetProductsByCategoryId(Guid categoryId);
        Task<Result<List<CategoryDto>>> GetAllCategories();
    }
}
