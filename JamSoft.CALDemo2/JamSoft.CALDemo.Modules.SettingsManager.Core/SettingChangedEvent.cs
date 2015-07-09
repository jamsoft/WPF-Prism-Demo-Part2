#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager.Core
// File Name    : SettingChangedEvent.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager.Core
{
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// The SettingChangedEvent event
    /// </summary>
    public class SettingChangedEvent : PubSubEvent<SettingChangedEventArgs>
    {
    }
}