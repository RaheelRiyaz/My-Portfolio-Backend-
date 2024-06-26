using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.DTO;

namespace New_Portfolio_Backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
        (
        IUsersService usersService
        ) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<DataResponse<LoginResponse>> Login(LoginRequest model) =>
            await usersService.Login(model);
    }
}
