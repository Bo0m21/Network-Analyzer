using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network_Analyzer_WinForms.Network.Handlers
{
    /// <summary>Implements the SOCKS4 and SOCKS4a protocols.</summary>
    internal sealed class Socks4Handler : SocksHandler
    {
        /// <summary>Initializes a new instance of the Socks4Handler class.</summary>
        /// <param name="clientConnection">The connection with the client.</param>
        /// <param name="callback">The method to call when the SOCKS negotiation is complete.</param>
        /// <exception cref="ArgumentNullException"><c>Callback</c> is null.</exception>
        public Socks4Handler(Socket clientConnection, NegotiationCompleteDelegate callback) : base(clientConnection,
            callback)
        {
        }

        /// <summary>Checks whether a specific request is a valid SOCKS request or not.</summary>
        /// <param name="request">The request array to check.</param>
        /// <returns>True is the specified request is valid, false otherwise</returns>
        protected override bool IsValidRequest(byte[] request)
        {
            try
            {
                if (request[0] != 1 && request[0] != 2)
                {
                    //CONNECT or BIND
                    Dispose(false);
                }
                else
                {
                    if (request[3] == 0 && request[4] == 0 && request[5] == 0 && request[6] != 0)
                    {
                        //Use remote DNS
                        int countReturn = Array.IndexOf(request, (byte) 0, 7);
                        if (countReturn > -1)
                            return Array.IndexOf(request, (byte) 0, countReturn + 1) != -1;
                    }
                    else
                    {
                        return Array.IndexOf(request, (byte) 0, 7) != -1;
                    }
                }
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>Processes a SOCKS request from a client.</summary>
        /// <param name="request">The request to process.</param>
        protected override void ProcessRequest(byte[] request)
        {
            try
            {
                if (request[0] == 1)
                {
                    // CONNECT
                    IPAddress RemoteIp;
                    int RemotePort = request[1] * 256 + request[2];
                    int countReturn = Array.IndexOf(request, (byte) 0, 7);
                    Username = Encoding.ASCII.GetString(request, 7, countReturn - 7);
                    if (request[3] == 0 && request[4] == 0 && request[5] == 0 && request[6] != 0)
                    {
                        // Use remote DNS
                        countReturn = Array.IndexOf(request, (byte) 0, countReturn + 1);
                        RemoteIp = Dns
                            .Resolve(Encoding.ASCII.GetString(request, Username.Length + 8,
                                countReturn - Username.Length - 8))
                            .AddressList[0];
                    }
                    else
                    {
                        //Do not use remote DNS
                        RemoteIp = IPAddress.Parse(request[3] + "." + request[4] + "." + request[5] + "." + request[6]);
                    }

                    RemoteConnection = new Socket(RemoteIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    RemoteConnection.BeginConnect(new IPEndPoint(RemoteIp, RemotePort), OnConnected, RemoteConnection);
                }
                else if (request[0] == 2)
                {
                    // BIND
                    byte[] Reply = new byte[8];
                    long LocalIp = Listener.GetLocalExternalIp().Address;
                    AcceptSocket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    AcceptSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
                    AcceptSocket.Listen(50);
                    RemoteBindIp = IPAddress.Parse(request[3] + "." + request[4] + "." + request[5] + "." + request[6]);
                    Reply[0] = 0; //Reply version 0
                    Reply[1] = 90; //Everything is ok :)
                    Reply[2] = (byte) (((IPEndPoint) AcceptSocket.LocalEndPoint).Port / 256); //Port/1
                    Reply[3] = (byte) (((IPEndPoint) AcceptSocket.LocalEndPoint).Port % 256); //Port/2
                    Reply[4] = (byte) (LocalIp % 256); //IP Address/1
                    Reply[5] = (byte) (LocalIp % 65536 / 256); //IP Address/2
                    Reply[6] = (byte) (LocalIp % 16777216 / 65536); //IP Address/3
                    Reply[7] = (byte) (LocalIp / 16777216); //IP Address/4
                    Connection.BeginSend(Reply, 0, Reply.Length, SocketFlags.None, OnStartAccept, Connection);
                }
            }
            catch
            {
                Dispose(91);
            }
        }

        /// <summary>Called when we're successfully connected to the remote host.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnConnected(IAsyncResult ar)
        {
            try
            {
                RemoteConnection.EndConnect(ar);
                Dispose(90);
            }
            catch
            {
                Dispose(91);
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
                    0, value, (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Port / 256),
                    (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Port % 256),
                    (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Address.Address % 256),
                    (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Address.Address % 65536 / 256),
                    (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Address.Address % 16777216 / 65536),
                    (byte) (((IPEndPoint) RemoteConnection.RemoteEndPoint).Address.Address / 16777216)
                };
            }
            catch
            {
                ToSend = new byte[] {0, 91, 0, 0, 0, 0, 0, 0};
            }

            try
            {
                Connection.BeginSend(ToSend, 0, ToSend.Length, SocketFlags.None,
                    ToSend[1] == 90 ? OnDisposeGood : new AsyncCallback(OnDisposeBad), Connection);
            }
            catch
            {
                Dispose(false);
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
                if (RemoteBindIp.Equals(((IPEndPoint) RemoteConnection.RemoteEndPoint).Address))
                    Dispose(90);
                else
                    Dispose(91);
            }
            catch
            {
                Dispose(91);
            }
        }
    }
}