#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager.Core
// File Name    : SettingChangedEventArgs.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager.Core
{
    using System;

    /// <summary>
    /// The SettingChangedEventArgs event args
    /// </summary>
    public class SettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingChangedEventArgs"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public SettingChangedEventArgs(string name, object value)
        {
            SettingName = name;
            SettingValue = value;
        }

        /// <summary>Gets the name of the setting.</summary>
        /// <value>The name of the setting.</value>
        public string SettingName { get; private set; }

        /// <summary>Gets the setting value.</summary>
        /// <value>The setting value.</value>
        public object SettingValue { get; private set; }
    }
}