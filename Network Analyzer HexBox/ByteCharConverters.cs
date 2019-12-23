using System.Text;

namespace Network_Analyzer_HexBox
{
    /// <summary>
    ///     The interface for objects that can translate between characters and bytes.
    /// </summary>
    public interface IByteCharConverter
    {
        /// <summary>
        ///     Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        char ToChar(byte b);

        /// <summary>
        ///     Returns the byte to use when the character passed across is entered during editing.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        byte ToByte(char c);
    }

    /// <summary>
    ///     The converter encoding ASCII
    /// </summary>
    public class DefaultByteCharConverter : IByteCharConverter
    {
        /// <summary>
        ///     The encoding
        /// </summary>
        private readonly Encoding _encoding = Encoding.ASCII;

        /// <summary>
        ///     Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            var encoded = _encoding.GetString(new[] {b});
            return encoded.Length > 0 ? encoded[0] >= 0x20 ? encoded[0] : '.' : '.';
        }

        /// <summary>
        ///     Returns the byte to use for the character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            var decoded = _encoding.GetBytes(new[] {c});
            return decoded.Length > 0 ? decoded[0] : (byte) 0;
        }

        /// <summary>
        ///     Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ASCII";
        }
    }

    /// <summary>
    ///     The converter encoding Unicode
    /// </summary>
    public class UnicodeByteCharProvider : IByteCharConverter
    {
        /// <summary>
        ///     The encoding
        /// </summary>
        private readonly Encoding _encoding = Encoding.Unicode;

        /// <summary>
        ///     Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            var encoded = _encoding.GetString(new[] {b});
            return encoded.Length > 0 ? encoded[0] >= 0x20 ? encoded[0] : '.' : '.';
        }

        /// <summary>
        ///     Returns the byte to use for the character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            var decoded = _encoding.GetBytes(new[] {c});
            return decoded.Length > 0 ? decoded[0] : (byte) 0;
        }

        /// <summary>
        ///     Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Unicode";
        }
    }

    /// <summary>
    ///     The converter encoding UTF8
    /// </summary>
    public class UTF8ByteCharProvider : IByteCharConverter
    {
        /// <summary>
        ///     The encoding
        /// </summary>
        private readonly Encoding _encoding = Encoding.UTF8;

        /// <summary>
        ///     Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            var encoded = _encoding.GetString(new[] {b});
            return encoded.Length > 0 ? encoded[0] >= 0x20 ? encoded[0] : '.' : '.';
        }

        /// <summary>
        ///     Returns the byte to use for the character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            var decoded = _encoding.GetBytes(new[] {c});
            return decoded.Length > 0 ? decoded[0] : (byte) 0;
        }

        /// <summary>
        ///     Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "UTF8";
        }
    }

    /// <summary>
    ///     The converter encoding Windows-1251
    /// </summary>
    public class Windows1251ByteCharProvider : IByteCharConverter
    {
        /// <summary>
        ///     The encoding
        /// </summary>
        private readonly Encoding _encoding = Encoding.GetEncoding("Windows-1251");

        /// <summary>
        ///     Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            var encoded = _encoding.GetString(new[] {b});
            return encoded.Length > 0 ? encoded[0] >= 0x20 ? encoded[0] : '.' : '.';
        }

        /// <summary>
        ///     Returns the byte to use for the character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            var decoded = _encoding.GetBytes(new[] {c});
            return decoded.Length > 0 ? decoded[0] : (byte) 0;
        }

        /// <summary>
        ///     Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Windows-1251";
        }
    }
}