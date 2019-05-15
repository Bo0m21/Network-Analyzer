using System;
using System.Net.Sockets;
using Network_Analyzer.Network.Authentication;
using Network_Analyzer.Network.Handlers;

namespace Network_Analyzer.Network.Clients
{
    /// <summary>Relays data between a remote host and a local client, using the SOCKS protocols.</summary>
    /// <remarks>This class implements the SOCKS4, SOCKS4a and SOCKS5 protocols.</remarks>
    /// <remarks>
    ///     If the MustAuthenticate property is set, only SOCKS5 connections are allowed and the AuthList parameter of the
    ///     constructor should not be null.
    /// </remarks>
    public sealed class SocksClient : Client
    {
        /// <summary>Holds the value of the Handler property.</summary>
        private SocksHandler m_Handler;

        /// <summary>Initializes a new instance of the SocksClient class.</summary>
        /// <param name="clientSocket">The Socket connection between this proxy server and the local client.</param>
        /// <param name="destroyer">The method to be called when this SocksClient object disconnects from the local client and the remote server.</param>
        /// <param name="authList">The list with valid username/password combinations.</param>
        /// <remarks>If the AuthList is non-null, every client has to authenticate before he can use this proxy server to relay data. If it is null, the clients don't have to authenticate.</remarks>
        public SocksClient(Socket clientSocket, DestroyDelegate destroyer, AuthenticationList authList) : base(clientSocket, destroyer)
        {
            AuthList = authList;
        }

        /// <summary>Gets or sets the SOCKS handler to be used when communicating with the client.</summary>
        /// <value>The SocksHandler to be used when communicating with the client.</value>
        internal SocksHandler Handler
        {
            get => m_Handler;
            set => m_Handler = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets or sets the SOCKS handler to be used when communicating with the client.</summary>
        /// <value>The SocksHandler to be used when communicating with the client.</value>
        private bool MustAuthenticate { get; set; } = false;

        /// <summary>Gets or sets the AuthenticationList to use when a computer tries to authenticate on the proxy server.</summary>
        /// <value>An instance of the AuthenticationList class that contains all the valid username/password combinations.</value>
        private AuthenticationList AuthList { get; }

        /// <summary>Starts communication with the client.</summary>
        public void StartHandshake()
        {
            try
            {
                ClientSocket.BeginReceive(Buffer, 0, 1, SocketFlags.None, OnStartSocksProtocol, ClientSocket);
            }
            catch
            {
                Dispose();
            }
        }

        /// <summary>Called when we have received some data from the client.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnStartSocksProtocol(IAsyncResult ar)
        {
            try
            {
                var countReturn = ClientSocket.EndReceive(ar);
                if (countReturn <= 0)
                {
                    Dispose();
                    return;
                }

                if (Buffer[0] == 4) // SOCKS4 Protocol
                {
                    if (MustAuthenticate)
                    {
                        Dispose();
                        return;
                    }

                    Handler = new Socks4Handler(ClientSocket, OnEndSocksProtocol);
                }
                else if (Buffer[0] == 5) // SOCKS5 Protocol
                {
                    if (MustAuthenticate && AuthList == null)
                    {
                        Dispose();
                        return;
                    }

                    Handler = new Socks5Handler(ClientSocket, OnEndSocksProtocol, AuthList);
                }
                else
                {
                    Dispose();
                    return;
                }

                Handler.StartNegotiating();
            }
            catch
            {
                Dispose();
            }
        }

        /// <summary>
        ///     Called when the SOCKS protocol has ended. We can no start relaying data, if the SOCKS authentication was
        ///     successful.
        /// </summary>
        /// <param name="success">Specifies whether the SOCKS negotiation was successful or not.</param>
        /// <param name="remote">The connection with the remote server.</param>
        private void OnEndSocksProtocol(bool success, Socket remote)
        {
            DestinationSocket = remote;

            if (success)
                StartRelay();
            else
                Dispose();
        }
    }
}