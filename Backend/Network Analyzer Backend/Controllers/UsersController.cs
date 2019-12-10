using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Network_Analyzer_Backend.Helpers;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.Users;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IMapper mapper, IOptions<AppSettings> appSettings, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        /// <summary>
        ///     Authenticate user by username and password
        /// </summary>
        /// <param name="userAuth"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Authenticate")]
        [HttpPost]
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

                return Ok(new UserAuthResModel
                {
                    Username = user.Username,
                    Token = tokenString
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        ///     Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin + ", " + Roles.Manager)]
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetUser(long id)
        {
            try
            {
                User user = _userService.GetUser(id);
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
                return userViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        ///     Create user
        /// </summary>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public ActionResult<UserViewModel> Create([FromBody] UserEditModel userEdit)
        {
            User user = _mapper.Map<User>(userEdit);

            try
            {
                User userCreate = _userService.Create(user, userEdit.Password);
                UserViewModel userCreateViewModel = _mapper.Map<UserViewModel>(userCreate);
                return userCreateViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        ///     Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody] UserEditModel userEdit)
        {
            User user = _mapper.Map<User>(userEdit);
            user.Id = id;

            try
            {
                _userService.Update(user, userEdit.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        ///     Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}