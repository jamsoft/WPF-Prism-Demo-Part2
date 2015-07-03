#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : IMusicSearchPresenterModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    /// <summary>
    /// The music search presenter model
    /// </summary>
    public interface IMusicSearchPresenterModel
    {
        /// <summary>Activates the model.</summary>
        void ActivateModel();

        /// <summary>Deactives the model.</summary>
        void DeactiveModel();
    }
}