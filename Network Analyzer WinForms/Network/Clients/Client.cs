using System;
using System.Net.Sockets;
using Network_Analyzer_WinForms.Extensions;
using Network_Analyzer_WinForms.Models.Connection;

namespace Network_Analyzer_WinForms.Network.Clients
{
    /// <summary>
    ///     Specifies the basic methods and properties of a <c>Client</c> object. This is class and must be inherited.
    /// </summary>
    /// <remarks>
    ///     The Client class provides base class that represents a connection to a local client and a remote server.
    ///     Descendant classes further specify the protocol that is used between those two connections.
    /// </remarks>
    public abstract class Client : IDisposable
    {
        /// <summary>
        ///     References the callback method to be called when the <c>Client</c> object disconnects from the local client
        ///     and the remote server.
        /// </summary>
        /// <param name="client">The <c>Client</c> that has closed its connections.</param>
        public delegate void DestroyDelegate(Client client);

        /// <summary>Synchronize array list locker.</summary>
        private static readonly object _syncLock = new object();

        /// <summary>Holds the address of the method to call when this client is ready to be destroyed.</summary>
        private readonly DestroyDelegate m_Destroyer;

        /// <summary>Holds the value of the ClientSocket property.</summary>
        private Socket m_ClientSocket;

        /// <summary>Holds the value of the DestinationSocket property.</summary>
        private Socket m_DestinationSocket;

        /// <summary>Initializes a new instance of the Client class.</summary>
        /// <param name="clientSocket">
        ///     The <see cref="Socket">Socket</see> connection between this proxy server and the local
        ///     client.
        /// </param>
        /// <param name="destroyer">
        ///     The callback method to be called when this Client object disconnects from the local client and
        ///     the remote server.
        /// </param>
        public Client(Socket clientSocket, DestroyDelegate destroyer)
        {
            ClientSocket = clientSocket;
            m_Destroyer = destroyer;
        }

        /// <summary>Unique identity Client.</summary>
        /// <returns>Return unique identity about this Client.</returns>
        public long Id { get; set; }

        /// <summary>Gets the buffer to store all the incoming data from the local client.</summary>
        /// <value>An array of bytes that can be used to store all the incoming data from the local client.</value>
        /// <seealso cref="RemoteBuffer" />
        protected byte[] Buffer { get; } = new byte[0x16384];

        /// <summary>Gets the buffer to store all the incoming data from the remote host.</summary>
        /// <value>An array of bytes that can be used to store all the incoming data from the remote host.</value>
        /// <seealso cref="Buffer" />
        protected byte[] RemoteBuffer { get; } = new byte[0x16384];

        /// <summary>Gets or sets the Socket connection between the proxy server and the local client.</summary>
        /// <value>A Socket instance defining the connection between the proxy server and the local client.</value>
        /// <seealso cref="DestinationSocket" />
        internal Socket ClientSocket
        {
            get => m_ClientSocket;
            set
            {
                m_ClientSocket?.Close();
                m_ClientSocket = value;
            }
        }

        /// <summary>Gets or sets the Socket connection between the proxy server and the remote host.</summary>
        /// <value>A Socket instance defining the connection between the proxy server and the remote host.</value>
        /// <seealso cref="ClientSocket" />
        internal Socket DestinationSocket
        {
            get => m_DestinationSocket;
            set
            {
                m_DestinationSocket?.Close();
                m_DestinationSocket = value;
            }
        }

        /// <summary>Disposes of the resources (other than memory) used by the Client.</summary>
        /// <remarks>
        ///     Closes the connections with the local client and the remote host. Once <c>Dispose</c> has been called, this
        ///     object should not be used anymore.
        /// </remarks>
        /// <seealso cref="System.IDisposable" />
        public void Dispose()
        {
            try
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
                // ignored
            }

            try
            {
                DestinationSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
                // ignored
            }

            //Close the sockets
            ClientSocket?.Close();
            DestinationSocket?.Close();

            //Clean up
            ClientSocket = null;
            DestinationSocket = null;

