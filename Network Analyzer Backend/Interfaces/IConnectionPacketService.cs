using System.Collections.Generic;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Interfaces
{
    public interface IConnectionPacketService
    {
        ConnectionPacket GetConnectionPacket(long userId, long connectionId, long id);
        IEnumerable<ConnectionPacket> GetConnectionPackets(long userId, long connectionId);
        ConnectionPacket Create(ConnectionPacket connectionPacket);
        void Update(ConnectionPacket connectionPacketParam);
        void Delete(long id);
    }
}