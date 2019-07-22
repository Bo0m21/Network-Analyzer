using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Services;
using System.Collections.Generic;
using System.Linq;

namespace Network_Analyzer.Extensions
{
	/// <summary>
	///     Class configuration extensions
	/// </summary>
	public static class ConfigurationExtension
	{
		/// <summary>
		///		Get length by type
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="configurationField"></param>
		/// <returns></returns>
		public static long GetLengthByType(this ConfigurationModel configuration, ConfigurationFieldModel configurationField)
		{
			if (configurationField.Type == Localizer.LocalizeString("Types.Byte") ||
				configurationField.Type == Localizer.LocalizeString("Types.Sbyte"))
			{
				return 1;
			}

			if (configurationField.Type == Localizer.LocalizeString("Types.Short") ||
				configurationField.Type == Localizer.LocalizeString("Types.Ushort"))
			{
				return 2;
			}

			if (configurationField.Type == Localizer.LocalizeString("Types.Int") ||
				configurationField.Type == Localizer.LocalizeString("Types.Uint") ||
				configurationField.Type == Localizer.LocalizeString("Types.Float"))
			{
				return 4;
			}

			if (configurationField.Type == Localizer.LocalizeString("Types.Long") ||
				configurationField.Type == Localizer.LocalizeString("Types.Ulong") ||
				configurationField.Type == Localizer.LocalizeString("Types.Double"))
			{
				return 8;
			}

			if (configurationField.Type == Localizer.LocalizeString("Types.String"))
			{
				if (long.TryParse(configurationField.Common, out long length))
				{
					return length;
				}
			}

			if (configurationField.Type == Localizer.LocalizeString("Types.Structure"))
			{
				return configuration.GetLengthByStructureName(configurationField.Common);
			}

			return 0;
		}

		/// <summary>
		///		Get all fields for configuration class
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="configurationClass"></param>
		/// <returns></returns>
		public static List<ConfigurationFieldModel> GetAllFieldForConfigurationClass(this ConfigurationModel configuration, ConfigurationClassModel configurationClass)
		{
			// TODO Обязательно рефакторинг этой хуйни
			var configurationFields = new List<ConfigurationFieldModel>();

			foreach (var configurationField in configurationClass.ConfigurationFields)
			{
				if (configurationField.Type == Localizer.LocalizeString("Types.String"))
				{
					if (configurationField.IsArray)
					{
						for (int i = 0; i < configurationField.ArrayLength; i++)
						{
							long len = 0;

							if (long.TryParse(configurationField.Common, out long newLen))
							{
								len = newLen;
							}
							else
							{
								len = 10;
							}

							configurationFields.Add(new ConfigurationFieldModel()
							{
								Name = configurationField.Name,
								Description = configurationField.Description,
								Type = configurationField.Type,
								SequenceType = configurationField.SequenceType,
								Position = configurationField.Position + (len * i),
								IsArray = configurationField.IsArray,
								ArrayLength = configurationField.ArrayLength,
								Common = configurationField.Common
							});
						}
					}
					else
					{
						configurationFields.Add(configurationField);
					}
				}
				else if (configurationField.Type == Localizer.LocalizeString("Types.Structure"))
				{
					if (configurationField.IsArray)
					{
						var lengthstr = configuration.GetLengthByType(configurationField);

						for (int i = 0; i < configurationField.ArrayLength; i++)
						{
							configurationFields.AddRange(configuration.GetAllFieldByStructureName(configurationField.Common, configurationField.Position + (lengthstr * i)));
						}
					}
					else
					{
						configurationFields.AddRange(configuration.GetAllFieldByStructureName(configurationField.Common, configurationField.Position));
					}
				}
				else
				{
					if (configurationField.IsArray)
					{
						for (int i = 0; i < configurationField.ArrayLength; i++)
						{
							configurationFields.Add(new ConfigurationFieldModel()
							{
								Name = configurationField.Name,
								Description = configurationField.Description,
								Type = configurationField.Type,
								SequenceType = configurationField.SequenceType,
								Position = configurationField.Position + (configuration.GetLengthByType(configurationField) * i),
								IsArray = configurationField.IsArray,
								ArrayLength = configurationField.ArrayLength,
								Common = configurationField.Common
							});
						}
					}
					else
					{
						configurationFields.Add(configurationField);
					}
				}
			}

			return configurationFields;
		}

		/// <summary>
		///		Get all field by structure name
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="structureName"></param>
		/// <param name="position"></param>
		/// <returns></returns>
		public static List<ConfigurationFieldModel> GetAllFieldByStructureName(this ConfigurationModel configuration, string structureName, long position)
		{
			var structure = configuration.ConfigurationStructures.FirstOrDefault(s => s.Name == structureName);

			if (structure == null)
			{
				return new List<ConfigurationFieldModel>();
			}

			var configurationFields = new List<ConfigurationFieldModel>();

			foreach (var configurationField in structure.ConfigurationFields)
			{
				if (configurationField.Type != Localizer.LocalizeString("Types.Structure"))
				{
					configurationFields.Add(new ConfigurationFieldModel()
					{
						Name = configurationField.Name,
						Description = configurationField.Description,
						Type = configurationField.Type,
						SequenceType = configurationField.SequenceType,
						Position = configurationField.Position + position,
						IsArray = configurationField.IsArray,
						ArrayLength = configurationField.ArrayLength,
						Common = configurationField.Common
					});
				}
				else
				{
					configurationFields.AddRange(configuration.GetAllFieldByStructureName(configurationField.Common, configurationField.Position + position));
				}
			}

			return configurationFields;
		}

