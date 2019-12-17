using AutoMapper;
using Network_Analyzer_Backend.Models.Users;
using Network_Analyzer_Database.Models;

namespace Network_Analyzer_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<ConnectionPacket, ConnectionPacketViewModel>();
            //CreateMap<ConnectionPacketViewModel, ConnectionPacket>();

            //CreateMap<Connection, ConnectionViewModel>();
            //CreateMap<ConnectionViewModel, Connection>();

            CreateMap<User, UserAuthReqModel>();
            CreateMap<UserAuthReqModel, User>();

            CreateMap<User, UserAuthResModel>();
            CreateMap<UserAuthResModel, User>();

            CreateMap<User, UserEditReqModel>();
            CreateMap<UserEditReqModel, User>();

            CreateMap<User, UserViewResModel>();
            CreateMap<UserViewResModel, User>();
        }
    }
}