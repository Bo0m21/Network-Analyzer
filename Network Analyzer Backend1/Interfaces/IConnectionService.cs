using System.Collections.Generic;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Interfaces
{
    public interface IConnectionService
    {
        Connection GetConnection(long userId, long id);
        IEnumerable<Connection> GetConnections(long userId);
        Connection Create(Connection connection);
        void Update(Connection connectionParam);
        void Delete(long id);
    }
}