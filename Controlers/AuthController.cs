using BlazorFileUploadSwagger.Models;
using BlazorFileUploadSwagger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        private readonly JWTAuthenticationService authenticationService;
        
        public AuthController(JWTAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }        

        #region public async Task<string> GetAuthToken([FromQuery] ApiToken objApiToken)
        /// <summary>
        /// Obtain a security token to use for subsequent calls. 
        /// Copy the output received and then click the Authorize button (above). 
        /// Paste the contents (between the quotes) into that box and then 
        /// click Authorize then close. Now the remaining methods will work.
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

            string token = await authenticationService.Authenticate(objApiToken);
            
            return token;
        }
        #endregion
    }
}
