#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : DirectAssemblySkin.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Skins
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Windows;

    using JamSoft.CALDemo.Modules.SkinManager.Core;

    /// <summary>
    /// The class for use when loading skins from unreferenced dll libraries
    /// </summary>
    public class DirectAssemblySkin : Skin
    {
        /// <summary>The _full name</summary>
        private readonly AssemblyName _fullName;

        /// <summary>The _resource name</summary>
        private string _resourceName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <exception cref="System.ArgumentException">Invalid assembly path;assemblyPath</exception>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        ///     is null. </exception>
        /// <exception cref="FileNotFoundException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        ///     is not found. </exception>
        /// <exception cref="SecurityException">The caller does not have path discovery permission. </exception>
        /// <exception cref="BadImageFormatException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        ///     is not a valid assembly. </exception>
        /// <exception cref="FileLoadException">An assembly or module was loaded twice with two different sets of evidence. </exception>
        public DirectAssemblySkin(string name, string description, string assemblyPath)
            : base(name, description)
        {
            if (string.IsNullOrEmpty(assemblyPath))
            {
                throw new ArgumentException("Invalid assembly path", "assemblyPath");
            }

            _fullName = AssemblyName.GetAssemblyName(assemblyPath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <exception cref="System.ArgumentException">Invalid resource name;assemblyPath</exception>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        ///     is null. </exception>
        /// <exception cref="FileLoadException">An assembly or module was loaded twice with two different sets of evidence. </exception>
        /// <exception cref="BadImageFormatException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        ///     is not a valid assembly. </exception>
        /// <exception cref="SecurityException">The caller does not have path discovery permission. </exception>
        /// <exception cref="FileNotFoundException"><paramref>
        ///         <name>assemblyFile</name>
        ///     </paramref>
        /// is not found. </exception>
        protected DirectAssemblySkin(string name, string description, string assemblyPath, string resourceName)
            : base(name, description)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentException("Invalid resource name", "assemblyPath");
            }

            _fullName = AssemblyName.GetAssemblyName(assemblyPath);
            _resourceName = resourceName;
            FixResourceName();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="fullName">The full name.</param>
        /// <exception cref="System.ArgumentException">Invalid assembly name;fullName</exception>
        protected DirectAssemblySkin(string name, string description, AssemblyName fullName)
            : base(name, description)
        {
            if (fullName == null)
            {
                throw new ArgumentException("Invalid assembly name", "fullName");
            }

            _fullName = fullName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <exception cref="System.ArgumentException">Invalid resource name;assemblyPath</exception>
        protected DirectAssemblySkin(string name, string description, AssemblyName fullName, string resourceName)
            : base(name, description)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentException("Invalid resource name", "resourceName");
            }

            _fullName = fullName;
            _resourceName = resourceName;
            FixResourceName();
        }

        /// <summary>Gets the full name.</summary>
        /// <value>The full name.</value>
        protected AssemblyName FullName
        {
            get
            {
                return _fullName;
            }
        }

        /// <summary>Loads the resources.</summary>
        protected override sealed void LoadResources()
        {
            var skinResolver = PreLoadResources();
            try
            {
                var skinBamlStreams = skinResolver.GetSkinBamlStreams(_fullName, _resourceName);
                foreach (var resourceStream in skinBamlStreams)
                {
                    var skinResource = BamlHelper.LoadBaml<ResourceDictionary>(resourceStream);
                    if (skinResource != null)
                    {
                        Resources.Add(skinResource);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PostLoadResources();
            }
        }

        /// <summary>Pres the load resources.</summary>
        /// <returns>a <see cref="ISkinBamlResolver"/> instance</returns>
        protected virtual ISkinBamlResolver PreLoadResources()
        {
            return new SkinBamlResolver();
        }

        /// <summary>Posts the load resources.</summary>
        protected virtual void PostLoadResources()
        {
        }

        /// <summary>Fixes the name of the resource.</summary>
        private void FixResourceName()
        {
            _resourceName = _resourceName.ToLower().Replace(".xaml", ".baml");
        }
    }
}