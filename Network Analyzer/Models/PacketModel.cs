using Network_Analyzer.Models.Enums;

namespace Network_Analyzer.Models
{
    /// <summary>
    ///     This base class packet
    /// </summary>
    public class PacketModel
    {
        /// <summary>
        ///     Identity packet
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Data has array bytes
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Type packet connection
        /// </summary>
        public PacketType Type { get; set; }

        /// <summary>
        ///     Flag if this is packet was decrypted
        /// </summary>
        public bool IsDecrypted { get; set; }

        /// <summary>
        ///     Unique identity packet
        /// </summary>
        public string Opcode { get; set; }
    }
}