using Network_Analyzer_Database.Enums;

namespace Network_Analyzer_Backend.Models.ConnectionPackets
{
    public class ConnectionPacketEditReqModel
    {
        public byte[] Data { get; set; }
        public ConnectionPacketType Type { get; set; }
    }
}