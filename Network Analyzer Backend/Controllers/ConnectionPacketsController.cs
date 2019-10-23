using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.ConnectionPackets;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionPacketsController : ControllerBase
    {
        private readonly ILogger<ConnectionPacketsController> _logger;
        private readonly IMapper _mapper;
        private readonly IConnectionPacketService _connectionPacketService;

        public ConnectionPacketsController(ILogger<ConnectionPacketsController> logger, IMapper mapper, IConnectionPacketService connectionPacketService)
        {
            _logger = logger;
            _mapper = mapper;
            _connectionPacketService = connectionPacketService;
        }

        /// <summary>
        ///     Get connection packet
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ConnectionPacketViewModel> GetConnectionPacket(long connectionId, long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new Exception("User not found");
                }

                ConnectionPacket connectionPacket = _connectionPacketService.GetConnectionPacket(userId, connectionId, id);
                ConnectionPacketViewModel connectionPacketViewModel = _mapper.Map<ConnectionPacketViewModel>(connectionPacket);
                return connectionPacketViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        ///     Get connections
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ConnectionPacketViewModel>> GetConnections(long connectionId)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new Exception("User not found");
                }

                IEnumerable<ConnectionPacket> connectionPackets = _connectionPacketService.GetConnectionPackets(connectionId, userId);
                List<ConnectionPacketViewModel> connectionPacketsViewModel = _mapper.Map<List<ConnectionPacketViewModel>>(connectionPackets);
                return connectionPacketsViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}