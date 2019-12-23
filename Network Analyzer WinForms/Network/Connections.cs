using System.Collections.Generic;
using System.Linq;
using Network_Analyzer_WinForms.Models.Connection;

namespace Network_Analyzer_WinForms.Network
{
    /// <summary>
    ///     This is class connections which save data
    /// </summary>
    public static class Connections
    {
        /// <summary>
        ///     Array connections and packets
        /// </summary>
        private static readonly List<ConnectionModel> _connections = new List<ConnectionModel>();

        /// <summary>
        ///     Connection id
        /// </summary>
        private static long _connectionId { get; set; }

        /// <summary>
        ///     Connection packet id
        /// </summary>
        private static long _connectionPacketId { get; set; }

        /// <summary>
        ///     Get all connections
        /// </summary>
        /// <returns>List connections</returns>
        public static List<ConnectionModel> GetConnections()
        {
            return _connections;
        }

        /// <summary>
        ///     Get new connection id
        /// </summary>
        /// <returns>New connection id</returns>
        public static long GetConnectionId()
        {
            _connectionId = _connectionId + 1;
            return _connectionId;
        }

        /// <summary>
        ///     Get new packet id for connection
        /// </summary>
        /// <returns>New packet id for connection</returns>
        public static long GetConnectionPacketId()
        {
            _connectionPacketId = _connectionPacketId + 1;
            return _connectionPacketId;
        }

        /// <summary>
        ///     Add new connection
        /// </summary>
        /// <param name="newConnection">New connection</param>
        public static void AddConnection(ConnectionModel newConnection)
        {
            ConnectionModel connection = _connections.FirstOrDefault(c => c.Id == newConnection.Id);

            if (connection == null)
            {
                _connections.Add(newConnection);
            }
        }

        /// <summary>
        ///     Add new connection packet for connection
        /// </summary>
        /// <param name="id">Id connection</param>
        /// <param name="newConnectionPacket">New connection packet</param>
        public static void AddConnectionPacket(long id, ConnectionPacketModel newConnectionPacket)
        {
            ConnectionModel connection = _connections.FirstOrDefault(c => c.Id == id);

            if (connection != null)
            {
                connection.ConnectionPackets.Add(newConnectionPacket);

                if (newConnectionPacket.Type == ConnectionPacketType.ClientToServer)
                {
                    connection.Send += newConnectionPacket.Data.Length;
                }
                else if (newConnectionPacket.Type == ConnectionPacketType.ServerToClient)
                {
                    connection.Received += newConnectionPacket.Data.Length;
                }
            }
        }

        /// <summary>
        ///     Update flag IsDisconnected if connection was close
        /// </summary>
        /// <param name="id">Id connection</param>
        public static void DisconnectedConnection(long id)
        {
            ConnectionModel connection = _connections.FirstOrDefault(c => c.Id == id);

            if (connection != null)
            {
                connection.IsDisconnected = true;
            }
        }
    }
}