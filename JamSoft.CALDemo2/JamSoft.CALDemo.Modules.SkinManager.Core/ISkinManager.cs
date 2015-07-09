#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager.Core
// File Name    : ISkinManager.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Core
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The ISkinManager <see langword="interface"/>
    /// </summary>
    public interface ISkinManager
    {
        /// <summary>Gets the skins.</summary>
        /// <value>The skins.</value>
        ObservableCollection<Skin> Skins { get; }

        /// <summary>Gets the current skin.</summary>
        /// <value>The current skin.</value>
        Skin CurrentSkin { get; }

        /// <summary>Loads the skin.</summary>
        /// <param name="skinName">Name of the skin.</param>
        void LoadSkin(string skinName);
    }
}