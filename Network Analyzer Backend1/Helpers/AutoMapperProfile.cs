using AutoMapper;
using Network_Analyzer_Backend.Models.ConnectionPackets;
using Network_Analyzer_Backend.Models.Connections;
using Network_Analyzer_Backend.Models.Entities;
using Network_Analyzer_Backend.Models.Users;

namespace Network_Analyzer_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ConnectionPacket, ConnectionPacketViewModel>();
            CreateMap<ConnectionPacketViewModel, ConnectionPacket>();

            CreateMap<Connection, ConnectionViewModel>();
            CreateMap<ConnectionViewModel, Connection>();

            CreateMap<User, UserAuthReqModel>();
            CreateMap<UserAuthReqModel, User>();

            CreateMap<User, UserAuthResModel>();
            CreateMap<UserAuthResModel, User>();

            CreateMap<User, UserEditModel>();
            CreateMap<UserEditModel, User>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}