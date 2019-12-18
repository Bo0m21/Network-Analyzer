using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Network_Analyzer_Backend.Extensions;
using Network_Analyzer_Backend.Helpers;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.Users;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public AuthenticateController(ILogger<AuthenticateController> logger, IOptions<AppSettings> appSettings, IUserService userService)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        /// <summary>
        ///     Authenticate user by username and password
        /// </summary>
        /// <param name="userAuth"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        public ActionResult<UserAuthResModel> Authenticate([FromBody] UserAuthReqModel userAuth)
        {
            try
            {
                User user = _userService.Authenticate(userAuth.Username, userAuth.Password);

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenString = tokenHandler.WriteToken(token);

                return Ok(new UserAuthResModel { Username = user.Username, Token = tokenString });
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        // TODO logout
    }
}