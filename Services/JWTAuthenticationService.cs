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

        public string Authenticate(ApiToken userCredentials)
        {
            string securityToken = tokenService.GetToken();

            return securityToken;
        }
    }
}
