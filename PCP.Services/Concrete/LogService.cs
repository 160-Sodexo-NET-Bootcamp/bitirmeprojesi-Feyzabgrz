using PCP.Data.Concrete.UnitOfWork;
using PCP.Entities.Concrete;
using PCP.Entities.Enums;
using PCP.Services.Abstract;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Services.Concrete
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Result<Log> AddLog(Log oLog)
        {
            Result<Log> result = new Result<Log>();
            try
            {

               // var model = _unitOfWork.Log.Add(oLog);

                _unitOfWork.SaveAsync();
                //result.Data = model.Entity;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;

                result.Success = false;
            }
            return result;
        }

        public Result<Log> SaveLog(string LogMessage, AppEnums.LogTypes LogType, string LogFunctionName, Guid LogUserId, string LogError)
        {
            Result<Log> returnLog = new Result<Log>();

            try
            {

                var model = new Log()
                {
                    LogError = LogError,
                    LogFunctionName = LogFunctionName.ToString(),
                    LogType = (byte)LogType,
                    LogUserId = LogUserId
                };
                returnLog = AddLog(model);
            }
            catch (Exception ex)
            {

                returnLog.Message = ex.Message;
            }

            return returnLog;

        }
    }
}