		/// <summary>
		///		Get length by structure name
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="structureName"></param>
		/// <returns></returns>
		private static long GetLengthByStructureName(this ConfigurationModel configuration, string structureName)
		{
			List<ConfigurationFieldModel> configurationFields = configuration.GetAllFieldByStructureName(structureName, 0);
			ConfigurationFieldModel configurationFieldModel = configurationFields.OrderBy(c => c.Position).LastOrDefault();

			if (configurationFieldModel != null)
			{
				return configurationFieldModel.Position + configuration.GetLengthByType(configurationFieldModel);
			}

			return 0;
		}

		// TODO Добавить получение длины по структуре по полю и по классу и так же получение полей по структуре и классу

		/// <summary>
		///		Rename configuration name all related fields
		/// </summary>
		/// <param name="configurationModel"></param>
		/// <param name="oldConfigurationName"></param>
		/// <param name="newConfigurationName"></param>
		public static void RenameConfigurationNameAllRelatedFields(this ConfigurationModel configurationModel, string oldConfigurationName, string newConfigurationName)
		{
			// Rename all related fields in configuration packet
			for (int i = 0; i < configurationModel.ConfigurationPackets.Count(); i++)
			{
				for (int j = 0; j < configurationModel.ConfigurationPackets[i].ConfigurationFields.Count(); j++)
				{
					if (configurationModel.ConfigurationPackets[i].ConfigurationFields[j].Common == oldConfigurationName)
					{
						configurationModel.ConfigurationPackets[i].ConfigurationFields[j].Common = newConfigurationName;
					}
				}
			}

			// Rename all related fields in configuration structure
			for (int i = 0; i < configurationModel.ConfigurationStructures.Count(); i++)
			{
				for (int j = 0; j < configurationModel.ConfigurationStructures[i].ConfigurationFields.Count(); j++)
				{
					if (configurationModel.ConfigurationStructures[i].ConfigurationFields[j].Common == oldConfigurationName)
					{
						configurationModel.ConfigurationStructures[i].ConfigurationFields[j].Common = newConfigurationName;
					}
				}
			}
		}

		/// <summary>
		///		Delete configuration name all related fields
		/// </summary>
		/// <param name="configurationModel"></param>
		public static void DeleteConfigurationNameAllRelatedFields(this ConfigurationModel configurationModel, string fieldName)
		{
			// Delete all related fields in configuration packet
			for (int i = 0; i < configurationModel.ConfigurationPackets.Count(); i++)
			{
				for (int j = 0; j < configurationModel.ConfigurationPackets[i].ConfigurationFields.Count(); j++)
				{
					if (configurationModel.ConfigurationPackets[i].ConfigurationFields[j].Common == fieldName)
					{
						configurationModel.ConfigurationPackets[i].ConfigurationFields.Remove(configurationModel.ConfigurationPackets[i].ConfigurationFields[j]);
					}
				}
			}

			// Delete all related fields in configuration structure
			for (int i = 0; i < configurationModel.ConfigurationStructures.Count(); i++)
			{
				for (int j = 0; j < configurationModel.ConfigurationStructures[i].ConfigurationFields.Count(); j++)
				{
					if (configurationModel.ConfigurationStructures[i].ConfigurationFields[j].Common == fieldName)
					{
						configurationModel.ConfigurationStructures[i].ConfigurationFields.Remove(configurationModel.ConfigurationStructures[i].ConfigurationFields[j]);
					}
				}
			}
		}

		/// <summary>
		///		Rename field name all related fields
		/// </summary>
		/// <param name="configurationClassModel"></param>
		/// <param name="oldFieldName"></param>
		/// <param name="newFieldName"></param>
		public static void RenameFieldNameAllRelatedFields(this ConfigurationClassModel configurationClassModel, string oldFieldName, string newFieldName)
		{
			// Rename all related fields
			for (int i = 0; i < configurationClassModel.ConfigurationFields.Count(); i++)
			{
				if (configurationClassModel.ConfigurationFields[i].Common == oldFieldName)
				{
					configurationClassModel.ConfigurationFields[i].Common = newFieldName;
				}
			}
		}

		/// <summary>
		///		Delete field name all related fields
		/// </summary>
		/// <param name="configurationClassModel"></param>
		/// <param name="fieldName"></param>
		public static void DeleteFieldNameAllRelatedFields(this ConfigurationClassModel configurationClassModel, string fieldName)
		{
			// Delete all related fields
			for (int i = 0; i < configurationClassModel.ConfigurationFields.Count(); i++)
			{
				if (configurationClassModel.ConfigurationFields[i].Common == fieldName)
				{
					configurationClassModel.ConfigurationFields.Remove(configurationClassModel.ConfigurationFields[i]);
				}
			}
		}
	}
}