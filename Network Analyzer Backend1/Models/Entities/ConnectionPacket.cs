using Network_Analyzer_Backend.Models.Entities.Enum;

namespace Network_Analyzer_Backend.Models.Entities
{
    /// <summary>
    ///     This base class connection packet
    /// </summary>
    public class ConnectionPacket
    {
        /// <summary>
        ///     Identity packet
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Identity connection
        /// </summary>
        public long ConnectionId { get; set; }

        /// <summary>
        ///     Data has array bytes
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Type packet connection
        /// </summary>
        public ConnectionPacketType Type { get; set; }

        /// <summary>
        ///     Mark that connection packet is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Connection
        /// </summary>
        public Connection Connection { get; set; }
    }
}