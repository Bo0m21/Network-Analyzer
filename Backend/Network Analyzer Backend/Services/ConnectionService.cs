using System;
using System.Collections.Generic;
using System.Linq;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Database;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly DatabaseContext _databaseContext;

        public ConnectionService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get connection
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Connection GetConnection(long userId, long id)
        {
            Connection connection = _databaseContext.Connections.FirstOrDefault(c => c.UserId == userId && c.Id == id);

            if (connection == null)
            {
                throw new Exception("Connection not found");
            }

            return connection;
        }

        /// <summary>
        ///     Get all connections by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Connection> GetConnections(long userId)
        {
            return _databaseContext.Connections.Where(c => c.UserId == userId);
        }

        /// <summary>
        ///     Create connection
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public Connection Create(Connection connection)
        {
            connection.Created = DateTime.Now;

            _databaseContext.Connections.Add(connection);
            _databaseContext.SaveChanges();

            return connection;
        }

        /// <summary>
        ///     Update connection
        /// </summary>
        /// <param name="connectionParam"></param>
        public void Update(Connection connectionParam)
        {
            Connection connection = _databaseContext.Connections.Find(connectionParam.Id);

            if (connection == null)
            {
                throw new Exception("Connection not found");
            }

            // Update connection properties
            connection.Disconnected = DateTime.Now;

            _databaseContext.Connections.Update(connection);
            _databaseContext.SaveChanges();
        }

        /// <summary>
        ///     Delete connection
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            Connection connection = _databaseContext.Connections.FirstOrDefault(u => u.Id == id);

            if (connection == null)
            {
                throw new Exception("Connection not found");
            }

            connection.IsDeleted = true;
            _databaseContext.SaveChanges();
        }
    }
}