using System.Collections.Generic;

namespace Network_Analyzer.Decryptor
{
    /// <summary>
    ///     This interfave for about decryptor
    /// </summary>
    public interface IDecryptor
    {
        List<DecryptorModel> Parse(byte[] data);
    }
}