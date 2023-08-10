using EP_Task.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace EP_Task.Infrastructure.Utility
{
    public class EncriptionUtility
    {
        private readonly Configs configs;

        public EncriptionUtility(IOptions<Configs> options)
        {
            this.configs = options.Value;
        }


        public string GetSHA256(string password,string salt)
        {

            using(var sha256 = SHA256.Create())
            {
                var bytes= sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                var hash=BitConverter.ToString(bytes).Replace("-", "").ToLower(); ;
                return hash;
            }


        }


        public string GetNewSalt()
        {

            return Guid.NewGuid().ToString();
        }

        public string GetNewRefreshToken() {
            return Guid.NewGuid().ToString();
        }

        public string GetNewToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configs.ToKenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {

              new Claim("userId",userId.ToString())
              }),
                Expires = DateTime.UtcNow.AddMinutes(configs.TokenTimeOut),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}
