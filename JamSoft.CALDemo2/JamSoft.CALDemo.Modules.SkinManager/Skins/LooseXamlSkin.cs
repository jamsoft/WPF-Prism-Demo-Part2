#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : LooseXamlSkin.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;

    using JamSoft.CALDemo.Modules.SkinManager.Core;

    /// <summary>
    /// The loose XAML Skin class
    /// </summary>
    public sealed class LooseXamlSkin : Skin
    {
        /// <summary>The _sources</summary>
        private readonly List<Uri> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="LooseXamlSkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="source">The source.</param>
        public LooseXamlSkin(string name, string description, Uri source)
            : base(name, description)
        {
            _sources = new List<Uri> { source };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LooseXamlSkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="sources">The sources.</param>
        public LooseXamlSkin(string name, string description, IList<Uri> sources)
            : base(name, description)
        {
            _sources = new List<Uri>(sources);
        }

        /// <summary>Loads the resources.</summary>
        /// <exception cref="Exception">Thrown when setting the skinDirectory source property.</exception>
        protected override void LoadResources()
        {
            foreach (var uri in _sources)
            {
                var skinDictionary = new ResourceDictionary();
                try
                {
                    skinDictionary.Source = uri;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Change error: " + ex);
                    throw;
                }

                Resources.Add(skinDictionary);
            }
        }
    }
}