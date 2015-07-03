#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : ISkinBamlResolver.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    ///     Interface for defining baml resolver methods
    /// </summary>
    public interface ISkinBamlResolver
    {
        /// <summary>Get Skins Interface Member</summary>
        /// <param name="skinAssemblyName">Name of the skin assembly.</param>
        /// <returns></returns>
        List<Stream> GetSkinBamlStreams(AssemblyName skinAssemblyName);

        /// <summary>Get Skins Interface Member</summary>
        /// <param name="skinAssemblyName">Name of the skin assembly.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        List<Stream> GetSkinBamlStreams(AssemblyName skinAssemblyName, string resourceName);
    }
}