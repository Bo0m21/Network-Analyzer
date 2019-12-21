using System.Net.Sockets;

namespace Network_Analyzer_WinForms.Network.Authentication
{
    /// <summary>Authenticates a user on a SOCKS5 server according to the 'No Authentication' subprotocol.</summary>
    internal sealed class AuthNone : AuthBase
    {
        /// <summary>Calls the parent class to inform it authentication is complete.</summary>
        /// <param name="connection">The connection with the SOCKS client.</param>
        /// <param name="callback">The method to call when the authentication is complete.</param>
        internal override void StartAuthentication(Socket connection, AuthenticationCompleteDelegate callback)
        {
            callback(true);
        }
    }
}