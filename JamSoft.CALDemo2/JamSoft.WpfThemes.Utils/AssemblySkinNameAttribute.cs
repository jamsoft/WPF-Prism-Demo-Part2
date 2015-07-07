#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.WpfThemes.Utils
// File Name    : AssemblySkinNameAttribute.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.WpfThemes.Utils
{
    using System;

    /// <summary>
    /// The AssemblySkinNameAttribute class
    /// </summary>
    public class AssemblySkinNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySkinNameAttribute"/> class.
        /// </summary>
        /// <param name="assemblySkinName">Name of the assembly skin.</param>
        public AssemblySkinNameAttribute(string assemblySkinName)
        {
            AssemblySkinName = assemblySkinName;
        }

        /// <summary>Gets or sets the name of the assembly skin.</summary>
        /// <value>The name of the assembly skin.</value>
        public string AssemblySkinName { get; set; }
    }
}