using System.Collections.Generic;
using System.Linq;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models.Exceptions;
using Network_Analyzer_Database;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Services
{
    public class ConnectionPacketService : IConnectionPacketService
    {
        private readonly DatabaseContext _databaseContext;

        public ConnectionPacketService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get connection packet by user id and connection id and connection packet id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connectionId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ConnectionPacket GetConnectionPacket(long userId, long connectionId, long id)
        {
            Connection connection =
                _databaseContext.Connections.FirstOrDefault(c => c.UserId == userId && c.Id == connectionId);

            if (connection == null)
            {
                throw new BadRequestException("Connection not found");
            }

            ConnectionPacket connectionPacket =
                _databaseContext.ConnectionPackets.FirstOrDefault(u => u.ConnectionId == connectionId && u.Id == id);

            if (connectionPacket == null)
            {
                throw new BadRequestException("Connection packet not found");
            }

            return connectionPacket;
        }

        /// <summary>
        ///     Get connection packets by user id and connection id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public IEnumerable<ConnectionPacket> GetConnectionPackets(long userId, long connectionId)
        {
            Connection connection =
                _databaseContext.Connections.FirstOrDefault(c => c.UserId == userId && c.Id == connectionId);

            if (connection == null)
            {
                throw new BadRequestException("Connection not found");
            }

            return _databaseContext.ConnectionPackets.Where(c => c.ConnectionId == connectionId);
        }

        /// <summary>
        ///     Create connection packet
        /// </summary>
        /// <param name="connectionPacket"></param>
        /// <returns></returns>
        public ConnectionPacket Create(ConnectionPacket connectionPacket)
        {
            _databaseContext.ConnectionPackets.Add(connectionPacket);
            _databaseContext.SaveChanges();

            return connectionPacket;
        }

        /// <summary>
        ///     Update connection packet
        /// </summary>
        /// <param name="connectionPacketParam"></param>
        public void Update(ConnectionPacket connectionPacketParam)
        {
            ConnectionPacket connectionPacket = _databaseContext.ConnectionPackets.Find(connectionPacketParam.Id);

            if (connectionPacket == null)
            {
                throw new BadRequestException("Connection packet not found");
            }

            // Update connection packet properties
            connectionPacket.Data = connectionPacketParam.Data;
            connectionPacket.Type = connectionPacketParam.Type;
            connectionPacket.IsDeleted = connectionPacketParam.IsDeleted;

            _databaseContext.ConnectionPackets.Update(connectionPacket);
            _databaseContext.SaveChanges();
        }

        /// <summary>
        ///     Delete connection packet by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            ConnectionPacket connectionPacket = _databaseContext.ConnectionPackets.FirstOrDefault(u => u.Id == id);

            if (connectionPacket == null)
            {
                throw new BadRequestException("Connection packet not found");
            }

            connectionPacket.IsDeleted = true;
            _databaseContext.SaveChanges();
        }
    }
}