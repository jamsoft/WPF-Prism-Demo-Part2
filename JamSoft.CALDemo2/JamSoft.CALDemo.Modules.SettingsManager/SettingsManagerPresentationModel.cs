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
    using JamSoft.CALDemo.Modules.PageManager.Core;
    using JamSoft.CALDemo.Modules.SettingsManager.Core;
    using JamSoft.CALDemo.Modules.SkinManager.Core;

    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// </summary>
    public class SettingsManagerPresentationModel : IPage, ISettingsManagerPresentationModel
    {
        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>The _page manager</summary>
        private readonly IPageManager _pageManager;

        /// <summary>The _settings manager</summary>
        private readonly SettingsManager _settingsManager;

        /// <summary>The _skin manager</summary>
        private readonly ISkinManager _skinManager;

        /// <summary>The _view</summary>
        private readonly ISettingsView _view;

        /// <summary>The _is active page</summary>
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
            _eventAggregator = eventAggregator;
            _pageManager = pageManager;
            _skinManager = skinManager;

            _view = view;
            _view.Model = this;
            _view.SkinPickerModel = _skinManager;

            _pageManager.Pages.Add(this);

            _eventAggregator.GetEvent<SettingChangedEvent>().Subscribe(OnSettingChanged, false);
            _settingsManager = new SettingsManager("defaultsettings.settings");
            InitialiseSettings();
        }

        /// <summary>
        /// </summary>
        public string ID
        {
            get
            {
                return "Settings";
            }
        }

        /// <summary>
        /// </summary>
        public float Position
        {
            get
            {
                return 50F;
            }
        }

        /// <summary>
        /// </summary>
        public object View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>
        /// </summary>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }

        /// <summary>Initialises the settings.</summary>
        private void InitialiseSettings()
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

        /// <summary>Gets the setting default value.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T GetSettingDefaultValue<T>(string key)
        {
            return (T)_settingsManager.GetSettingValue<T>(key);
        }

        /// <summary>Saves the settings.</summary>
        public void SaveSettings()
        {
            _settingsManager.SetSettingValue("UserSelectedSkinName", _skinManager.CurrentSkin.Name);
            _settingsManager.SaveSettingsFile();
        }
    }
}