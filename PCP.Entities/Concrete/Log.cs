using PCP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Entities.Concrete
{
    public class Log : BaseEntity
    {

        public Guid LogUserId { get; set; }
        public string LogFieldName { get; set; }
        public string LogMessage { get; set; }
        public byte LogType { get; set; }
        public string LogFunctionName { get; set; }
        public string LogError { get; set; }

    }
}
