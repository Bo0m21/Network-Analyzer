﻿using Network_Analyzer_Backend.Models.BaseModels;

namespace Network_Analyzer_Backend.Models.Users
{
    public class UserAuthResModel : BaseResponseModel
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}