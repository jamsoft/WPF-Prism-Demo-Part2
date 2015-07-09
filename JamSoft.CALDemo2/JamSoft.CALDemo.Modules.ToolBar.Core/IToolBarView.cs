#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ToolBar.Core
// File Name    : IToolBarView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ToolBar.Core
{
    using System.Windows.Controls;

    /// <summary>
    /// The IToolBarView <see langword="interface"/>
    /// </summary>
    public interface IToolBarView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        IToolBarPresentationModel Model { set; }

        /// <summary>Gets the dynamic tool panel.</summary>
        /// <value>The dynamic tool panel.</value>
        StackPanel DynamicToolPanel { get; }
    }
}