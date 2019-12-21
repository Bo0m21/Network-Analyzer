using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Network_Analyzer_WinForms.Network.Authentication;

namespace Network_Analyzer_WinForms.Network.Handlers
{
    /// <summary>Implements the SOCKS5 protocol.</summary>
    internal sealed class Socks5Handler : SocksHandler
    {
        /// <summary>Holds the value of the AuthMethod property.</summary>
        private AuthBase m_AuthMethod;

        /// <summary>Initializes a new instance of the Socks5Handler class.</summary>
        /// <param name="clientConnection">The connection with the client.</param>
        /// <param name="callback">The method to call when the SOCKS negotiation is complete.</param>
        /// <param name="authList">The authentication list to use when clients connect.</param>
        /// <exception cref="ArgumentNullException"><c>Callback</c> is null.</exception>
        /// <remarks>
        ///     If the AuthList parameter is null, no authentication will be required when a client connects to the proxy
        ///     server.
        /// </remarks>
        public Socks5Handler(Socket clientConnection, NegotiationCompleteDelegate callback, AuthenticationList authList)
            : base(clientConnection, callback)
        {
            AuthList = authList;
        }

        /// <summary>Initializes a new instance of the Socks5Handler class.</summary>
        /// <param name="clientConnection">The connection with the client.</param>
        /// <param name="callback">The method to call when the SOCKS negotiation is complete.</param>
        /// <exception cref="ArgumentNullException"><c>Callback</c> is null.</exception>
        public Socks5Handler(Socket clientConnection, NegotiationCompleteDelegate callback) : this(clientConnection,
            callback, null)
        {
        }

