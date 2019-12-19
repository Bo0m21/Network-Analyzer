using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetUser(long id);
        User Create(User user, string password);
        void Update(User user, string password);
        void Delete(long id);
    }
}