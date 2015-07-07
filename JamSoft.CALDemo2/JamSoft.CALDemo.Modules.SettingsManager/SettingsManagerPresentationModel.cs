#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager
// File Name    : SettingsManagerPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager
{
    using System;
    using System.IO;
    using System.Security;

    using JamSoft.CALDemo.Modules.PageManager.Core;
    using JamSoft.CALDemo.Modules.SettingsManager.Core;
    using JamSoft.CALDemo.Modules.SkinManager.Core;

    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// Settings manager presentation model
    /// </summary>
    public class SettingsManagerPresentationModel : IPage, ISettingsManagerPresentationModel
    {
        /// <summary>The _settings manager</summary>
        private readonly SettingsManager _settingsManager;

        /// <summary>The _skin manager</summary>
        private readonly ISkinManager _skinManager;

        /// <summary>The _view</summary>
        private readonly ISettingsView _view;

        /// <summary>The _is active page</summary>
        // ReSharper disable once NotAccessedField.Local
        private bool _isActivePage;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsManagerPresentationModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="pageManager">The page manager.</param>
        /// <param name="view">The view.</param>
        /// <param name="skinManager">The skin manager.</param>
        public SettingsManagerPresentationModel(
            IEventAggregator eventAggregator, 
            IPageManager pageManager, 
            ISettingsView view, 
            ISkinManager skinManager)
        {
            _skinManager = skinManager;

            _view = view;
            _view.Model = this;
            _view.SkinPickerModel = _skinManager;

            pageManager.Pages.Add(this);

            eventAggregator.GetEvent<SettingChangedEvent>().Subscribe(OnSettingChanged, false);
            _settingsManager = new SettingsManager("defaultsettings.settings");
            InitializeSettings();
        }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public string ID
        {
            get
            {
                return "Settings";
            }
        }

        /// <summary>Gets the position.</summary>
        /// <value>The position.</value>
        public float Position
        {
            get
            {
                return 50F;
            }
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public object View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>Sets a value indicating whether <see langword="this"/> instance is active page.</summary>
        /// <value>
        /// true if this instance is active page; otherwise, false.
        /// </value>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }

        /// <summary>Gets the setting default value.</summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="key">The parameter <paramref name="key"/> type.</param>
        /// <returns>the value</returns>
        public T GetSettingDefaultValue<T>(string key)
        {
            return _settingsManager.GetSettingValue<T>(key);
        }

        /// <summary>Saves the settings.</summary>
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
        public void SaveSettings()
        {
            _settingsManager.SetSettingValue("UserSelectedSkinName", _skinManager.CurrentSkin.Name);
            _settingsManager.SaveSettingsFile();
        }

        /// <summary>Initializes the settings.</summary>
        private void InitializeSettings()
        {
            _skinManager.LoadSkin(_settingsManager.GetSettingValue<string>("UserSelectedSkinName"));
        }

        /// <summary>Raises the <see cref="E:SettingChanged" /> event.</summary>
        /// <param name="newSettingValue">The <see cref="SettingChangedEventArgs"/> instance containing the event data.</param>
        private void OnSettingChanged(SettingChangedEventArgs newSettingValue)
        {
            if (newSettingValue.SettingValue != null)
            {
                _settingsManager.SetSettingValue(newSettingValue.SettingName, newSettingValue.SettingValue);
            }
        }
    }
}