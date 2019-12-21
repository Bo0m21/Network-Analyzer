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
            return _connections.Count + 1;
        }

        /// <summary>
        ///     Get new packet id for connection
        /// </summary>
        /// <param name="connectionId">Connection id</param>
        /// <returns>New packet id for connection</returns>
        public static long GetConnectionPacketId(long connectionId)
        {
            ConnectionModel connection = _connections.FirstOrDefault(c => c.Id == connectionId);
            return connection.ConnectionPackets.Count + 1;
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
                // TODO: Сделать ивент по приходу новых соединений
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

                // TODO: Сделать ивент по приходу новых пакетов
                // Этот ивент будет служить перехватчиком для редактирования пакетов
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
                // TODO: Сделать ивент по приходу разрыва соединения
                // Если мы ждем пакет от сервера и нам пришел дистконнект то выходим из ожидания
                // Служит так же для перехвата и редактирования пакетов
            }
        }
    }
}