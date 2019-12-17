using Microsoft.EntityFrameworkCore;
using Network_Analyzer_Database.Models;
using System.Linq;

namespace Network_Analyzer_Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();

            var userBase = Users.FirstOrDefault(u => u.Username == "string");

            if (userBase == null)
            {
                using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    Users.Add(new User()
                    {
                        Username = "string",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string")),
                        PasswordSalt = hmac.Key,
                        Role = "Admin"
                    });

                    this.SaveChanges();
                }
            }

            var userBase1 = Users.FirstOrDefault(u => u.Username == "string1");

            if (userBase1 == null)
            {
                using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    Users.Add(new User()
                    {
                        Username = "string1",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string1")),
                        PasswordSalt = hmac.Key,
                        Role = "Admin"
                    });

                    this.SaveChanges();
                }
            }
        }

        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionPacket> ConnectionPackets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}