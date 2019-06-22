using Network_Analyzer.Services;
using System;

namespace Network_Analyzer.Extensions
{
    /// <summary>
    ///     This is class work with converter
    /// </summary>
    public static class ConverterExtension
    {
        public static sbyte ReadSbyte(this byte[] data, int index)
        {
            return (sbyte)data[index];
        }

        public static byte ReadByte(this byte[] data, int index)
        {
            return data[index];
        }

        public static short ReadShort(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(short)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(short));
            }

            return BitConverter.ToInt16(bytes, 0);
        }

        public static ushort ReadUshort(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(ushort)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(ushort));
            }

            return BitConverter.ToUInt16(bytes, 0);
        }

        public static int ReadInt(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(int)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(int));
            }

            return BitConverter.ToInt32(bytes, 0);
        }

        public static uint ReadUint(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(uint)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(uint));
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static float ReadFloat(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(float)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(float));
            }

            return BitConverter.ToSingle(bytes, 0);
        }

        public static long ReadLong(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(long)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(long));
            }

            return BitConverter.ToInt64(bytes, 0);
        }

        public static ulong ReadUlong(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(ulong)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(ulong));
            }

            return BitConverter.ToUInt64(bytes, 0);
        }

        public static double ReadDouble(this byte[] data, int index, bool reverse)
        {
            byte[] bytes = new byte[sizeof(double)];
            Array.Copy(data, index, bytes, 0, bytes.Length);

            if (reverse)
            {
                Array.Reverse(bytes, 0, sizeof(double));
            }

            return BitConverter.ToDouble(bytes, 0);
        }

        public static string GetValue(this byte[] data, string type, long index, bool reverse)
        {
            if (type == Localizer.LocalizeString("Types.Byte"))
            {
                return data.ReadByte((int)index).ToString();
            }

            if (type == Localizer.LocalizeString("Types.Sbyte"))
            {
                return data.ReadSbyte((int)index).ToString();
            }

            if (index + 1 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Short"))
                {
                    return data.ReadShort((int)index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Ushort"))
                {
                    return data.ReadUshort((int)index, reverse).ToString();
                }
            }

            if (index + 3 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Int"))
                {
                    return data.ReadInt((int)index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Uint"))
                {
                    return data.ReadUint((int)index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Float"))
                {
                    return data.ReadFloat((int)index, reverse).ToString();
                }
            }

            if (index + 7 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Long"))
                {
                    return data.ReadLong((int)index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Ulong"))
                {
                    return data.ReadUlong((int)index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Double"))
                {
                    return data.ReadDouble((int)index, reverse).ToString();
                }
            }

            return "";
        }
    }
}