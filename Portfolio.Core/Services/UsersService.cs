using Portfolio.Core.Abstractions.IRepository;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.DTO;
using Portfolio.Core.ResponseCodes;
using Portfolio.Core.UtilsMehtods;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class UsersService
        (
        IUsersRepository repository,
        IJwtService jwtService
        )
        : IUsersService
    {
        public async Task<DataResponse<LoginResponse>> Login(LoginRequest model)
        {
            var user = await repository.FindOneAsync(_ => _.Login == model.Login);

            if (user is null)
                return DataResponse<LoginResponse>.ErrorResponse(ResponseCode.InvalidCredentials,"Login details invalid");

            if(!Utils.VerifyPassword(model.Password,user.Password))
                return DataResponse<LoginResponse>.ErrorResponse(ResponseCode.InvalidCredentials, "Login details invalid");

            var response = WriteLoginResponse(user);

            return DataResponse<LoginResponse>.SuccessResponse(response);
        }




        #region Helper Functions
        private LoginResponse WriteLoginResponse(User model)
        {
            var accessToken = jwtService.GetJwtAccessToken(model);
            var refreshToken = jwtService.GetJwtRefreshToken(model);

            var response = new LoginResponse(model.Id,accessToken, refreshToken);

            return response;
        }
        #endregion Helper Functions

    }
}
