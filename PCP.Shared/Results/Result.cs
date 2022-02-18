using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Shared.Results
{
    public class Result
    {
        public Result() : this(false) { }

        public Result(Boolean pSuccess)
        {
            Success = pSuccess;
            Messages = new List<string>();
        }

        public string Message
        {
            get
            {
                return Messages.FirstOrDefault();
            }
            set
            {
                Messages.Add(value);
            }
        }

        public bool Success { get; set; }

        public List<string> Messages { get; set; }

    }

    public class Result<T> : Result
    {
        public Result() : base() { }
        public Result(Boolean pSuccess) : base(pSuccess) { }

        public T Data { get; set; }
    }

}
