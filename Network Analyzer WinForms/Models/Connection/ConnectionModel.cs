using System.Collections.Generic;

namespace Network_Analyzer_WinForms.Models.Connection
{
    /// <summary>
    ///     This class has information and packets for connection
    /// </summary>
    public class ConnectionModel
    {
        public ConnectionModel()
        {
            ConnectionPackets = new List<ConnectionPacketModel>();
            DecryptedPackets = new List<ConnectionPacketModel>();
        }

        /// <summary>
        ///     Identity connection
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Database identity connection
        /// </summary>
        public long DatabaseId { get; set; }

        /// <summary>
        ///     Source ip and port
        /// </summary>
        /// <returns>Return source ip and port about this connection.</returns>
        public string SourceAddress { get; set; }

        /// <summary>
        ///     Destination ip and port
        /// </summary>
        /// <returns>Return destination ip and port about this connection.</returns>
        public string DestinationAddress { get; set; }

        /// <summary>
        ///     Count received data
        /// </summary>
        /// <returns>Return count received data about this connection.</returns>
        public long Received { get; set; }

        /// <summary>
        ///     Count send data
        /// </summary>
        /// <returns>Return count send data about this connection.</returns>
        public long Send { get; set; }

        /// <summary>
        ///     Mark that connection is disconnected
        /// </summary>
        /// <returns>Return information disconnected about this connection.</returns>
        public bool IsDisconnected { get; set; }

        /// <summary>
        ///     Mark that connection is disconnected in database
        /// </summary>
        /// <returns>Return information disconnected about this connection in database.</returns>
        public bool IsDatabaseDisconnected { get; set; }

        /// <summary>
        ///     Gets the packets in the connection.
        /// </summary>
        public List<ConnectionPacketModel> ConnectionPackets { get; set; }

        /// <summary>
        ///     Gets the decrypted packets in the connection
        /// </summary>
        public List<ConnectionPacketModel> DecryptedPackets { get; set; }
    }
}