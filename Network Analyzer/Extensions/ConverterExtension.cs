using System;
using System.Collections.Generic;
using System.Text;
using Network_Analyzer.Code;
using Network_Analyzer.Models.SelectedEncoding;
using Network_Analyzer.Models.SelectedPacket;

namespace Network_Analyzer.Extensions
{
    /// <summary>
    ///     This is class work with converter
    /// </summary>
    public static class ConverterExtension
    {
		/// <summary>
		///		Read sbyte from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <returns></returns>
        public static sbyte ReadSbyte(this byte[] data, int index)
        {
            return (sbyte) data[index];
        }

		/// <summary>
		///		Read byte from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static byte ReadByte(this byte[] data, int index)
        {
            return data[index];
        }

		/// <summary>
		///		Read short from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read ushort from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read int from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read uint from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read float from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read long from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read ulong from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Read double from array
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
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

		/// <summary>
		///		Get value from array by type
		/// </summary>
		/// <param name="data"></param>
		/// <param name="type"></param>
		/// <param name="index"></param>
		/// <param name="reverse"></param>
		/// <returns></returns>
		public static string GetValue(this byte[] data, string type, long index, bool reverse, SelectedEncodingType selectedEncodingType = SelectedEncodingType.EncodingAscii)
        {
	        if (index < data.Length)
	        {
		        if (type == Localizer.LocalizeString("Types.Byte"))
	            {
	                return data.ReadByte((int) index).ToString();
	            }

	            if (type == Localizer.LocalizeString("Types.Sbyte"))
	            {
	                return data.ReadSbyte((int) index).ToString();
	            }

				if (type == Localizer.LocalizeString("Types.String"))
				{
					List<byte> bytes = new List<byte>();

					for (long i = index; i < data.Length; i++)
					{
						if (data[i] == 0)
						{
							break;
						}

						bytes.Add(data[i]);
					}

					if (bytes.Count == 0)
					{
						return "";
					}

					if (selectedEncodingType == SelectedEncodingType.EncodingUnicode)
					{
						return Encoding.Unicode.GetString(bytes.ToArray());
					}
					else if (selectedEncodingType == SelectedEncodingType.EncodingUTF8)
					{
						return Encoding.UTF8.GetString(bytes.ToArray());
					}
					else if (selectedEncodingType == SelectedEncodingType.EncodingWindows1251)
					{
						return Encoding.GetEncoding("Windows-1251").GetString(bytes.ToArray());
					}
					else
					{
						return Encoding.ASCII.GetString(bytes.ToArray());
					}
				}

				if (type == Localizer.LocalizeString("Types.Structure"))
				{
					return "";
				}
			}

            if (index + 1 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Short"))
                {
                    return data.ReadShort((int) index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Ushort"))
                {
                    return data.ReadUshort((int) index, reverse).ToString();
                }
            }

            if (index + 3 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Int"))
                {
                    return data.ReadInt((int) index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Uint"))
                {
                    return data.ReadUint((int) index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Float"))
                {
                    return data.ReadFloat((int) index, reverse).ToString();
                }
            }

            if (index + 7 < data.Length)
            {
                if (type == Localizer.LocalizeString("Types.Long"))
                {
                    return data.ReadLong((int) index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Ulong"))
                {
                    return data.ReadUlong((int) index, reverse).ToString();
                }

                if (type == Localizer.LocalizeString("Types.Double"))
                {
                    return data.ReadDouble((int) index, reverse).ToString();
                }
            }

            return "0";
        }
    }
}