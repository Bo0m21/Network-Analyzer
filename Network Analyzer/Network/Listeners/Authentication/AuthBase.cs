using System;
using System.Net.Sockets;

namespace Network_Analyzer.Network.Listeners.Authentication
{
    /// <summary>Defines the signature of the method to be called when the authentication is complete.</summary>
    /// <param name="success">Specifies whether the authentication was successfull or not.</param>
    internal delegate void AuthenticationCompleteDelegate(bool success);

    /// <summary>Authenticates a user on a SOCKS5 server according to the implemented subprotocol.</summary>
    /// <remarks>
    ///     This is an abstract class. The subprotocol that's used to authenticate a user is specified in the subclasses
    ///     of this base class.
    /// </remarks>
    internal abstract class AuthBase
    {
        /// <summary>The method to call when the authentication is complete.</summary>
        protected AuthenticationCompleteDelegate Callback;

        /// <summary>Holds the value of the Connection property.</summary>
        private Socket m_Connection;

        /// <summary>Gets or sets the Socket connection between the proxy server and the SOCKS client.</summary>
        /// <value>A Socket instance defining the connection between the proxy server and the local client.</value>
        protected Socket Connection
        {
            get => m_Connection;
            set => m_Connection = value ?? throw new ArgumentNullException();
        }

        /// <summary>Gets a buffer that can be used to receive data from the client connection.</summary>
        /// <value>An array of bytes that can be used to receive data from the client connection.</value>
        protected byte[] Buffer { get; } = new byte[1024];

        /// <summary>Gets or sets an array of bytes that can be used to store all received data.</summary>
        /// <value>An array of bytes that can be used to store all received data.</value>
        protected byte[] Bytes { get; set; }

        /// <summary>Starts the authentication process.</summary>
        /// <remarks>This abstract method must be implemented in the subclasses, according to the selected subprotocol.</remarks>
        /// <param name="connection">The connection with the SOCKS client.</param>
        /// <param name="callback">The method to call when the authentication is complete.</param>
        internal abstract void StartAuthentication(Socket connection, AuthenticationCompleteDelegate callback);

        /// <summary>Adds bytes to the array returned by the Bytes property.</summary>
        /// <param name="newBytes">The bytes to add.</param>
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
                var tmp = Bytes;
                Bytes = new byte[Bytes.Length + cnt];
                Array.Copy(tmp, 0, Bytes, 0, tmp.Length);
            }

            Array.Copy(newBytes, 0, Bytes, Bytes.Length - cnt, cnt);
        }
    }
}