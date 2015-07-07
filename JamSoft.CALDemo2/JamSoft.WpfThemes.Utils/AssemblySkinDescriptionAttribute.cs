#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.WpfThemes.Utils
// File Name    : AssemblySkinDescriptionAttribute.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.WpfThemes.Utils
{
    using System;

    /// <summary>
    /// The assembly description attribute class
    /// </summary>
    public class AssemblySkinDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySkinDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="assemblySkinDescription">The assembly skin description.</param>
        public AssemblySkinDescriptionAttribute(string assemblySkinDescription)
        {
            AssemblySkinDescription = assemblySkinDescription;
        }

        /// <summary>Gets or sets the assembly skin description.</summary>
        /// <value>The assembly skin description.</value>
        public string AssemblySkinDescription { get; set; }
    }
}