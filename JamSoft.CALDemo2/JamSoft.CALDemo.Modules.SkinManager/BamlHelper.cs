#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : BamlHelper.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System;
    using System.IO;
    using System.Windows.Baml2006;
    using System.Xaml;

    /// <summary>
    /// A helper class to load objects from baml
    /// </summary>
    public static class BamlHelper
    {
        /// <summary>Loads the baml.</summary>
        /// <typeparam name="TRoot">The type of the root.</typeparam>
        /// <param name="stream">The <paramref name="stream"/>.</param>
        /// <returns>the loaded <see langword="object"/> parameter</returns>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>reader</name>
        ///     </paramref>
        ///     is null.</exception>
        /// <exception cref="NotImplementedException">The default implementation encountered a <see cref="T:System.Xaml.XamlNodeType" /> that is not in the default enumeration.</exception>
        internal static TRoot LoadBaml<TRoot>(Stream stream)
        {
            var reader = new Baml2006Reader(stream);
            var writer = new XamlObjectWriter(reader.SchemaContext);
            while (reader.Read())
            {
                writer.WriteNode(reader);
            }

            return (TRoot)writer.Result;
        }
    }
}