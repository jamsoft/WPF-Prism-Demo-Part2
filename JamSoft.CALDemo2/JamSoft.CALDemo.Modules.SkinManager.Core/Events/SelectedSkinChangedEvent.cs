#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager.Core
// File Name    : SelectedSkinChangedEvent.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Core.Events
{
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// The SelectedSkinChangedEvent event arguments
    /// </summary>
    public class SelectedSkinChangedEvent : PubSubEvent<string>
    {
    }
}