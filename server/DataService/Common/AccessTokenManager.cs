using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace DataService.Commons
{
    public class AccessTokenManager
    {
        /// <summary>
        ///     Generate jwt token
        /// </summary>
        /// <param name="name">Username</param>
        /// <param name="roles">Role</param>
        /// <param name="userId">customerId or adminStoreId</param>
        /// <returns></returns>
        public static string GenerateJwtToken(string name, string[] roles, int? userId = null)
        {


            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name)
            };
            if (userId != null)
            {
                permClaims.Add(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));

            }
            if (roles != null && roles.Length > 0)
            {
                foreach (string role in roles)
                {
                    permClaims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Issuer,
                permClaims,
                expires: DateTime.Now.AddMinutes(Constants.AccessTokenExpireTimeOnMinutes),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GenerateJwtRefreshToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.RefreshTokenSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            var token = new JwtSecurityToken(
                Constants.RefreshTokenIssuer,
                Constants.RefreshTokenIssuer,
                permClaims,
                expires: DateTime.Now.AddMinutes(Constants.RefreshTokenExpireTimeOnMinutes),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        ///     Verify jwt refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>UserId</returns>
        public static int? VerifyRefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return null;
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(Constants.RefreshTokenSecretKey)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = Constants.RefreshTokenIssuer,
                ValidAudience = Constants.RefreshTokenIssuer
            };
            ClaimsPrincipal claims = null;
            try
            {
                claims = handler.ValidateToken
                (refreshToken, validations, out var secureToken);
                if (claims != null)
                {
                    return int.Parse(claims.Claims.FirstOrDefault
                        (x => x.Type == ClaimTypes.NameIdentifier).Value);
                }
            }
            catch (SecurityTokenException)
            {
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
            }
            return null;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }

            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                //Đã catch password = null ở ngoài
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

    }
}
