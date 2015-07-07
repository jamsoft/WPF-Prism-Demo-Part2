#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager
// File Name    : ISettingsView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager
{
    using JamSoft.CALDemo.Modules.SettingsManager.Core;
    using JamSoft.CALDemo.Modules.SkinManager.Core;

    /// <summary>
    /// The ISettingsView <see langword="interface"/>
    /// </summary>
    public interface ISettingsView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        ISettingsManagerPresentationModel Model { set; }

        /// <summary>Sets the skin picker model.</summary>
        /// <value>The skin picker model.</value>
        ISkinManager SkinPickerModel { set; }
    }
}