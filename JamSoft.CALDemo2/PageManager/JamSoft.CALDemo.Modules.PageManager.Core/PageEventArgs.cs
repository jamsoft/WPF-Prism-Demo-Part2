#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.PageManager.Core
// File Name    : PageEventArgs.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.PageManager.Core
{
    using System;

    /// <summary>
    /// The page event arguments
    /// </summary>
    public class PageEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageEventArgs"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        public PageEventArgs(IPage page)
        {
            Page = page;
        }

        /// <summary>Gets the page.</summary>
        /// <value>The page.</value>
        public IPage Page { get; private set; }
    }
}