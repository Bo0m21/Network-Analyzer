using System.Collections.Generic;
using Network_Analyzer_WinForms.Models.Decryptor;

namespace Network_Analyzer_WinForms.Interfaces
{
    /// <summary>
    ///     This interfave for about decryptor
    /// </summary>
    public interface IDecryptor
    {
		/// <summary>
		///		Method return decrypt data and opcode
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        List<DecryptorModel> Parse(byte[] data);
    }
}