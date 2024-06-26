using Portfolio.Core.ResponseCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Exceptions
{
    public class AppException : Exception
    {
        public AppException(ResponseCode code) : base(code.ToString())
        {
            Code = code;
        }
        public AppException(ResponseCode code, string message) : base($"{code}: {message}")
        {
            Code = code;
            Info = message;
        }
        public AppException(string message) : base($"{message}")
        {
        }
        public AppException(ResponseCode code, Exception innerException) : base(code.ToString(), innerException)
        {
            Code = code;
        }
        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ResponseCode Code { get; set; }
        public string Info { get; set; } = null!;

    }
}
