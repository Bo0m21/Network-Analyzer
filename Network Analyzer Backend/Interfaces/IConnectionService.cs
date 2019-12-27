using System.Collections.Generic;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Interfaces
{
    public interface IConnectionService
    {
        Connection GetConnection(long userId, long id);
        IEnumerable<Connection> GetConnections(long userId);
        int GetConnectionsCount(long userId);
        Connection Create(Connection connection);
        void Update(Connection connectionParam);
        void CloseConnection(long userId, long id);
        void CloseConnections(long userId);
        void Delete(long id);
    }
}