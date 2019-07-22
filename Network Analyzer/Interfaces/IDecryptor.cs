using System.Collections.Generic;

namespace Network_Analyzer.Decryptor
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