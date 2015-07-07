#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : SkinBamlResolver.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// The skin baml resolver class
    /// </summary>
    internal class SkinBamlResolver : MarshalByRefObject, ISkinBamlResolver
    {
        #region ISkinResolver Members

        /// <summary>Get Skins Interface Member</summary>
        /// <param name="skinAssemblyName">the assembly name containing the skin to load</param>
        /// <returns>a list of baml streams</returns>
        List<Stream> ISkinBamlResolver.GetSkinBamlStreams(AssemblyName skinAssemblyName)
        {
            var resolver = this as ISkinBamlResolver;
            return resolver.GetSkinBamlStreams(skinAssemblyName, string.Empty);
        }

        /// <summary>Gets the skin baml streams.</summary>
        /// <param name="skinAssemblyName">Name of the skin assembly.</param>
        /// <param name="bamlResourceName">Name of the baml resource.</param>
        /// <returns>a list of baml streams</returns>
        List<Stream> ISkinBamlResolver.GetSkinBamlStreams(AssemblyName skinAssemblyName, string bamlResourceName)
        {
            var skinBamlStreams = new List<Stream>();
            var skinAssembly = Assembly.Load(skinAssemblyName);
            var resourcesNames = skinAssembly.GetManifestResourceNames();
            foreach (var resourceName in resourcesNames)
            {
                var resourceInfo = skinAssembly.GetManifestResourceInfo(resourceName);
                if (resourceInfo != null && resourceInfo.ResourceLocation != ResourceLocation.ContainedInAnotherAssembly)
                {
                    var resourceStream = skinAssembly.GetManifestResourceStream(resourceName);

                    if (resourceStream != null)
                    {
                        using (var resourceReader = new ResourceReader(resourceStream))
                        {
                            skinBamlStreams.AddRange(from DictionaryEntry entry in resourceReader where IsRelevantResource(entry, bamlResourceName) select entry.Value as Stream);
                        }
                    }
                }
            }

            return skinBamlStreams;
        }

        /// <summary>
        /// Determines whether is relevant resource the specified <paramref name="entry"/>.
        /// </summary>
        /// <param name="entry">The <paramref name="entry"/>.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns><see langword="true"/> if is relevant</returns>
        private bool IsRelevantResource(DictionaryEntry entry, string resourceName)
        {
            var entryName = entry.Key as string;
            var extension = Path.GetExtension(entryName);
            return string.Compare(extension, ".baml", StringComparison.OrdinalIgnoreCase) == 0 && entry.Value is Stream && (string.IsNullOrEmpty(resourceName) || string.Compare(resourceName, entryName, StringComparison.OrdinalIgnoreCase) == 0);
        }

        #endregion
    }
}