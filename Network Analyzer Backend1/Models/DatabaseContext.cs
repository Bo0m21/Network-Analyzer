using Microsoft.EntityFrameworkCore;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Models
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for User and Token
            modelBuilder.Entity<User>()
                .HasOne(a => a.Token)
                .WithOne(a => a.User)
                .HasForeignKey<Token>(c => c.UserId);
        }

        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionPacket> ConnectionPackets { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}