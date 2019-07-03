using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Services;

namespace Network_Analyzer.Extensions
{
	/// <summary>
	///     Class configuration extensions
	/// </summary>
	public static class ConfigurationExtension
	{
		/// <summary>
		///     Get length by type
		/// </summary>
		/// <param name="configurationPacketField">Configuration packet field</param>
		/// <returns></returns>
		public static long GetLengthByType(this ConfigurationPacketFieldModel configurationPacketField)
		{
			if (configurationPacketField.Type == Localizer.LocalizeString("Types.Byte") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Sbyte"))
			{
				return 1;
			}

			if (configurationPacketField.Type == Localizer.LocalizeString("Types.Short") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Ushort"))
			{
				return 2;
			}

			if (configurationPacketField.Type == Localizer.LocalizeString("Types.Int") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Uint") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Float"))
			{
				return 4;
			}

			if (configurationPacketField.Type == Localizer.LocalizeString("Types.Long") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Ulong") ||
			    configurationPacketField.Type == Localizer.LocalizeString("Types.Double"))
			{
				return 8;
			}

			return 0;
		}
	}
}