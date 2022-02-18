using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCP.Entities.Dtos;
using PCP.Entities.Enums;
using PCP.Services.Abstract;
using PCP.Services.FluentValidator;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogProjectAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {

        private readonly ICategoryService _categoryService;
        private readonly IValidatorFactory _validatorFactory;

        public CategoryController(ICategoryService categoryService, IValidatorFactory validatorFactory)
        {
            _categoryService = categoryService;
            _validatorFactory = validatorFactory;
        }

        [HttpPost]
      //  [Authorize]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                var ValidateMessage = _validatorFactory.GetDefaultValidator<CategoryDto>().Validate(categoryDto).Errors.FirstOrDefault();
                if (ValidateMessage != null)
                {
                    return BadRequest(ValidateMessage.ErrorMessage);
                }

                var result =  await _categoryService.AddCategory(categoryDto);

                if (result.Success)
                    SaveLog( "Kategori ekleme işlemi başarılı", AppEnums.LogTypes.Success,"CategoryController.AddCategory" ,new Guid(), "");
                else
                    SaveLog("Kategori ekleme işlemi başarısız", AppEnums.LogTypes.UnSuccess,"CategoryController.AddCategory" ,new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Kategori ekleme işleminde hata!", AppEnums.LogTypes.Error, "CategoryController.AddCategory", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


        [HttpPost]
        //  [Authorize]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                var ValidateMessage = _validatorFactory.GetDefaultValidator<CategoryDto>().Validate(categoryDto).Errors.FirstOrDefault();
                if (ValidateMessage != null)
                {
                    return BadRequest(ValidateMessage.ErrorMessage);
                }

                var result = await _categoryService.UpdateCategory(categoryDto);

                if (result.Success)
                    SaveLog("Kategori güncelleme işlemi başarılı ", AppEnums.LogTypes.Success, "CategoryController.UpdateCategory", new Guid(), "");
                else
                    SaveLog("Kategori güncelleme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "CategoryController.UpdateCategory", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Kategori güncelleme işleminde hata!", AppEnums.LogTypes.Error, "CategoryController.UpdateCategory", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {

            try
            {
                var result = await _categoryService.GetAllCategories();
                if (result.Success)
                    SaveLog("Kategori listeleme işlemi başarılı", AppEnums.LogTypes.Success, "CategoryController.GetAllCategories", new Guid(), "");
                else
                    SaveLog("Kategori listeleme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "CategoryController.GetAllCategories", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Kategori listeleme işleminde hata!", AppEnums.LogTypes.Error, "CategoryController.GetAllCategories", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId)
        {

            try
            {
                var result = await _categoryService.GetProductsByCategoryId(categoryId);
                if (result.Success)
                    SaveLog("Kategoriye bağlı ürünleri getirme işlemi başarılı", AppEnums.LogTypes.Success, "CategoryController.GetProductsByCategoryId", new Guid(), "");
                else
                    SaveLog("Kategoriye bağlı ürünleri getirme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "CategoryController.GetProductsByCategoryId", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Kategoriye bağlı ürünleri getirme işleminde hata!", AppEnums.LogTypes.Error, "CategoryController.GetProductsByCategoryId", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }

    }
}
