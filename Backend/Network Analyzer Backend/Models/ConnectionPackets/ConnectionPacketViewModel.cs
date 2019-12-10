using Network_Analyzer_Database.Enums;

namespace Network_Analyzer_Backend.Models.ConnectionPackets
{
    public class ConnectionPacketViewModel
    {
        public long Id { get; set; }
        public byte[] Data { get; set; }
        public ConnectionPacketType Type { get; set; }
    }
}