#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : AppDomainAssemblySkin.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Skins
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security;

    /// <summary>
    /// The AppDomainAssemblySkin loading class
    /// </summary>
    public class AppDomainAssemblySkin : DirectAssemblySkin
    {
        /// <summary>
        /// The _assembly skin domain
        /// </summary>
        private AppDomain _assemblySkinDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <exception cref="ArgumentException">Invalid assembly path;assemblyPath</exception>
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
        public AppDomainAssemblySkin(string name, string description, string assemblyPath)
            : base(name, description, assemblyPath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="fullName">The full name.</param>
        public AppDomainAssemblySkin(string name, string description, AssemblyName fullName)
            : base(name, description, fullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <exception cref="ArgumentException">Invalid assembly path;assemblyPath</exception>
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
        public AppDomainAssemblySkin(string name, string description, string assemblyPath, string resourceName)
            : base(name, description, assemblyPath, resourceName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainAssemblySkin"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="resourceName">Name of the resource.</param>
        public AppDomainAssemblySkin(string name, string description, AssemblyName fullName, string resourceName)
            : base(name, description, fullName, resourceName)
        {
        }

        /// <summary>Pres the load resources.</summary>
        /// <returns>the <see cref="ISkinBamlResolver"/> instance</returns>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>assemblyName</name>
        ///     </paramref>
        ///     or <paramref>
        ///         <name>typeName</name>
        ///     </paramref>
        ///     is null. </exception>
        /// <exception cref="MissingMethodException">No matching public constructor was found. </exception>
        /// <exception cref="TypeLoadException"><paramref>
        ///         <name>typename</name>
        ///     </paramref>
        ///     was not found in <paramref>
        ///         <name>assemblyName</name>
        ///     </paramref>
        ///     . </exception>
        /// <exception cref="FileNotFoundException"><paramref>
        ///         <name>assemblyName</name>
        ///     </paramref>
        ///     was not found. </exception>
        /// <exception cref="MethodAccessException">The caller does not have permission to call this constructor. </exception>
        /// <exception cref="AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception>
        /// <exception cref="BadImageFormatException"><paramref>
        ///         <name>assemblyName</name>
        ///     </paramref>
        ///     is not a valid assembly. -or-Version 2.0 or later of the common language runtime is currently loaded and <paramref>
        ///         <name>assemblyName</name>
        ///     </paramref>
        ///     was compiled with a later version.</exception>
        /// <exception cref="FileLoadException">An assembly or module was loaded twice with two different evidences. </exception>
        protected override ISkinBamlResolver PreLoadResources()
        {
            _assemblySkinDomain = AppDomain.CreateDomain(Name);
            var skinResolver = (ISkinBamlResolver)_assemblySkinDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(SkinBamlResolver).FullName);
            return skinResolver;
        }

        /// <summary>Posts the load resources.</summary>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>domain</name>
        ///     </paramref>
        ///     is <c>null</c>. </exception>
        /// <exception cref="CannotUnloadAppDomainException"><paramref>
        ///         <name>domain</name>
        ///     </paramref>
        ///     could not be unloaded. </exception>
        /// <exception cref="Exception">An error occurred during the unload process.</exception>
        protected override void PostLoadResources()
        {
            if (_assemblySkinDomain != null)
            {
                AppDomain.Unload(_assemblySkinDomain);
                _assemblySkinDomain = null;
            }
        }
    }
}