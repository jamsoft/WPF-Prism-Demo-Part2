#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.StatusBar
// File Name    : IStatusBarView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.StatusBar
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStatusBarView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        IStatusBarPresentationModel Model { set; }
    }
}