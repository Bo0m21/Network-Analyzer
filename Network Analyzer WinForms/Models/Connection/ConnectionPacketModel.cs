﻿namespace Network_Analyzer_WinForms.Models.Connection
{
    /// <summary>
    ///     This base class connection packet
    /// </summary>
    public class ConnectionPacketModel
    {
        /// <summary>
        ///     Identity packet
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Database identity connection
        /// </summary>
        public long DatabaseId { get; set; }

        /// <summary>
        ///     Data has array bytes
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Type packet connection
        /// </summary>
        public ConnectionPacketType Type { get; set; }

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