#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ToolBar.Core
// File Name    : IToolBarPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ToolBar.Core
{
    using System.Windows.Controls;

    /// <summary>
    /// The IToolBarPresentationModel <see langword="interface"/>
    /// </summary>
    public interface IToolBarPresentationModel
    {
        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        IToolBarView View { get; }

        /// <summary>Adds the tool bar item.</summary>
        /// <param name="control">The control.</param>
        void AddToolBarItem(Control control);

        /// <summary>Removes the tool bar item.</summary>
        /// <param name="control">The control.</param>
        void RemoveToolBarItem(Control control);
    }
}