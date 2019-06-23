using System;
using System.Net;
using System.Net.Sockets;
using Network_Analyzer.Network.Listeners.Authentication;
using Network_Analyzer.Network.Listeners.Clients;

namespace Network_Analyzer.Network.Listeners
{
    /// <summary>Listens on a specific port on the proxy server for incoming SOCKS4 and SOCKS5 requests.</summary>
    /// <remarks>This class also implements the SOCKS4a protocol.</remarks>
    public sealed class SocksListener : Listener
    {
        /// <summary>Initializes a new instance of the SocksListener class.</summary>
        /// <param name="port">The port to listen on.</param>
        /// <remarks>The SocksListener will listen on all available network cards and it will not use an AuthenticationList.</remarks>
        public SocksListener(int port) : this(IPAddress.Any, port, null)
        {
        }

        /// <summary>Initializes a new instance of the SocksListener class.</summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="address">The address to listen on. You can specify IPAddress.Any to listen on all installed network cards.</param>
        /// <remarks>
        ///     For the security of your server, try to avoid to listen on every network card (IPAddress.Any). Listening on a
        ///     local IP address is usually sufficient and much more secure.
        /// </remarks>
        /// <remarks>The SocksListener object will not use an AuthenticationList.</remarks>
        public SocksListener(IPAddress address, int port) : this(address, port, null)
        {
        }

        /// <summary>Initializes a new instance of the SocksListener class.</summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="authList">
        ///     The list of valid login/password combinations. If you do not need password authentication, set
        ///     this parameter to null.
        /// </param>
        /// <remarks>The SocksListener will listen on all available network cards.</remarks>
        public SocksListener(int port, AuthenticationList authList) : this(IPAddress.Any, port, authList)
        {
        }

        /// <summary>Initializes a new instance of the SocksListener class.</summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="address">The address to listen on. You can specify IPAddress.Any to listen on all installed network cards.</param>
        /// <param name="authList">
        ///     The list of valid login/password combinations. If you do not need password authentication, set
        ///     this parameter to null.
        /// </param>
        /// <remarks>
        ///     For the security of your server, try to avoid to listen on every network card (IPAddress.Any). Listening on a
        ///     local IP address is usually sufficient and much more secure.
        /// </remarks>
        public SocksListener(IPAddress address, int port, AuthenticationList authList) : base(port, address)
        {
            AuthList = authList;
        }

        /// <summary>Gets or sets the AuthenticationList to be used when a SOCKS5 client connects.</summary>
        /// <value>An AuthenticationList that is to be used when a SOCKS5 client connects.</value>
        /// <remarks>This value can be null.</remarks>
        private AuthenticationList AuthList { get; }

        /// <summary>Called when there's an incoming client connection waiting to be accepted.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        public override void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket socket = ListenSocket.EndAccept(ar);
                if (socket != null)
                {
                    SocksClient client = new SocksClient(socket, RemoveClient, AuthList);
                    AddClient(client);

                    client.StartHandshake();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                //Restart Listening
                ListenSocket.BeginAccept(OnAccept, ListenSocket);
            }
            catch
            {
                Dispose();
            }
        }
    }
}