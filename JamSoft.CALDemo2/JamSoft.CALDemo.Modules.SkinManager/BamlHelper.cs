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
    using System.IO;
    using System.Reflection;
    using System.Windows.Markup;

    /// <summary>
    /// </summary>
    public static class BamlHelper
    {
        /// <summary>The load baml method</summary>
        private static readonly MethodInfo LoadBamlMethod;

        /// <summary>Initializes the <see cref="BamlHelper"/> class.</summary>
        static BamlHelper()
        {
            var type = typeof(XamlReader);
            // Hope that Microsoft will not change this in the future, or at least provide an official way to load baml
            LoadBamlMethod = type.GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static);
        }

        /// <summary>Loads the baml.</summary>
        /// <typeparam name="TRoot">The type of the root.</typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        internal static TRoot LoadBaml<TRoot>(Stream stream)
        {
            var parserContext = new ParserContext();
            var parameters = new object[] { stream, parserContext, null, false };
            var bamlRoot = LoadBamlMethod.Invoke(null, parameters);
            return (TRoot)bamlRoot;
        }
    }
}