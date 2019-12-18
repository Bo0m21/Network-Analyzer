using System;

namespace Network_Analyzer_Backend.Models.Connections
{
    public class ConnectionEditReqModel
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Disconnected { get; set; }
    }
}