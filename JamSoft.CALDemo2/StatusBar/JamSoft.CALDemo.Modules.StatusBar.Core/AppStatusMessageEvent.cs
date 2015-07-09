#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.StatusBar.Core
// File Name    : AppStatusMessageEvent.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.StatusBar.Core
{
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// The AppStatusMessageEvent event
    /// </summary>
    public class AppStatusMessageEvent : PubSubEvent<string>
    {
    }
}