using Microsoft.EntityFrameworkCore;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionPacket> ConnectionPackets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}