            //Disconnected
            Connections.DisconnectedConnection(Id);

            //Destroyed
            m_Destroyer?.Invoke(this);
        }

        /// <summary>Starts relaying data between the remote host and the local client.</summary>
        /// <remarks>This method should only be called after all protocol specific communication has been finished.</remarks>
        public void StartRelay()
        {
            try
            {
                lock (_syncLock)
                {
                    Id = Connections.GetConnectionId();

                    ConnectionModel connection = new ConnectionModel
                    {
                        Id = Id,
                        SourceAddress = DestinationSocket.LocalEndPoint.ToString(),
                        DestinationAddress = DestinationSocket.RemoteEndPoint.ToString()
                    };

                    Connections.AddConnection(connection);
                }

                ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnClientReceive, ClientSocket);
                DestinationSocket.BeginReceive(RemoteBuffer, 0, RemoteBuffer.Length, SocketFlags.None, OnRemoteReceive,
                    DestinationSocket);
            }
            catch
            {
                Dispose();
            }
        }

        /// <summary>
        ///     Called when we have received data from the local client.
        ///     <br>Incoming data will immediately be forwarded to the remote host.</br>
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnClientReceive(IAsyncResult ar)
        {
            try
            {
                int countReturn = ClientSocket.EndReceive(ar);
                if (countReturn <= 0)
                {
                    Dispose();
                    return;
                }

                lock (_syncLock)
                {
                    long packetId = Connections.GetConnectionPacketId();

                    ConnectionPacketModel packet = new ConnectionPacketModel
                    {
                        Id = packetId,
                        Data = Buffer.ResizeByteArray(countReturn),
                        Type = ConnectionPacketType.ClientToServer
                    };

                    Connections.AddConnectionPacket(Id, packet);
                }

                DestinationSocket.BeginSend(Buffer, 0, countReturn, SocketFlags.None, OnRemoteSent, DestinationSocket);
            }
            catch
            {
                Dispose();
            }
        }

        /// <summary>
        ///     Called when we have sent data to the remote host.
        ///     <br>When all the data has been sent, we will start receiving again from the local client.</br>
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnRemoteSent(IAsyncResult ar)
        {
            try
            {
                int countReturn = DestinationSocket.EndSend(ar);
                if (countReturn > 0)
                {
                    ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnClientReceive,
                        ClientSocket);
                    return;
                }
            }
            catch
            {
                // ignored
            }

            Dispose();
        }

        /// <summary>
        ///     Called when we have received data from the remote host.
        ///     <br>Incoming data will immediately be forwarded to the local client.</br>
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnRemoteReceive(IAsyncResult ar)
        {
            try
            {
                int countReturn = DestinationSocket.EndReceive(ar);
                if (countReturn <= 0)
                {
                    Dispose();
                    return;
                }

                lock (_syncLock)
                {
                    long packetId = Connections.GetConnectionPacketId();

                    ConnectionPacketModel packet = new ConnectionPacketModel
                    {
                        Id = packetId,
                        Data = RemoteBuffer.ResizeByteArray(countReturn),
                        Type = ConnectionPacketType.ServerToClient
                    };

                    Connections.AddConnectionPacket(Id, packet);
                }

                ClientSocket.BeginSend(RemoteBuffer, 0, countReturn, SocketFlags.None, OnClientSent, ClientSocket);
            }
            catch
            {
                Dispose();
            }
        }

        /// <summary>
        ///     Called when we have sent data to the local client.
        ///     <br>When all the data has been sent, we will start receiving again from the remote host.</br>
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        private void OnClientSent(IAsyncResult ar)
        {
            try
            {
                int countReturn = ClientSocket.EndSend(ar);
                if (countReturn > 0)
                {
                    DestinationSocket.BeginReceive(RemoteBuffer, 0, RemoteBuffer.Length, SocketFlags.None,
                        OnRemoteReceive, DestinationSocket);
                    return;
                }
            }
            catch
            {
                // ignored
            }

            Dispose();
        }
    }
}