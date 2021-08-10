using DataService.BaseConnect;
using DataService.Commons;
using DataService.Models.Entities;
using DataService.Models.Responses;
using DataService.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public partial interface IUserService
    {
        public AuthenticateResponse Authenticate(string username, string password, string ipAddress);
        public AuthenticateResponse RefreshToken(string refreshToken, string ipAddress);
        public bool RevokeToken(string refeshToken, string ipAddress);
    }

    public partial class UserService
    {
        private IRefreshTokenRepository _refreshTokenRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository,
            IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository)
            : base(unitOfWork, repository)
        {
            ConnectionString = configuration.GetConnectionString("Default");
            this.repository = repository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public AuthenticateResponse Authenticate(string username, string password, string ipAddress)
        {
            User user = FirstOrDefault(x => x.Username == username && x.Password == password);
            string[] roles = { "user" };
            if (user != null)
            {
                string accessToken = AccessTokenManager.GenerateJwtToken(username, roles, user.Id);
                string refreshTokenString = AccessTokenManager.GenerateJwtRefreshToken(user.Id);
                RefreshToken refreshToken = new()
                {
                    Created = DateTime.Now,
                    Expired = DateTime.Now.AddMinutes(Constants.RefreshTokenExpireTimeOnMinutes),
                    UserId = user.Id,
                    Token = refreshTokenString,
                    CreatedByIp = ipAddress,
                };
                _refreshTokenRepository.Create(refreshToken);
                this.Save();
                return new AuthenticateResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshTokenString,
                    User = user,
                };
            }
            return null;
        }
        public AuthenticateResponse RefreshToken(string refreshToken, string ipAddress)
        {
            int? userId = AccessTokenManager.VerifyRefreshToken(refreshToken);
            if (userId == null)
            {
                return null;
            }
            User user = FirstOrDefault(x => x.RefreshTokens.Any(t => t.Token == refreshToken
            && t.Expired > DateTime.Now && t.Revoked == null));
            if (user == null)
            {
                return null;
            }
            string accessToken = AccessTokenManager.GenerateJwtToken(user.Username, new string[] { "user" }, user.Id);
            RefreshToken newRefreshToken = new()
            {
                Token = AccessTokenManager.GenerateJwtRefreshToken(user.Id),
                Created = DateTime.Now,
                Expired = DateTime.Now.AddMinutes(Constants.RefreshTokenExpireTimeOnMinutes),
                UserId = user.Id,
                CreatedByIp = ipAddress,
            };
            _refreshTokenRepository.Create(newRefreshToken);
            RefreshToken oldRefeshToken = _refreshTokenRepository.FirstOrDefault(x => x.Token == refreshToken);
            oldRefeshToken.ReplaceByToken = newRefreshToken.Token;
            oldRefeshToken.Revoked = DateTime.Now;
            oldRefeshToken.RevokedByIp = ipAddress;
            this.Save();
            return new AuthenticateResponse
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken.Token,
                User = user,
            };

        }
        public bool RevokeToken(string refeshToken, string ipAddress)
        {
            try
            {
                RefreshToken token = _refreshTokenRepository.FirstOrDefault(x => x.Token == refeshToken
                && x.Revoked == null);
                if (token != null)
                {
                    token.Revoked = DateTime.Now;
                    token.RevokedByIp = ipAddress;
                    this.Save();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


    }
}
