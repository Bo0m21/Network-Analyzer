using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.Tokens;

namespace Network_Analyzer_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ILogger<TokensController> _logger;
        private readonly ITokenService _tokenService;

        public TokensController(ILogger<TokensController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        /// <summary>
        ///     Get token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetToken")]
        public ActionResult<TokenViewModel> GetToken()
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new Exception("User not found");
                }

                string token = _tokenService.GetToken(userId);
                return new TokenViewModel { Token = token };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        ///     Generate token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateToken")]
        public ActionResult<TokenViewModel> GenerateToken()
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new Exception("User not found");
                }

                string token = _tokenService.GenerateToken(userId);
                return new TokenViewModel { Token = token };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}