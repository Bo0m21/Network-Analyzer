using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Network_Analyzer.Network.Clients;

namespace Network_Analyzer.Network
{
    /// <summary>
    ///     Specifies the basic methods and properties of a <c>Listener</c> object. This is an abstract class and must be
    ///     inherited.
    /// </summary>
    /// <remarks>
    ///     The Listener class provides an abstract base class that represents a listening socket of the proxy server.
    ///     Descendant classes further specify the protocol that is used between those two connections.
    /// </remarks>
    public abstract class Listener : IDisposable
    {
        /// <summary>Gets the list of connected clients.</summary>
        /// <value>An instance of the ArrayList class that's used to store all the connections.</value>
        private readonly ArrayList m_Clients = new ArrayList();

        /// <summary>Holds the value of the Address property.</summary>
        private IPAddress m_Address;

        /// <summary>Holds the value of the ListenSocket property.</summary>
        private Socket m_ListenSocket;

        /// <summary>Holds the value of the Port property.</summary>
        private int m_Port;

        /// <summary>Initializes a new instance of the Listener class.</summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="address">The address to listen on. You can specify IPAddress.Any to listen on all installed network cards.</param>
        /// <remarks>
        ///     For the security of your server, try to avoid to listen on every network card (IPAddress.Any). Listening on a
        ///     local IP address is usually sufficient and much more secure.
        /// </remarks>
        public Listener(int port, IPAddress address)
        {
            Port = port;
            Address = address;
        }

        /// <summary>Gets or sets the listening Socket.</summary>
        /// <value>An instance of the Socket class that's used to listen for incoming connections.</value>
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        protected Socket ListenSocket
        {
            get => m_ListenSocket;
            set => m_ListenSocket = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets or sets the address on which to listen on.</summary>
        /// <value>An IPAddress instance defining the IP address to listen on.</value>
        /// <seealso cref="Port" />
        /// <exception cref="ArgumentNullException">The specified value is null.</exception>
        protected IPAddress Address
        {
            get => m_Address;
            set
            {
                m_Address = value ?? throw new ArgumentNullException();
                Restart();
            }
        }

        /// <summary>Gets or sets the port number on which to listen on.</summary>
        /// <value>An integer defining the port number to listen on.</value>
        /// <seealso cref="Address" />
        /// <exception cref="ArgumentException">The specified value is less than or equal to zero.</exception>
        protected int Port
        {
            get => m_Port;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                m_Port = value;
                Restart();
            }
        }

        /// <summary>Gets a value indicating whether the Listener has been disposed or not.</summary>
        /// <value>An boolean that specifies whether the object has been disposed or not.</value>
        public bool IsDisposed { get; private set; }

        /// <summary>Gets a value indicating whether the Listener is currently listening or not.</summary>
        /// <value>A boolean that indicates whether the Listener is currently listening or not.</value>
        public bool Listening => ListenSocket != null;

        /// <summary>Disposes of the resources (other than memory) used by the Listener.</summary>
        /// <remarks>
        ///     Stops listening and disposes <em>all</em> the client objects. Once disposed, this object should not be used
        ///     anymore.
        /// </remarks>
        /// <seealso cref="System.IDisposable" />
        public void Dispose()
        {
            if (IsDisposed)
                return;

            while (m_Clients.Count > 0)
            {
                ((Client) m_Clients[0]).Dispose();
            }

            try
            {
                ListenSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
                // ignored
            }

            ListenSocket?.Close();
            IsDisposed = true;
        }

