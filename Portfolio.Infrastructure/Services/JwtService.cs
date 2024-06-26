using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        public Jwt _jwt { get; set; }
        public JwtService(IOptions<Jwt> options)
        {
            _jwt = options.Value;
        }
        public string GetJwtAccessToken(User model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
            new Claim(ClaimTypes.Email, model.Login),
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwt.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetJwtRefreshToken(User model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
            new Claim(ClaimTypes.Email, model.Login),
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_jwt.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
