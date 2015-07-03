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

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System;
    using System.Reflection;

    using JamSoft.CALDemo.Modules.SkinManager.Skins;

    /// <summary>
    /// 
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
        public AppDomainAssemblySkin(string name, string description, string assemblyPath, string resourceName)
            : base(name, assemblyPath, resourceName)
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
        /// <returns></returns>
        protected override ISkinBamlResolver PreLoadResources()
        {
            _assemblySkinDomain = AppDomain.CreateDomain(Name);
            var skinResolver =
                (ISkinBamlResolver)
                _assemblySkinDomain.CreateInstanceAndUnwrap(
                    Assembly.GetExecutingAssembly().FullName, 
                    typeof(SkinBamlResolver).FullName);
            return skinResolver;
        }

        /// <summary>Posts the load resources.</summary>
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