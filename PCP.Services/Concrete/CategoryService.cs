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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Adding new Category*/
        public async Task<Result<CategoryDto>> AddCategory(CategoryDto categoryDto)
        {
            Result<CategoryDto> result = new Result<CategoryDto>();
            var category = _mapper.Map<Category>(categoryDto);
            //category.CreatedByName = createdByName;
            //category.ModifiedByName = createdByName;
            var addedCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            result.Success = true;
            result.Data = _mapper.Map<CategoryDto>(addedCategory);
            return result;
        }

        public async Task<Result<CategoryDto>> Delete(Guid categoryId)
        {
            Result<CategoryDto> result = new Result<CategoryDto>();
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                var deletedCategory = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                result.Success = true;
                result.Data = _mapper.Map<CategoryDto>(deletedCategory);
            }
            return result;
        }

        public async Task<Result<CategoryDto>> UpdateCategory(CategoryDto categoryDto)
        {
            Result<CategoryDto> result = new Result<CategoryDto>();
            var oldCategory = await _unitOfWork.Categories.GetByIdAsync(categoryDto.Id);
            var category = _mapper.Map<CategoryDto, Category>(categoryDto, oldCategory);
            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            result.Success = true;
            result.Data = _mapper.Map<CategoryDto>(updatedCategory);
            return result;
        }

        public async Task<Result<CategoryDto>> GetProductsByCategoryId(Guid categoryId)
        {

            Result<CategoryDto> result = new Result<CategoryDto>();
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            result.Success = true;
            result.Data = _mapper.Map<CategoryDto>(category);
            return result;
        }


        /* List all Categories*/
        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            Result<List<CategoryDto>> result = new Result<List<CategoryDto>>();
            var category = await _unitOfWork.Categories.GetAllAsync();
            result.Success = true;
            result.Data = _mapper.Map<List<CategoryDto>>(category);
            return result;
        }

    }
}
