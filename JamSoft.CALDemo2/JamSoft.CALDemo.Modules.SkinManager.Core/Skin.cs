#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager.Core
// File Name    : Skin.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Core
{
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    ///     An <see langword="abstract" /> class that defines the structure of a
    ///     loadable skin object
    /// </summary>
    public abstract class Skin
    {
        /// <summary>The <see langword="null"/> skin class instance</summary>
        public static readonly Skin Null = new NullSkin();

        /// <summary>The _description</summary>
        private readonly string _description;

        /// <summary>The _name</summary>
        private readonly string _name;

        /// <summary>The _resources</summary>
        private readonly List<ResourceDictionary> _resources = new List<ResourceDictionary>();

        /// <summary>Initializes a new instance of the <see cref="Skin"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        protected Skin(string name, string description)
        {
            _name = name;
            _description = description;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Skin"/> class from being created.
        /// </summary>
        private Skin()
        {
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>Gets the description.</summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return _description;
            }
        }

        /// <summary>Gets the resources.</summary>
        /// <value>The resources.</value>
        protected List<ResourceDictionary> Resources
        {
            get
            {
                return _resources;
            }
        }

        /// <summary>Loads this instance.</summary>
        public virtual void Load()
        {
            if (Resources.Count != 0)
            {
                // Already loaded
                return;
            }

            LoadResources();
            foreach (var skinResource in Resources)
            {
                Application.Current.Resources.MergedDictionaries.Add(skinResource);
            }
        }

        /// <summary>Unloads <c>this</c> instance.</summary>
        public virtual void Unload()
        {
            foreach (var skinResource in Resources)
            {
                Application.Current.Resources.MergedDictionaries.Remove(skinResource);
            }

            Resources.Clear();
        }

        /// <summary>Loads the resources.</summary>
        protected abstract void LoadResources();

        /// <summary>
        /// A default <see>
        ///         <cref><see langword="null"/></cref>
        ///     </see>
        ///     skin class
        /// </summary>
        private sealed class NullSkin : Skin
        {
            /// <summary>Loads the resources.</summary>
            protected override void LoadResources()
            {
            }
        }
    }
}