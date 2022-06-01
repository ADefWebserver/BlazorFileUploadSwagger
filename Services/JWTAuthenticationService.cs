#pragma warning disable 1591
using static BlazorFileUploadSwagger.Controlers.AuthController;

namespace BlazorFileUploadSwagger.Services
{
    public class JWTAuthenticationService
    {
        private readonly TokenService tokenService;

        public JWTAuthenticationService(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public async Task<string> Authenticate(ApiToken userCredentials)
        {
            // **********************
            // TO DO
            // ACTUALLY authenticate the username and password HERE
            // **********************
            
            string securityToken = await tokenService.GetToken();

            return securityToken;
        }
    }
}
