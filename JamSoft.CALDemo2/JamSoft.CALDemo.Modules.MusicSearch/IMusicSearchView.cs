#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : IMusicSearchView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    /// <summary>
    /// The music search view
    /// </summary>
    public interface IMusicSearchView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        IMusicSearchPresenterModel Model { set; }
    }
}