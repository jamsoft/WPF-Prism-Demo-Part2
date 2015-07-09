#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager.Core
// File Name    : ISettingsManagerPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager.Core
{
    /// <summary>
    /// The ISettingsManagerPresentationModel <see langword="interface"/>
    /// </summary>
    public interface ISettingsManagerPresentationModel
    {
        /// <summary>Saves the settings.</summary>
        void SaveSettings();

        /// <summary>Gets the setting default value.</summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="key">The <paramref name="key"/>.</param>
        /// <returns>The settings value</returns>
        T GetSettingDefaultValue<T>(string key);
    }
}