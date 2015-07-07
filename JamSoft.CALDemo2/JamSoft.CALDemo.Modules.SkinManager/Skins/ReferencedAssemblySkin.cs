#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : ReferencedAssemblySkin.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Skins
{
    using System;
    using System.Windows;

    using JamSoft.CALDemo.Modules.SkinManager.Core;

    /// <summary>
    /// The referenced skin assembly class
    /// </summary>
    public sealed class ReferencedAssemblySkin : Skin
    {
        /// <summary>The _resource URI</summary>
        private readonly Uri _resourceUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferencedAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="resourceUri">The resource URI.</param>
        public ReferencedAssemblySkin(string name, string description, Uri resourceUri)
            : base(name, description)
        {
            _resourceUri = resourceUri;
        }

        /// <summary>Loads the resources.</summary>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>resourceLocator</name>
        ///     </paramref>
        ///     is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <see cref="P:System.Uri.OriginalString" /> property of the <paramref>
        ///         <name>resourceLocator</name>
        ///     </paramref>
        ///     <see cref="T:System.Uri" /> parameter is null.</exception>
        /// <exception cref="Exception">The file is not a XAML file.</exception>
        protected override void LoadResources()
        {
            var resource = (ResourceDictionary)Application.LoadComponent(_resourceUri);
            Resources.Add(resource);
        }
    }
}