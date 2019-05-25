using System;
using System.Net.Sockets;
using System.Text;

namespace Network_Analyzer.Network.Listeners.Authentication
{
	/// <summary>Authenticates a user on a SOCKS5 server according to the username/password authentication subprotocol.</summary>
	internal sealed class AuthUserPass : AuthBase
	{
		/// <summary>Initializes a new instance of the AuthUserPass class.</summary>
		/// <param name="authList">An AuthenticationList object that contains the list of all valid username/password combinations.</param>
		/// <remarks>If the AuthList parameter is null, any username/password combination will be accepted.</remarks>
		public AuthUserPass(AuthenticationList authList)
		{
			AuthList = authList;
		}

		/// <summary>Gets or sets the AuthenticationList to use when a computer tries to authenticate on the proxy server.</summary>
		/// <value>An instance of the AuthenticationList class that contains all the valid username/password combinations.</value>
		private AuthenticationList AuthList { get; }

		/// <summary>Starts the authentication process.</summary>
		/// <param name="connection">The connection with the SOCKS client.</param>
		/// <param name="callback">The method to call when the authentication is complete.</param>
		internal override void StartAuthentication(Socket connection, AuthenticationCompleteDelegate callback)
		{
			Connection = connection;
			Callback = callback;

			try
			{
				Bytes = null;
				connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnRecvRequest, connection);
			}
			catch
			{
				callback(false);
			}
		}

		/// <summary>Called when we have received the initial authentication data from the SOCKS client.</summary>
		/// <param name="ar">The result of the asynchronous operation.</param>
		private void OnRecvRequest(IAsyncResult ar)
		{
			try
			{
				var countReturn = Connection.EndReceive(ar);
				if (countReturn <= 0)
				{
					Callback(false);
					return;
				}

				AddBytes(Buffer, countReturn);

				if (IsValidQuery(Bytes))
					ProcessQuery(Bytes);
				else
					Connection.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnRecvRequest, Connection);
			}
			catch
			{
				Callback(false);
			}
		}

		/// <summary>Checks whether the specified authentication query is a valid one.</summary>
		/// <param name="query">The query to check.</param>
		/// <returns>True if the query is a valid authentication query, false otherwise.</returns>
		private bool IsValidQuery(byte[] query)
		{
			try
			{
				return query.Length == query[1] + query[query[1] + 2] + 3;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>Processes an authentication query.</summary>
		/// <param name="query">The query to process.</param>
		private void ProcessQuery(byte[] query)
		{
			try
			{
				var User = Encoding.ASCII.GetString(query, 2, query[1]);
				var Pass = Encoding.ASCII.GetString(query, query[1] + 3, query[query[1] + 2]);

				if (AuthList == null || AuthList.IsItemPresent(User, Pass))
				{
					byte[] ToSend = {5, 0};
					Connection.BeginSend(ToSend, 0, ToSend.Length, SocketFlags.None, OnOkSent, Connection);
				}
				else
				{
					byte[] ToSend = {5, 1};
					Connection.BeginSend(ToSend, 0, ToSend.Length, SocketFlags.None, OnUhohSent, Connection);
				}
			}
			catch
			{
				Callback(false);
			}
		}

		/// <summary>Called when an OK reply has been sent to the client.</summary>
		/// <param name="ar">The result of the asynchronous operation.</param>
		private void OnOkSent(IAsyncResult ar)
		{
			try
			{
				Callback(Connection.EndSend(ar) > 0);
			}
			catch
			{
				Callback(false);
			}
		}

		/// <summary>Called when a negatiev reply has been sent to the client.</summary>
		/// <param name="ar">The result of the asynchronous operation.</param>
		private void OnUhohSent(IAsyncResult ar)
		{
			try
			{
				Connection.EndSend(ar);
			}
			catch
			{
				// ignored
			}

			Callback(false);
		}
	}
}