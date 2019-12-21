using System;
using System.Net;
using System.Net.Sockets;

namespace Network_Analyzer_WinForms.Network.Handlers
{
    /// <summary>Defines the signature of the method that's called when the SOCKS negotiation is complete.</summary>
    /// <param name="success">Indicates whether the negotiation was successful or not.</param>
    /// <param name="remote">The connection with the remote server.</param>
    internal delegate void NegotiationCompleteDelegate(bool success, Socket remote);

    /// <summary>Implements a specific version of the SOCKS protocol.</summary>
    internal abstract class SocksHandler
    {
        /// <summary>Holds the address of the method to call when the SOCKS negotiation is complete.</summary>
        private readonly NegotiationCompleteDelegate m_Signaler;

        /// <summary>Holds the value of the Connection property.</summary>
        private Socket m_Connection;

        /// <summary>Holds the value of the RemoteConnection property.</summary>
        private Socket m_RemoteConnection;

        /// <summary>Holds the value of the Username property.</summary>
        private string m_Username;

        /// <summary>Initializes a new instance of the SocksHandler class.</summary>
        /// <param name="clientConnection">The connection with the client.</param>
        /// <param name="callback">The method to call when the SOCKS negotiation is complete.</param>
        /// <exception cref="ArgumentNullException"><c>Callback</c> is null.</exception>
        public SocksHandler(Socket clientConnection, NegotiationCompleteDelegate callback)
        {
            Connection = clientConnection;
            m_Signaler = callback ?? throw new ArgumentNullException();
        }

        /// <summary>Gets or sets the username of the SOCKS user.</summary>
        /// <value>A String representing the username of the logged on user.</value>
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        internal string Username
        {
            get => m_Username;
            set => m_Username = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets or sets the connection with the client.</summary>
        /// <value>A Socket representing the connection between the proxy server and the SOCKS client.</value>
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        protected Socket Connection
        {
            get => m_Connection;
            set => m_Connection = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets a buffer that can be used when receiving bytes from the client.</summary>
        /// <value>A byte array that can be used when receiving bytes from the client.</value>
        protected byte[] Buffer { get; } = new byte[1024];

        /// <summary>Gets or sets a byte array that can be used to store received bytes from the client.</summary>
        /// <value>A byte array that can be used to store bytes from the client.</value>
        protected byte[] Bytes { get; set; }

        /// <summary>Gets or sets the connection with the remote host.</summary>
        /// <value>A Socket representing the connection between the proxy server and the remote host.</value>
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        protected Socket RemoteConnection
        {
            get => m_RemoteConnection;
            set
            {
                m_RemoteConnection = value;

                try
                {
                    m_RemoteConnection.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
                }
                catch
                {
                    // ignored
                }
            }
        }

        /// <summary>Gets or sets the socket that is used to accept incoming connections.</summary>
        /// <value>A Socket that is used to accept incoming connections.</value>
        protected Socket AcceptSocket { get; set; }

        /// <summary>Gets or sets the IP address of the requested remote server.</summary>
        /// <value>An IPAddress object specifying the address of the requested remote server.</value>
        protected IPAddress RemoteBindIp { get; set; }

        /// <summary>Closes the listening socket if present, and signals the parent object that SOCKS negotiation is complete.</summary>
        /// <param name="success">Indicates whether the SOCKS negotiation was successful or not.</param>
        protected void Dispose(bool success)
        {
            AcceptSocket?.Close();
            m_Signaler(success, RemoteConnection);
        }

        /// <summary>Starts accepting bytes from the client.</summary>
        public void StartNegotiating()
        {
            try
            {
                Connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnReceiveBytes, Connection);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when we receive some bytes from the client.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected void OnReceiveBytes(IAsyncResult ar)
        {
            try
            {
                int countReturn = Connection.EndReceive(ar);
                if (countReturn <= 0)
                    Dispose(false);
                AddBytes(Buffer, countReturn);
                if (IsValidRequest(Bytes))
                    ProcessRequest(Bytes);
                else
                    Connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnReceiveBytes, Connection);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when an OK reply has been sent to the client.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected void OnDisposeGood(IAsyncResult ar)
        {
            try
            {
                if (Connection.EndSend(ar) > 0)
                {
                    Dispose(true);
                    return;
                }
            }
            catch
            {
                // ignored
            }

            Dispose(false);
        }

        /// <summary>Called when a negative reply has been sent to the client.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected void OnDisposeBad(IAsyncResult ar)
        {
            try
            {
                Connection.EndSend(ar);
            }
            catch
            {
                // ignored
            }

            Dispose(false);
        }

        /// <summary>Adds some bytes to a byte aray.</summary>
        /// <param name="newBytes">The new bytes to add.</param>
        /// <param name="cnt">The number of bytes to add.</param>
        protected void AddBytes(byte[] newBytes, int cnt)
        {
            if (cnt <= 0 || newBytes == null || cnt > newBytes.Length)
                return;
            if (Bytes == null)
            {
                Bytes = new byte[cnt];
            }
            else
            {
                byte[] tmp = Bytes;
                Bytes = new byte[Bytes.Length + cnt];
                Array.Copy(tmp, 0, Bytes, 0, tmp.Length);
            }

            Array.Copy(newBytes, 0, Bytes, Bytes.Length - cnt, cnt);
        }

        /// <summary>Called when the AcceptSocket should start accepting incoming connections.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected void OnStartAccept(IAsyncResult ar)
        {
            try
            {
                if (Connection.EndSend(ar) <= 0)
                    Dispose(false);
                else
                    AcceptSocket.BeginAccept(OnAccept, AcceptSocket);
            }
            catch
            {
                Dispose(false);
            }
        }

        /// <summary>Called when there's an incoming connection in the AcceptSocket queue.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        protected abstract void OnAccept(IAsyncResult ar);

        /// <summary>Sends a reply to the client connection and disposes it afterwards.</summary>
        /// <param name="value">A byte that contains the reply code to send to the client.</param>
        protected abstract void Dispose(byte value);

        /// <summary>Checks whether a specific request is a valid SOCKS request or not.</summary>
        /// <param name="request">The request array to check.</param>
        /// <returns>True is the specified request is valid, false otherwise</returns>
        protected abstract bool IsValidRequest(byte[] request);

        /// <summary>Processes a SOCKS request from a client.</summary>
        /// <param name="request">The request to process.</param>
        protected abstract void ProcessRequest(byte[] request);
    }
}