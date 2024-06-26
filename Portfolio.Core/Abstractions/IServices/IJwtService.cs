using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IServices
{
    public interface IJwtService
    {
        string GetJwtAccessToken(User model);
        string GetJwtRefreshToken(User model);
    }
}
