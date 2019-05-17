using System.Collections.Generic;

namespace Network_Analyzer.Models
{
    /// <summary>
    ///     This class has information and packets for connection
    /// </summary>
    public class ConnectionModel
    {
        public ConnectionModel()
        {
            ConnectionPackets = new List<PacketModel>();
            DecryptedPackets = new List<PacketModel>();
        }

        /// <summary>
        ///     Identity connection
        /// </summary>
        public long Id { get; set; }

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
        ///     Gets the packets in the connection.
        /// </summary>
        public List<PacketModel> ConnectionPackets { get; set; }

        /// <summary>
        ///     Gets the decrypted packets in the connection
        /// </summary>
        public List<PacketModel> DecryptedPackets { get; set; }
    }
}