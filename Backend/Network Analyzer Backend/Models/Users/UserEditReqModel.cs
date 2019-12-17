using Network_Analyzer_Backend.Models.BaseModels;

namespace Network_Analyzer_Backend.Models.Users
{
    public class UserEditReqModel : BaseRequestModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}