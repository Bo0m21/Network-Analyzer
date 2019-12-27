using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Extensions;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.Connections;
using Network_Analyzer_Backend.Models.Exceptions;
using Network_Analyzer_Database.Enums;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController : ControllerBase
    {
        private readonly IConnectionPacketService _connectionPacketService;
        private readonly IConnectionService _connectionService;
        private readonly ILogger<ConnectionsController> _logger;
        private readonly IMapper _mapper;

        public ConnectionsController(ILogger<ConnectionsController> logger, IMapper mapper,
            IConnectionService connectionService, IConnectionPacketService connectionPacketService)
        {
            _logger = logger;
            _mapper = mapper;
            _connectionService = connectionService;
            _connectionPacketService = connectionPacketService;
        }

        /// <summary>
        ///     Get connection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetConnection")]
        public ActionResult<ConnectionViewModel> GetConnection(long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                Connection connection = _connectionService.GetConnection(userId, id);
                ConnectionViewModel connectionViewModel = _mapper.Map<ConnectionViewModel>(connection);

                IEnumerable<ConnectionPacket> connectionPackets =
                    _connectionPacketService.GetConnectionPackets(userId, connectionViewModel.Id);

                connectionViewModel.Send = connectionPackets.Where(cp => cp.Type == ConnectionPacketType.ClientToServer)
                    .Sum(cp => cp.Data.Length);
                connectionViewModel.Received = connectionPackets
                    .Where(cp => cp.Type == ConnectionPacketType.ServerToClient).Sum(cp => cp.Data.Length);

                return connectionViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Get connections
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetConnections")]
        public ActionResult<List<ConnectionViewModel>> GetConnections()
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                IEnumerable<Connection> connections = _connectionService.GetConnections(userId);
                List<ConnectionViewModel> connectionsViewModel = _mapper.Map<List<ConnectionViewModel>>(connections);

                for (int i = 0; i < connectionsViewModel.Count; i++)
                {
                    IEnumerable<ConnectionPacket> connectionPackets =
                        _connectionPacketService.GetConnectionPackets(userId, connectionsViewModel[i].Id);

                    connectionsViewModel[i].Send = connectionPackets
                        .Where(cp => cp.Type == ConnectionPacketType.ClientToServer).Sum(cp => cp.Data.Length);
                    connectionsViewModel[i].Received = connectionPackets
                        .Where(cp => cp.Type == ConnectionPacketType.ServerToClient).Sum(cp => cp.Data.Length);
                }

                return connectionsViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Get connections count
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetConnectionsCount")]
        public ActionResult<int> GetConnectionsCount()
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                return _connectionService.GetConnectionsCount(userId);
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Create connection
        /// </summary>
        /// <param name="connectionEdit"></param>
        /// <returns></returns>
        [HttpPost("CreateConnection")]
        public ActionResult<ConnectionViewModel> CreateConnection([FromBody] ConnectionEditReqModel connectionEdit)
        {
            try
            {
                Connection connection = _mapper.Map<Connection>(connectionEdit);

                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                // If user exist
                connection.UserId = userId;

                Connection connectionCreate = _connectionService.Create(connection);
                ConnectionViewModel connectionCreateViewModel = _mapper.Map<ConnectionViewModel>(connectionCreate);
                return connectionCreateViewModel;
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Close connection by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CloseConnection")]
        public ActionResult CloseConnection(long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                _connectionService.CloseConnection(userId, id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Close all connections
        /// </summary>
        /// <returns></returns>
        [HttpGet("CloseAllConnection")]
        public ActionResult CloseAllConnection()
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                _connectionService.CloseConnections(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.TreatmentException(ex, out int code, out string message);
                return StatusCode(code, message);
            }
        }

        /// <summary>
        ///     Delete connection by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteConnection")]
        public ActionResult DeleteConnection(long id)
        {
            try
            {
                string claimUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!long.TryParse(claimUserId, out long userId))
                {
                    throw new BadRequestException("User not found");
                }

                Connection connection = _connectionService.GetConnection(userId, id);
                _connectionService.Delete(connection.Id);

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