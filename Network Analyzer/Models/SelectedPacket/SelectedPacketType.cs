using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Analyzer.Models.Enums
{
    /// <summary>
    /// Selected type packet connection
    /// </summary>
    public enum SelectedPacketType
    {
        AllPackets = 0,
        ClientToServer = 1,
        ServerToClient = 2
    }
}
