using System;

namespace Network_Analyzer_Backend.Models.Connections
{
    public class ConnectionViewModel
    {
        public long Id { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public long Send { get; set; }
        public long Received { get; set; }
        public DateTime? Created { get; set; }
        public bool IsDisconnected { get; set; }
    }
}