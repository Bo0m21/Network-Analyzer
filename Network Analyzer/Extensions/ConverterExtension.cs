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
			return (sbyte) data[index];
		}

		public static byte ReadByte(this byte[] data, int index)
		{
			return data[index];
		}

		public static short ReadShort(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(short)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(short));
			}

			return BitConverter.ToInt16(bytes, 0);
		}

		public static ushort ReadUshort(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(ushort)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(ushort));
			}

			return BitConverter.ToUInt16(bytes, 0);
		}

		public static int ReadInt(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(int)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(int));
			}

			return BitConverter.ToInt32(bytes, 0);
		}

		public static uint ReadUint(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(uint)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(uint));
			}

			return BitConverter.ToUInt32(bytes, 0);
		}

		public static float ReadFloat(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(float)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(float));
			}

			return BitConverter.ToSingle(bytes, 0);
		}

		public static long ReadLong(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(long)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(long));
			}

			return BitConverter.ToInt64(bytes, 0);
		}

		public static ulong ReadUlong(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(ulong)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(ulong));
			}

			return BitConverter.ToUInt64(bytes, 0);
		}

		public static double ReadDouble(this byte[] data, int index, bool reverse)
		{
			var bytes = new byte[sizeof(double)];
			Array.Copy(data, index, bytes, 0, bytes.Length);

			if (reverse)
			{
				Array.Reverse(bytes, 0, sizeof(double));
			}

			return BitConverter.ToDouble(bytes, 0);
		}
	}
}