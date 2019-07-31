using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Network_Analyzer.Models;
using Network_Analyzer.Models.Configuration;

namespace Network_Analyzer.Code
{
	/// <summary>
	///     Class configuration extensions
	/// </summary>
	public static class ConfigurationExtension
	{
        /// <summary>
        ///     Get color by enum colors
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color GetColor(this Colors color)
        {
            if (color == Colors.Error)
            {
                return Color.FromArgb(255, 90, 90);
            }
            else if (color == Colors.Warning)
            {
                return Color.FromArgb(245, 250, 90);
            }
            else if(color == Colors.Success)
            {
                return Color.FromArgb(146, 250, 90);
            }
            else if (color == Colors.BlockedElement)
            {
                return Color.Gainsboro;
            }
            else if (color == Colors.ServerToClient)
            {
                return Color.FromArgb(73, 235, 231);
            }
            else if (color == Colors.ClientToServer)
            {
                return Color.FromArgb(87, 142, 255);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }

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
				// TODO Дописать проверку
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

        ///  <summary>
        /// 		Get all fields for configuration field
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="configurationField"></param>
        ///  <param name="position"></param>
        ///  <returns></returns>
        public static List<ConfigurationFieldModel> GetAllFieldForConfiguration(this ConfigurationModel configuration, ConfigurationFieldModel configurationField, long position = 0, bool display = false)
		{
			return configuration.GetAllFieldForConfiguration(new List<ConfigurationFieldModel> { configurationField }, position, display);
		}

        ///  <summary>
        /// 		Get all fields for configuration class
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="configurationClass"></param>
        ///  <param name="position"></param>
        ///  <returns></returns>
        public static List<ConfigurationFieldModel> GetAllFieldForConfiguration(this ConfigurationModel configuration, ConfigurationClassModel configurationClass, long position = 0, bool display = false)
		{
			return configuration.GetAllFieldForConfiguration(configurationClass.ConfigurationFields, position, display);
		}

        ///  <summary>
        /// 		Get all fields for configuration fields
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="configurationFields"></param>
        ///  <param name="position"></param>
        ///  <returns></returns>
        private static List<ConfigurationFieldModel> GetAllFieldForConfiguration(this ConfigurationModel configuration, List<ConfigurationFieldModel> configurationFields, long position = 0, bool display = false)
		{
			var allConfigurationFields = new List<ConfigurationFieldModel>();

			foreach (var configurationField in configurationFields)
			{
                if ((configurationField.Type == Localizer.LocalizeString("Types.Structure") || configurationField.IsArray) && display)
                {
                    allConfigurationFields.Add(new ConfigurationFieldModel
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

                if (configurationField.Type == Localizer.LocalizeString("Types.Structure"))
				{
                    var structure = configuration.ConfigurationStructures.FirstOrDefault(s => s.Name == configurationField.Common);

                    if (structure != null)
                    {
                        if (configurationField.IsArray)
                        {
                            for (int i = 0; i < configurationField.ArrayLength; i++)
                            {
                                var structureFields = configuration.GetAllFieldForConfiguration(structure,
                                    configurationField.Position + position + (configuration.GetLengthByType(configurationField) * i));

                                for (int j = 0; j < structureFields.Count; j++)
                                {
                                    structureFields[j].Name = configurationField.Name + "[" + i + "]" + "." + structureFields[j].Name;
                                }

                                allConfigurationFields.AddRange(structureFields);
                            }
                        }
					    else
                        {
                            var structureFields = configuration.GetAllFieldForConfiguration(structure,
                                configurationField.Position + position);

                            for (int i = 0; i < structureFields.Count; i++)
                            {
                                structureFields[i].Name = configurationField.Name + "." + structureFields[i].Name;
                            }

                            allConfigurationFields.AddRange(structureFields);
                        }
                    }
				}
				else
				{
					if (configurationField.IsArray)
					{
                        for (int i = 0; i < configurationField.ArrayLength; i++)
						{
							allConfigurationFields.Add(new ConfigurationFieldModel
                            {
								Name = configurationField.Name + "[" + i + "]",
								Description = configurationField.Description,
								Type = configurationField.Type,
								SequenceType = configurationField.SequenceType,
								Position = configurationField.Position + position + (configuration.GetLengthByType(configurationField) * i),
								IsArray = configurationField.IsArray,
								ArrayLength = configurationField.ArrayLength,
								Common = configurationField.Common
							});
						}
					}
					else
					{
						allConfigurationFields.Add(new ConfigurationFieldModel
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
				}
			}

			return allConfigurationFields;
		}

        ///  <summary>
        /// 		Get length by structure name
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="structureName"></param>
        ///  <returns></returns>
        private static long GetLengthByStructureName(this ConfigurationModel configuration, string structureName)
        {
            var structure = configuration.ConfigurationStructures.FirstOrDefault(s => s.Name == structureName);

            if (structure == null)
            {
                return 0;
            }

            ConfigurationFieldModel lastConfigurationField = configuration.GetAllFieldForConfiguration(structure, 0).OrderBy(o => o.Position).LastOrDefault();

            if (lastConfigurationField != null)
            {
                return lastConfigurationField.Position + configuration.GetLengthByType(lastConfigurationField);
            }

            return 0;
        }

        ///  <summary>
        /// 		Get length for configuration class
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="configurationClass"></param>
        ///  <returns></returns>
        public static long GetLengthForConfiguration(this ConfigurationModel configuration, ConfigurationClassModel configurationClass)
        {
            ConfigurationFieldModel lastConfigurationField = configuration.GetAllFieldForConfiguration(configurationClass, 0).OrderBy(o => o.Position).LastOrDefault();

            if (lastConfigurationField != null)
            {
                return lastConfigurationField.Position + configuration.GetLengthByType(lastConfigurationField);
            }

            return 0;
        }

        ///  <summary>
        /// 		Get length for configuration field
        ///  </summary>
        ///  <param name="configuration"></param>
        ///  <param name="configurationField"></param>
        ///  <returns></returns>
        public static long GetLengthForConfiguration(this ConfigurationModel configuration, ConfigurationFieldModel configurationField)
        {
            ConfigurationFieldModel lastConfigurationField = configuration.GetAllFieldForConfiguration(configurationField, 0).OrderBy(o => o.Position).LastOrDefault();

            if (lastConfigurationField != null)
            {
                return (lastConfigurationField.Position - configurationField.Position) + configuration.GetLengthByType(lastConfigurationField);
            }

            return 0;
        }

        /// <summary>
        ///     Get entry field by index
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configurationClass"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ConfigurationFieldModel GetEntryFieldByIndex(this ConfigurationModel configuration, ConfigurationClassModel configurationClass, long index)
        {
            List<ConfigurationFieldModel> configurationFields = configuration.GetAllFieldForConfiguration(configurationClass);

            foreach (var configurationField in configurationFields)
            {
                long positionField = configurationField.Position;
                long lengthField = configuration.GetLengthForConfiguration(configurationField) - 1;

                if (positionField <= index && positionField + lengthField >= index)
                {
                    return configurationField;
                }
            }

            return null;
        }

        /// <summary>
        ///     Check field for uniqueness of space
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configurationFields"></param>
        /// <param name="configurationField"></param>
        /// <returns></returns>
        public static bool CheckFieldForUniquenessSpace(this ConfigurationModel configuration, List<ConfigurationFieldModel> configurationFields, ConfigurationFieldModel configurationField)
        {
            if (configurationField.Type == Localizer.LocalizeString("Types.Structure") || configurationField.IsArray)
            {
                return true;
            }

            foreach (var checkConfigurationField in configurationFields)
            {
                if (checkConfigurationField.Type == Localizer.LocalizeString("Types.Structure") || checkConfigurationField.IsArray)
                {
                    continue;
                }

                if (configurationField == checkConfigurationField)
                {
                    continue;
                }

                var configurationFieldLength = configuration.GetLengthByType(configurationField) - 1;
                var configurationFieldPosition = configurationField.Position;

                var checkConfigurationFieldLength = configuration.GetLengthByType(checkConfigurationField) - 1;
                var checkConfigurationFieldPosition = checkConfigurationField.Position;

                if (configurationFieldPosition >= checkConfigurationFieldPosition &&
                    configurationFieldPosition <= checkConfigurationFieldPosition + checkConfigurationFieldLength)
                {
                    return false;
                }

                if (configurationFieldPosition + configurationFieldLength >= checkConfigurationFieldPosition &&
                    configurationFieldPosition + configurationFieldLength <= checkConfigurationFieldPosition + checkConfigurationFieldLength)
                {
                    return false;
                }

                if (configurationFieldPosition <= checkConfigurationFieldPosition &&
                    configurationFieldPosition + configurationFieldLength >= checkConfigurationFieldPosition + checkConfigurationFieldLength)
                {
                    return false;
                }
            }

            return true;
        }

        #region Rename or Delete fields

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

		#endregion
	}
}