#pragma warning disable 1591
using Microsoft.Extensions.Options;
using static BlazorFileUploadSwagger.Controlers.AuthController;

namespace BlazorFileUploadSwagger.Services
{
    public class JWTAuthenticationService
    {
        private readonly AppSettings appSettings;
        private readonly TokenService tokenService;

        public JWTAuthenticationService(IOptions<AppSettings> options, TokenService tokenService)
        {
            appSettings = options.Value;
            this.tokenService = tokenService;
        }

        public async Task<string> Authenticate(ApiToken userCredentials)
        {
            // **********************
            // authenticate the username and password 
            // **********************

            string securityToken = "";
            
            if (
                (appSettings.UserName.ToLower() == userCredentials.UserName.ToLower())
                && 
                (appSettings.Password == userCredentials.Password)
                )
            {
                securityToken = await tokenService.GetToken();
            }

            return securityToken;
        }
    }
}
