using PCP.Entities.Concrete;
using PCP.Entities.Enums;
using PCP.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Services.Abstract
{
    public interface ILogService
    {
        Result<Log> AddLog(Log oLog);
        Result<Log> SaveLog(string LogMessage, AppEnums.LogTypes LogType, string LogFunctionName, Guid LogUserId, string LogError);
    }
}
