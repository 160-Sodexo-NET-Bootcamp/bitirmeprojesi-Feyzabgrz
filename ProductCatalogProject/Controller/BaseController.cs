using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCP.Entities.Concrete;
using PCP.Entities.Enums;
using PCP.Services.Abstract;
using PCP.Services.FluentValidator;
using PCP.Shared.Results;
using System;
using System.Linq;

namespace ProductCatalogProjectAPI.Controller
{
    public abstract class BaseController : ControllerBase
    {

        public ILogService _logService { get; set; }

        //public IMapper Mapper { get; set; }

        public IValidatorFactory _validatorFactory { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public Result<Log> SaveLog(string LogMessage, AppEnums.LogTypes LogType, string LogFunctionName, Guid LogUserId, string LogError)
        {
            var result = _logService.SaveLog(LogMessage, LogType, LogFunctionName, LogUserId, LogError);
            return result;
        }


        [HttpGet]
        [AllowAnonymous]
        public string Validate<T>(T model)
        {
            var validator = _validatorFactory.GetDefaultValidator<T>();
            var validatorResult = validator.Validate(model);
            validatorResult.Errors.ToList()
                .ForEach(err => ModelState.AddModelError(err.PropertyName, err.ErrorMessage));
            if (validatorResult.IsValid == false)
                ModelState.AddModelError(string.Empty, "Lütfen zorunlu alanları giriniz!");

            var errorMessageList = validatorResult.Errors.Where(m => m.ErrorMessage != "").ToList();
            if (errorMessageList.Count() == 0)
            {
                return "";
            }
            else
            {
                return errorMessageList.FirstOrDefault().ErrorMessage;
            }
        }


    }
}
