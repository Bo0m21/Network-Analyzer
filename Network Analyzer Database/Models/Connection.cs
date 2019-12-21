using System;
using System.Collections.Generic;

namespace Network_Analyzer_Database.Models
{
    /// <summary>
    ///     This class has information and packets for connection
    /// </summary>
    public class Connection
    {
        /// <summary>
        ///     Identity connection
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Identity user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///     Source ip and port
        /// </summary>
        public string SourceAddress { get; set; }

        /// <summary>
        ///     Destination ip and port
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        ///     Date that connection is created
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///     Mark that connection is disconnected
        /// </summary>
        public bool IsDisconnected { get; set; }

        /// <summary>
        ///     Mark that connection is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Connection user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        ///     Get all packets in the connection
        /// </summary>
        public List<ConnectionPacket> ConnectionPacket { get; set; }
    }
}