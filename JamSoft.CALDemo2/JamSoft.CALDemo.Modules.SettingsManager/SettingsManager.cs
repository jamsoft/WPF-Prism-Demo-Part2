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
    using System.Security;
    using System.Xml.Serialization;

    /// <summary>
    /// The settings manager class
    /// </summary>
    internal class SettingsManager
    {
        /// <summary>The settings file</summary>
        private readonly Uri _settingsFile;

        /// <summary>The _settings</summary>
        private PropertiesCollection _settings = new PropertiesCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsManager"/> class.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        internal SettingsManager(string file)
        {
            _settingsFile = new Uri(file, UriKind.RelativeOrAbsolute);
            ReadSettingsFile();
        }

        /// <summary>
        /// Sets the setting <paramref name="value"/>.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetSettingValue(string key, object value)
        {
            _settings.SetSetting(key, value);
        }

        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <typeparam name="T">
        /// the value type
        /// </typeparam>
        /// <param name="key">
        /// The <paramref name="key"/>.
        /// </param>
        /// <returns>
        /// the value
        /// </returns>
        public T GetSettingValue<T>(string key)
        {
            return (T)_settings.GetSettingValue(key);
        }
        
        /// <summary>Saves the settings file.</summary>
        /// <exception cref="ArgumentException"><paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     is an empty string (""). -or-<paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     contains the name of a system device (com1, com2, and so on).</exception>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     is <see langword="null"/>. </exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must not exceed 248 characters, and file names must not exceed 260 characters. </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="IOException"><paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     includes an incorrect or invalid syntax for file name, directory name, or volume label syntax. </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission. </exception>
        /// <exception cref="UnauthorizedAccessException">Access is denied. </exception>
        public void SaveSettingsFile()
        {
            var settingsSerializer = new XmlSerializer(typeof(PropertiesCollection));
            var writer = new StreamWriter(_settingsFile.OriginalString);
            settingsSerializer.Serialize(writer, _settings);
        }

        /// <summary>Reads the settings file.</summary>
        private void ReadSettingsFile()
        {
            if (File.Exists(_settingsFile.OriginalString))
            {
                var reader = new StreamReader(_settingsFile.OriginalString);
                var settingsSerializer = new XmlSerializer(typeof(PropertiesCollection));
                _settings = (PropertiesCollection)settingsSerializer.Deserialize(reader);
            }
        }
    }
}