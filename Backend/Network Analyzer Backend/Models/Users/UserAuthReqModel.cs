using Network_Analyzer_Backend.Models.BaseModels;

namespace Network_Analyzer_Backend.Models.Users
{
    public class UserAuthReqModel : BaseRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}