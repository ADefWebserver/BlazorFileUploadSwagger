using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorFileUploadSwagger.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorFileUploadSwagger.Controlers
{
    /// <summary>
    /// Auth Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Auth Token
        public class ApiToken
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ApplicationGUID { get; set; }
        }

        public IConfiguration _configuration;
        private readonly JWTAuthenticationService authenticationService;
        
        public AuthController(IConfiguration configuration,
            JWTAuthenticationService authenticationService)
        {
            _configuration = configuration;
            this.authenticationService = authenticationService;
        }        

        #region public async Task<string> GetAuthToken([FromQuery] ApiToken objApiToken)
        /// <summary>
        /// Obtain a security token to use for subsequent calls - copy the output received and then click the Authorize button (above). Paste the contents (between the quotes) into that box and then click Authorize then close. Now the remaining methods will work.
        /// </summary>
        /// <param name="objApiToken"></param>
        /// <response code="200">JWT token created</response>
        [AllowAnonymous]
        [HttpGet("GetAuthToken")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<string> GetAuthToken([FromQuery] ApiToken objApiToken)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("username", objApiToken.UserName);
            dict.Add("password", objApiToken.Password);
            dict.Add("applicationGUID", objApiToken.ApplicationGUID);

            string token = await authenticationService.Authenticate(objApiToken);
            return token;
        }
        #endregion
    }
}
