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
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// 
    /// </summary>
    internal class SkinBamlResolver : MarshalByRefObject, ISkinBamlResolver
    {
        #region ISkinResolver Members

        /// <summary>Get Skins Interface Member</summary>
        /// <param name="skinAssemblyName"></param>
        /// <returns></returns>
        List<Stream> ISkinBamlResolver.GetSkinBamlStreams(AssemblyName skinAssemblyName)
        {
            var resolver = this as ISkinBamlResolver;
            return resolver.GetSkinBamlStreams(skinAssemblyName, string.Empty);
        }

        /// <summary>Gets the skin baml streams.</summary>
        /// <param name="skinAssemblyName">Name of the skin assembly.</param>
        /// <param name="bamlResourceName">Name of the baml resource.</param>
        /// <returns></returns>
        List<Stream> ISkinBamlResolver.GetSkinBamlStreams(AssemblyName skinAssemblyName, string bamlResourceName)
        {
            var skinBamlStreams = new List<Stream>();
            var skinAssembly = Assembly.Load(skinAssemblyName);
            var resourcesNames = skinAssembly.GetManifestResourceNames();
            foreach (var resourceName in resourcesNames)
            {
                var resourceInfo = skinAssembly.GetManifestResourceInfo(resourceName);
                if (resourceInfo.ResourceLocation != ResourceLocation.ContainedInAnotherAssembly)
                {
                    var resourceStream = skinAssembly.GetManifestResourceStream(resourceName);

                    using (var resourceReader = new ResourceReader(resourceStream))
                    {
                        foreach (DictionaryEntry entry in resourceReader)
                        {
                            if (IsRelevantResource(entry, bamlResourceName))
                            {
                                skinBamlStreams.Add(entry.Value as Stream);
                            }
                        }
                    }
                }
            }

            return skinBamlStreams;
        }

        /// <summary>
        /// Determines whether [is relevant resource] [the specified entry].
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        private bool IsRelevantResource(DictionaryEntry entry, string resourceName)
        {
            var entryName = entry.Key as string;
            var extension = Path.GetExtension(entryName);
            return string.Compare(extension, ".baml", true) == 0 && // the resource has a .baml extension
                   entry.Value is Stream && // the resource is a Stream
                   (string.IsNullOrEmpty(resourceName) || string.Compare(resourceName, entryName, true) == 0);

        }

        #endregion
    }
}