        /// <summary>Gets or sets the the AuthBase object to use when trying to authenticate the SOCKS client.</summary>
        /// <value>The AuthBase object to use when trying to authenticate the SOCKS client.</value>
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        private AuthBase AuthMethod
        {
            get => m_AuthMethod;
            set => m_AuthMethod = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets or sets the AuthenticationList object to use when trying to authenticate the SOCKS client.</summary>
        /// <value>The AuthenticationList object to use when trying to authenticate the SOCKS client.</value>
        private AuthenticationList AuthList { get; }

        /// <summary>Checks whether a specific request is a valid SOCKS request or not.</summary>
        /// <param name="request">The request array to check.</param>
        /// <returns>True is the specified request is valid, false otherwise</returns>
        protected override bool IsValidRequest(byte[] request)
        {
            try
            {
                return request.Length == request[0] + 1;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Processes a SOCKS request from a client and selects an authentication method.</summary>
        /// <param name="request">The request to process.</param>
        protected override void ProcessRequest(byte[] request)
        {
            try
            {
                byte countReturn = 255;
                for (int Cnt = 1; Cnt < request.Length; Cnt++)
                    if (request[Cnt] == 0 && AuthList == null)
                    {
                        //0 = No authentication
                        countReturn = 0;
                        AuthMethod = new AuthNone();
                        break;
                    }
                    else if (request[Cnt] == 2 && AuthList != null)
                    {
                        //2 = user/pass
                        countReturn = 2;
                        AuthMethod = new AuthUserPass(AuthList);
                        if (AuthList != null)
                            break;
                    }

                Connection.BeginSend(new byte[] {5, countReturn}, 0, 2, SocketFlags.None, OnAuthSent, Connection);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when client has been notified of the selected authentication method.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnAuthSent(IAsyncResult ar)
        {
            try
            {
                if (Connection.EndSend(ar) <= 0 || AuthMethod == null)
                {
                    Dispose(false);
                    return;
                }

                AuthMethod.StartAuthentication(Connection, OnAuthenticationComplete);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when the authentication is complete.</summary>
        /// <param name="success">Indicates whether the authentication was successful ot not.</param>
        private void OnAuthenticationComplete(bool success)
        {
            try
            {
                if (success)
                {
                    Bytes = null;
                    Connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnRecvRequest, Connection);
                }
                else
                {
                    Dispose(false);
                }
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when we received the request of the client.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnRecvRequest(IAsyncResult ar)
        {
            try
            {
                int Ret = Connection.EndReceive(ar);
                if (Ret <= 0)
                {
                    Dispose(false);
                    return;
                }

                AddBytes(Buffer, Ret);
                if (IsValidQuery(Bytes))
                    ProcessQuery(Bytes);
                else
                    Connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnRecvRequest, Connection);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Checks whether a specified query is a valid query or not.</summary>
        /// <param name="query">The query to check.</param>
        /// <returns>True if the query is valid, false otherwise.</returns>
        private bool IsValidQuery(byte[] query)
        {
            try
            {
                switch (query[3])
                {
                    case 1: //IPv4 address
                        return query.Length == 10;
                    case 3: //Domain name
                        return query.Length == query[4] + 7;
                    case 4: //IPv6 address
                        //Not supported
                        Dispose(8);
                        return false;
                    default:
                        Dispose(false);
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Processes a received query.</summary>
        /// <param name="query">The query to process.</param>
        private void ProcessQuery(byte[] query)
        {
            try
            {
                switch (query[1])
                {
                    case 1: //CONNECT
                        IPAddress RemoteIp = null;
                        int RemotePort = 0;
                        if (query[3] == 1)
                        {
                            RemoteIp = IPAddress.Parse(query[4] + "." + query[5] + "." + query[6] + "." + query[7]);
                            RemotePort = query[8] * 256 + query[9];
                        }
                        else if (query[3] == 3)
                        {
                            RemoteIp = Dns.Resolve(Encoding.ASCII.GetString(query, 5, query[4])).AddressList[0];
                            RemotePort = query[4] + 5;
                            RemotePort = query[RemotePort] * 256 + query[RemotePort + 1];
                        }

                        RemoteConnection = new Socket(RemoteIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        RemoteConnection.BeginConnect(new IPEndPoint(RemoteIp, RemotePort), OnConnected,
                            RemoteConnection);
                        break;
                    case 2: //BIND
                        byte[] Reply = new byte[10];
                        long LocalIp = Listener.GetLocalExternalIp().Address;
                        AcceptSocket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        AcceptSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
                        AcceptSocket.Listen(50);
                        Reply[0] = 5; //Version 5
                        Reply[1] = 0; //Everything is ok :)
                        Reply[2] = 0; //Reserved
                        Reply[3] = 1; //We're going to send a IPv4 address
                        Reply[4] = (byte) (LocalIp % 256); //IP Address/1
                        Reply[5] = (byte) (LocalIp % 65536 / 256); //IP Address/2
                        Reply[6] = (byte) (LocalIp % 16777216 / 65536); //IP Address/3
                        Reply[7] = (byte) (LocalIp / 16777216); //IP Address/4
                        Reply[8] = (byte) (((IPEndPoint) AcceptSocket.LocalEndPoint).Port / 256); //Port/1
                        Reply[9] = (byte) (((IPEndPoint) AcceptSocket.LocalEndPoint).Port % 256); //Port/2
                        Connection.BeginSend(Reply, 0, Reply.Length, SocketFlags.None, OnStartAccept, Connection);
                        break;
                    case 3: //ASSOCIATE
                        //ASSOCIATE is not implemented (yet?)
                        Dispose(7);
                        break;
                    default:
                        Dispose(7);
                        break;
                }
            }
            catch
            {
                Dispose(1);
            }
        }

        /// <summary>Called when we're successfully connected to the remote host.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnConnected(IAsyncResult ar)
        {
            try
            {
                RemoteConnection.EndConnect(ar);
                Dispose(0);
            }
            catch
            {
                Dispose(1);
            }
        }

        /// <summary>Called when there's an incoming connection in the AcceptSocket queue.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected override void OnAccept(IAsyncResult ar)
        {
            try
            {
                RemoteConnection = AcceptSocket.EndAccept(ar);
                AcceptSocket.Close();
                AcceptSocket = null;
                Dispose(0);
            }
            catch
            {
                Dispose(1);
            }
        }

        /// <summary>Sends a reply to the client connection and disposes it afterwards.</summary>
        /// <param name="value">A byte that contains the reply code to send to the client.</param>
        protected override void Dispose(byte value)
        {
            byte[] ToSend;
            try
            {
                ToSend = new byte[]
                {
                    5, value, 0, 1,
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Address.Address % 256),
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Address.Address % 65536 / 256),
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Address.Address % 16777216 / 65536),
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Address.Address / 16777216),
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Port / 256),
                    (byte) (((IPEndPoint) RemoteConnection.LocalEndPoint).Port % 256)
                };
            }
            catch
            {
                ToSend = new byte[] {5, 1, 0, 1, 0, 0, 0, 0, 0, 0};
            }

            try
            {
                Connection.BeginSend(ToSend, 0, ToSend.Length, SocketFlags.None,
                    ToSend[1] == 0 ? OnDisposeGood : new AsyncCallback(OnDisposeBad), Connection);
            }
            catch
            {
                Dispose(false);
            }
        }
    }
}