using System;

namespace Network_Analyzer.Extensions
{
    /// <summary>
    ///     Class array extensions
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        ///     Resize bytes array
        /// </summary>
        public static byte[] ResizeByteArray(this byte[] byteArray, int length)
        {
            byte[] newArray = new byte[length];
            Array.Copy(byteArray, newArray, length);

            return newArray;
        }
    }
}