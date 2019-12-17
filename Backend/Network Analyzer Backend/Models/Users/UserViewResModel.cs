using Network_Analyzer_Backend.Models.BaseModels;

namespace Network_Analyzer_Backend.Models.Users
{
    public class UserViewResModel : BaseResponseModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}