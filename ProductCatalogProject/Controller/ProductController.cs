using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCP.Entities.Dtos;
using PCP.Entities.Enums;
using PCP.Services.Abstract;
using PCP.Services.FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogProjectAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        private readonly IProductService _productService;
        private readonly IValidatorFactory _validatorFactory;

        public ProductController(IProductService productService, IValidatorFactory validatorFactory)
        {
            _productService = productService;
            _validatorFactory = validatorFactory;
        }

        [HttpPost]
        //  [Authorize]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var ValidateMessage = _validatorFactory.GetDefaultValidator<ProductDto>().Validate(productDto).Errors.FirstOrDefault();
                if (ValidateMessage != null)
                {
                    return BadRequest(ValidateMessage.ErrorMessage);
                }

                var result = await _productService.AddProduct(productDto);

                if (result.Success)
                    SaveLog("Ürün ekleme işlemi başarılı", AppEnums.LogTypes.Success, "ProductController.AddProduct", new Guid(), "");
                else
                    SaveLog("Ürün ekleme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.AddProduct", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Ürün ekleme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.AddProduct", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


        /*Bütün renkleri getiren endpoint*/

        [HttpGet]
        public async Task<IActionResult> GetAllColor()
        {

            try
            {
                var result = await _productService.GetAllColor();
                if (result.Success)
                    SaveLog("Renk listesi getirme işlemi başarılı", AppEnums.LogTypes.Success, "ProductController.GetAllColor", new Guid(), "");
                else
                    SaveLog("Renk listesi getirme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.GetAllColor", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Renk listesi getirme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.GetAllColor", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }

        /*Renk filtresine göre ürünleri listeleyen endpoint*/

        [HttpGet]
        public async Task<IActionResult> GetProductsByColor(string color)
        {

            try
            {
                var result = await _productService.GetProductsByColor(color);
                if (result.Success)
                    SaveLog("Renge bağlı ürünleri getirme işlemi başarılı", AppEnums.LogTypes.Success, "ProductController.GetProductsByColor", new Guid(), "");
                else
                    SaveLog("Renge bağlı ürünleri getirme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.GetProductsByColor", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Renge bağlı ürünleri getirme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.GetProductsByColor", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {

            try
            {
                var result = await _productService.GetAllBrand();
                if (result.Success)
                    SaveLog("Marka listesi getirme işlemi başarılı", AppEnums.LogTypes.Success, "ProductController.GetAllBrand", new Guid(), "");
                else
                    SaveLog("Marka listesi getirme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.GetAllBrand", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Marka listesi getirme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.GetAllBrand", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }

        /*Renk filtresine göre ürünleri listeleyen endpoint*/

        [HttpGet]
        public async Task<IActionResult> GetProductsByBrand(string brand)
        {

            try
            {
                var result = await _productService.GetProductsByBrand(brand);
                if (result.Success)
                    SaveLog("Markaya bağlı ürünleri getirme işlemi başarılı", AppEnums.LogTypes.Success, "ProductController.GetProductsBrand", new Guid(), "");
                else
                    SaveLog("Markaya bağlı ürünleri getirme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.GetProductsBrand", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("GetProductsBrand bağlı ürünleri getirme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.GetProductsBrand", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


        [HttpPost]
        //  [Authorize]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var ValidateMessage = _validatorFactory.GetDefaultValidator<ProductDto>().Validate(productDto).Errors.FirstOrDefault();
                if (ValidateMessage != null)
                {
                    return BadRequest(ValidateMessage.ErrorMessage);
                }

                var result = await _productService.UpdateProduct(productDto);

                if (result.Success)
                    SaveLog("Ürün güncelleme işlemi başarılı ", AppEnums.LogTypes.Success, "ProductController.UpdateProduct", new Guid(), "");
                else
                    SaveLog("Ürün güncelleme işlemi başarısız", AppEnums.LogTypes.UnSuccess, "ProductController.UpdateProduct", new Guid(), result.Message);

                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                SaveLog("Ürün güncelleme işleminde hata!", AppEnums.LogTypes.Error, "ProductController.UpdateProduct", new Guid(), ex.Message);
                return new JsonResult(new { success = false, message = "Hata oluştu" });
            }
        }


    }
}
