#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Shell
// File Name    : ShellPresenter.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo
{
    /// <summary>
    /// The shell presenter class
    /// </summary>
    public class ShellPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ShellPresenter(IShellView view)
        {
            View = view;
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public IShellView View { get; private set; }
    }
}