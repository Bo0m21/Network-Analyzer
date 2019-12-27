using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Extensions;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.ConnectionPackets;
using Network_Analyzer_Backend.Models.Exceptions;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionPacketsController : ControllerBase
    {
        private readonly ILogger<ConnectionPacketsController> _logger;
        private readonly IMapper _mapper;
        private readonly IConnectionService _connectionService;
        private readonly IConnectionPacketService _connectionPacketService;

        public ConnectionPacketsController(ILogger<ConnectionPacketsController> logger, IMapper mapper, IConnectionService connectionService, IConnectionPacketService connectionPacketService)
        {
            _logger = logger;
            _mapper = mapper;
            _connectionService = connectionService;
            _connectionPacketService = connectionPacketService;
        }

        /// <summary>
        ///     Get connection packet
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetConnectionPacket")]
        public ActionResult<ConnectionPacketViewModel> GetConnectionPacket(long connectionId, long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                ConnectionPacket connectionPacket = _connectionPacketService.GetConnectionPacket(userId, connectionId, id);
                ConnectionPacketViewModel connectionPacketViewModel = _mapper.Map<ConnectionPacketViewModel>(connectionPacket);

                return connectionPacketViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Get connection packets
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        [HttpGet("GetConnectionPackets")]
        public ActionResult<List<ConnectionPacketViewModel>> GetConnectionPackets(long connectionId)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                IEnumerable<ConnectionPacket> connectionPackets = _connectionPacketService.GetConnectionPackets(userId, connectionId);
                List<ConnectionPacketViewModel> connectionPacketsViewModel = _mapper.Map<List<ConnectionPacketViewModel>>(connectionPackets);

                return connectionPacketsViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Get connections packets count
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        [HttpGet("GetConnectionPacketsCount")]
        public ActionResult<int> GetConnectionPacketsCount(long connectionId)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                return _connectionPacketService.GetConnectionPacketsCount(userId, connectionId);
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Create connection packet
        /// </summary>
        /// <param name="connectionPacketEdit"></param>
        /// <returns></returns>
        [HttpPost("CreateConnectionPacket")]
        public ActionResult<ConnectionPacketViewModel> CreateConnectionPacket(long connectionId,
            [FromBody] ConnectionPacketEditReqModel connectionPacketEdit)
        {
            try
            {
                ConnectionPacket connectionPacket = _mapper.Map<ConnectionPacket>(connectionPacketEdit);

                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                Connection connection = _connectionService.GetConnection(userId, connectionId);
                connectionPacket.ConnectionId = connection.Id;

                ConnectionPacket connectionPacketCreate = _connectionPacketService.Create(connectionPacket);
                ConnectionPacketViewModel connectionPacketCreateViewModel = _mapper.Map<ConnectionPacketViewModel>(connectionPacketCreate);

                return connectionPacketCreateViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Delete connection packet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteConnectionPacket")]
        public ActionResult DeleteConnectionPacket(long connectionId, long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                Connection connection = _connectionService.GetConnection(userId, connectionId);
                _connectionPacketService.Delete(connection.Id);

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