#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager
// File Name    : SettingsManager.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// </summary>
    internal class SettingsManager
    {
        /// <summary>The settings file</summary>
        public readonly Uri SettingsFile;

        /// <summary>The _settings</summary>
        private PropertiesCollection _settings = new PropertiesCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsManager"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        internal SettingsManager(string file)
        {
            SettingsFile = new Uri(file, UriKind.RelativeOrAbsolute);

            ReadSettingsFile();
        }

        /// <summary>Sets the setting value.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetSettingValue(string key, object value)
        {
            _settings.SetSetting(key, value);
        }

        /// <summary>Gets the setting value.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T GetSettingValue<T>(string key)
        {
            return (T)_settings.GetSettingValue(key);
        }

        /// <summary>Reads the settings file.</summary>
        private void ReadSettingsFile()
        {
            var e = File.Exists(SettingsFile.OriginalString);
            var reader = new StreamReader(SettingsFile.OriginalString);
            var _settingsSerializer = new XmlSerializer(typeof(PropertiesCollection));
            _settings = (PropertiesCollection)_settingsSerializer.Deserialize(reader);
        }

        /// <summary>Saves the settings file.</summary>
        public void SaveSettingsFile()
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            var _settingsSerializer = new XmlSerializer(typeof(PropertiesCollection));
            var writer = new StreamWriter(SettingsFile.OriginalString);
            _settingsSerializer.Serialize(writer, _settings);
        }
    }
}