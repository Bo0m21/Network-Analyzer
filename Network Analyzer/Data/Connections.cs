using Network_Analyzer.Models;
using Network_Analyzer.Models.Packets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Network_Analyzer.Data
{
    /// <summary>This is class connections which save data</summary>
    public static class Connections
    {
        /// <summary>Array connections and packets</summary>
        private static List<ConnectionModel> _connections = new List<ConnectionModel>();

        /// <summary>Array connections and packets</summary>
        private static long _clinetsCount = 0;

        /// <summary>Array connections and packets</summary>
        private static long _packetsCount = 0;

        /// <summary>Get all connections</summary>
        /// <returns>List connections</returns>
        public static IEnumerable<ConnectionModel> GetConnections()
        {
            return _connections;
        }

        /// <summary>Get connection at id</summary>
        /// <param name="id">Id connection in collection</param>
        /// <returns>Return connection or null</returns>
        public static ConnectionModel GetConnection(long id)
        {
            return _connections.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>Get connection at index</summary>
        /// <param name="index">Index connection in collection</param>
        /// <returns>Return connection or null</returns>
        public static ConnectionModel GetConnectionAtIndex(int index)
        {
            if (index < 0 || index >= _connections.Count)
                return null;

            return _connections[index];
        }

        /// <summary>Add new connection</summary>
        /// <param name="newConnection">New connection</param>
        public static void AddConnection(ConnectionModel newConnection)
        {
            var connection = _connections.FirstOrDefault(c => c.Id == newConnection.Id);

            if (connection == null)
            {
                _connections.Add(newConnection);
            }
        }

        /// <summary>Add new connections</summary>
        /// <param name="newConnections">New connections</param>
        public static void AddConnectionList(List<ConnectionModel> newConnections)
        {
            foreach (var newConnection in newConnections)
            {
                var connection = _connections.FirstOrDefault(c => c.Id == newConnection.Id);

                if (connection == null)
                {
                    _connections.Add(newConnection);
                }
            }
        }

        /// <summary>Add new packet for connection</summary>
        /// <param name="id">Id connection</param>
        /// <param name="newPacket">New packet</param>
        public static void AddConnectionPacket(long id, PacketModel newPacket)
        {
            var connection = _connections.FirstOrDefault(c => c.Id == id);

            if (connection != null)
            {
                connection.ConnectionPackets.Add(newPacket);

                if (newPacket.Type == PacketType.ClientToServer)
                {
                    connection.Send += newPacket.Data.Length;
                }
                else if (newPacket.Type == PacketType.ServerToClient)
                {
                    connection.Received += newPacket.Data.Length;
                }
            }
        }

        /// <summary>Update flag IsDisconnected if connection was close</summary>
        /// <param name="id">Id connection</param>
        public static void DisconnectedConnection(long id)
        {
            var connection = _connections.FirstOrDefault(c => c.Id == id);

            if (connection != null)
            {
                connection.IsDisconnected = true;
            }
        }

        /// <summary>Get count connections</summary>
        /// <returns>Count connections</returns>
        public static int GetCount()
        {
            return _connections.Count;
        }

        /// <summary>Clear all connections</summary>
        public static void Clear()
        {
            _connections.Clear();
        }
    }
}
