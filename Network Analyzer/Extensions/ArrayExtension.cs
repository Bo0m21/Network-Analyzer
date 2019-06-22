using System;
using System.Collections.Generic;

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

        /// <summary>
        ///     Fast search for array bytes
        /// </summary>
        /// <param name="self"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public static int[] Search(this byte[] self, byte[] candidate)
        {
            if (IsEmptyLocate(self, candidate))
            {
                return new int[0];
            }

            List<int> list = new List<int>();

            for (int i = 0; i < self.Length; i++)
            {
                if (!IsMatch(self, i, candidate))
                {
                    continue;
                }

                list.Add(i);
            }

            return list.Count == 0 ? new int[0] : list.ToArray();
        }

        /// <summary>
        ///     Methor for search
        /// </summary>
        private static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > array.Length - position)
            {
                return false;
            }

            for (int i = 0; i < candidate.Length; i++)
            {
                if (array[position + i] != candidate[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Methor for search
        /// </summary>
        private static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null || candidate == null || array.Length == 0 ||
                   candidate.Length == 0 || candidate.Length > array.Length;
        }
    }
}