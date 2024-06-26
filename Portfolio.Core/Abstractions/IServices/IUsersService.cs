
using Portfolio.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IServices
{
    public interface IUsersService
    {
        Task<DataResponse<LoginResponse>> Login(LoginRequest model);
    }
}
