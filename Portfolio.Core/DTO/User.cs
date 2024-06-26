using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DTO
{
    public record LoginRequest(string Login, string Password);

    public record LoginResponse(Guid Id, string AccessToken, string RefreshToken);
}