        /// <summary>Starts listening on the selected IP address and port.</summary>
        /// <exception cref="SocketException">There was an error while creating the listening socket.</exception>
        public void Start()
        {
            try
            {
                ListenSocket = new Socket(Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                ListenSocket.Bind(new IPEndPoint(Address, Port));
                ListenSocket.Listen(100);
                ListenSocket.BeginAccept(OnAccept, ListenSocket);
            }
            catch
            {
                ListenSocket = null;
                throw new SocketException();
            }
        }

        /// <summary>Restarts listening on the selected IP address and port.</summary>
        /// <remarks>This method is automatically called when the listening port or the listening IP address are changed.</remarks>
        /// <exception cref="SocketException">There was an error while creating the listening socket.</exception>
        protected void Restart()
        {
            //If we weren't listening, do nothing
            if (ListenSocket == null)
                return;

            ListenSocket.Close();
            Start();
        }

        /// <summary>Adds the specified Client to the client list.</summary>
        /// <remarks>A client will never be added twice to the list.</remarks>
        /// <param name="client">The client to add to the client list.</param>
        protected void AddClient(Client client)
        {
            if (m_Clients.IndexOf(client) == -1)
                m_Clients.Add(client);
        }

        /// <summary>Removes the specified Client from the client list.</summary>
        /// <param name="client">The client to remove from the client list.</param>
        protected void RemoveClient(Client client)
        {
            m_Clients.Remove(client);
        }

        /// <summary>Returns the number of clients in the client list.</summary>
        /// <returns>The number of connected clients.</returns>
        public int GetClientCount()
        {
            return m_Clients.Count;
        }

        /// <summary>Returns the requested client from the client list.</summary>
        /// <param name="index">The index of the requested client.</param>
        /// <returns>The requested client.</returns>
        /// <remarks>If the specified index is invalid, the GetClientAt method returns null.</remarks>
        public Client GetClientAt(int index)
        {
            if (index < 0 || index >= GetClientCount())
                return null;

            return (Client) m_Clients[index];
        }

        /// <summary>Finalizes the Listener.</summary>
        /// <remarks>The destructor calls the Dispose method.</remarks>
        ~Listener()
        {
            Dispose();
        }

        /// <summary>Returns an external IP address of this computer, if present.</summary>
        /// <returns>
        ///     Returns an external IP address of this computer; if this computer does not have an external IP address, it
        ///     returns the first local IP address it can find.
        /// </returns>
        /// <remarks>If this computer does not have any configured IP address, this method returns the IP address 0.0.0.0.</remarks>
        public static IPAddress GetLocalExternalIp()
        {
            try
            {
                IPHostEntry he = Dns.Resolve(Dns.GetHostName());
                for (int Cnt = 0; Cnt < he.AddressList.Length; Cnt++)
                    if (IsRemoteIp(he.AddressList[Cnt]))
                        return he.AddressList[Cnt];
                return he.AddressList[0];
            }
            catch
            {
                return IPAddress.Any;
            }
        }

        /// <summary>Checks whether the specified IP address is a remote IP address or not.</summary>
        /// <param name="ip">The IP address to check.</param>
        /// <returns>True if the specified IP address is a remote address, false otherwise.</returns>
        protected static bool IsRemoteIp(IPAddress ip)
        {
            byte First = (byte) (ip.Address % 256);
            byte Second = (byte) (ip.Address % 65536 / 256);
            //Not 10.x.x.x And Not 172.16.x.x <-> 172.31.x.x And Not 192.168.x.x
            //And Not Any And Not Loopback And Not Broadcast
            return First != 10 &&
                   (First != 172 || Second < 16 || Second > 31) &&
                   (First != 192 || Second != 168) &&
                   !ip.Equals(IPAddress.Any) &&
                   !ip.Equals(IPAddress.Loopback) &&
                   !ip.Equals(IPAddress.Broadcast);
        }

        /// <summary>Checks whether the specified IP address is a local IP address or not.</summary>
        /// <param name="ip">The IP address to check.</param>
        /// <returns>True if the specified IP address is a local address, false otherwise.</returns>
        protected static bool IsLocalIp(IPAddress ip)
        {
            byte First = (byte) (ip.Address % 256);
            byte Second = (byte) (ip.Address % 65536 / 256);
            //10.x.x.x Or 172.16.x.x <-> 172.31.x.x Or 192.168.x.x
            return First == 10 ||
                   First == 172 && Second >= 16 && Second <= 31 ||
                   First == 192 && Second == 168;
        }

        /// <summary>Returns an internal IP address of this computer, if present.</summary>
        /// <returns>
        ///     Returns an internal IP address of this computer; if this computer does not have an internal IP address, it
        ///     returns the first local IP address it can find.
        /// </returns>
        /// <remarks>If this computer does not have any configured IP address, this method returns the IP address 0.0.0.0.</remarks>
        public static IPAddress GetLocalInternalIp()
        {
            try
            {
                IPHostEntry he = Dns.Resolve(Dns.GetHostName());
                for (int Cnt = 0; Cnt < he.AddressList.Length; Cnt++)
                    if (IsLocalIp(he.AddressList[Cnt]))
                        return he.AddressList[Cnt];
                return he.AddressList[0];
            }
            catch
            {
                return IPAddress.Any;
            }
        }

        /// <summary>Called when there's an incoming client connection waiting to be accepted.</summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        public abstract void OnAccept(IAsyncResult ar);
    }
}