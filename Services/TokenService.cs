#pragma warning disable 1591
// From: https://github.com/StefanescuEduard/DotnetSwaggerDocumentation/blob/master/API.WithAuthentication/Services/TokenService.cs
using BlazorFileUploadSwagger.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BlazorFileUploadSwagger.Services
{
    public class TokenService
    {
        private readonly AppSettings appSettings;

        public TokenService(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
        }

        public async Task<string> GetToken()
        {
            SecurityTokenDescriptor tokenDescriptor = await GetTokenDescriptor();
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private async Task<SecurityTokenDescriptor> GetTokenDescriptor()
        {
            const int expiringHours = 24;

            byte[] securityKey = await Task.Run(() => Encoding.UTF8.GetBytes(appSettings.EncryptionKey));
            var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(expiringHours),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }
    }
}
