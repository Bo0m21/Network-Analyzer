using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Extensions;
using Network_Analyzer_Backend.Helpers;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.BaseModels;
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
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        ///     Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin + ", " + Roles.Manager)]
        [HttpGet("GetUser")]
        public ActionResult<UserViewResModel> GetUser(long id)
        {
            try
            {
                User user = _userService.GetUser(id);
                UserViewResModel userViewModel = _mapper.Map<UserViewResModel>(user);
                return userViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Create user
        /// </summary>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("CreateUser")]
        public ActionResult<UserViewResModel> CreateUser([FromBody] UserEditReqModel userEdit)
        {
            User user = _mapper.Map<User>(userEdit);

            try
            {
                User userCreate = _userService.Create(user, userEdit.Password);
                UserViewResModel userCreateViewModel = _mapper.Map<UserViewResModel>(userCreate);
                return userCreateViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public ActionResult<BaseResponseModel> UpdateUser(long id, [FromBody] UserEditReqModel userEdit)
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
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("DeleteUser")]
        public ActionResult DeleteUser(long id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }
    }
}