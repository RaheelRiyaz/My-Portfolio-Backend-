using Portfolio.Core.ResponseCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core
{
    public class DataResponse <T>
    {
        public ResponseCode Code { get; set; }
        public string Info { get; set; } = null!;
        public T? Result { get; set; }


        public static DataResponse<T> SuccessResponse
            (
            T result,
            ResponseCode code = ResponseCode.Success,
            string info = "Success"
            )
        {
            return new DataResponse<T> { Code = code, Info = info, Result = result };
        }


        public static DataResponse<T> ErrorResponse
           (
           ResponseCode code = ResponseCode.ServerError,
           string info = "Error"
           )
        {
            return new DataResponse<T> { Code = code, Info = info };
        }
    }
}
