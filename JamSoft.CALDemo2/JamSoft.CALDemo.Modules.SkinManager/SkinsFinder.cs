#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : SkinsFinder.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using JamSoft.CALDemo.Modules.SkinManager.Core;
    using JamSoft.CALDemo.Modules.SkinManager.Skins;
    using JamSoft.WpfThemes.Utils;

    /// <summary>
    /// </summary>
    internal sealed class SkinsFinder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkinsFinder"/> class.
        /// </summary>
        public SkinsFinder()
        {
        }

        #region Data

        /// <summary>The _skin fullname</summary>
        private string _skinFullname;

        /// <summary>The _skin friendly name</summary>
        private string _skinFriendlyName;

        /// <summary>The _skin description</summary>
        private string _skinDescription;

        /// <summary>The _skins</summary>
        private FileInfo[] _skins;

        /// <summary>The _skins directory</summary>
        private DirectoryInfo _skinsDirectory;

        /// <summary>The _skins list</summary>
        private List<Skin> _skinsList = new List<Skin>();

        /// <summary>Gets the skins list.</summary>
        /// <value>The skins list.</value>
        public List<Skin> SkinsList
        {
            get
            {
                return _skinsList;
            }

            private set
            {
                _skinsList = value;
            }
        }

        #endregion // Data

        #region Methods

        /// <summary>Initializes this instance.</summary>
        public void Init()
        {
            _skinsDirectory = GetDirectoryInfo();
            FindSkins();
            SkinsList = _skinsList;
        }

        /// <summary>Finds the skins.</summary>
        private void FindSkins()
        {
            GetDynamicLibraries();

            if (_skins != null && _skins.Length > 0)
            {
                foreach (var skin in _skins)
                {
                    if (IsSkin(skin) == true)
                    {
                        _skinFullname = skin.FullName;
                        _skinsList.Add(new DirectAssemblySkin(_skinFriendlyName, _skinDescription, _skinFullname));
                    }
                }
            }
        }

        /// <summary>Gets the dynamic libraries.</summary>
        /// <exception cref="JamSoft.CALDemo.Modules.SkinManager.Core.SkinException">
        /// Skins directory not found
        /// or
        /// No skins found!
        /// </exception>
        /// <exception cref="SkinException"></exception>
        private void GetDynamicLibraries()
        {
            try
            {
                _skins = _skinsDirectory.GetFiles("*.dll");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new SkinException("Skins directory not found", ex);
            }

            if (_skins.Length == 0)
            {
                throw new SkinException("No skins found!");
            }
        }

        /// <summary>Gets the directory information.</summary>
        /// <returns></returns>
        private DirectoryInfo GetDirectoryInfo()
        {
            var skinsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Skins");
            if (Directory.Exists(skinsDir))
            {
                _skinsDirectory = new DirectoryInfo(skinsDir);
            }

            return _skinsDirectory;
        }

        /// <summary>Determines whether the specified file is skin.</summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        private bool IsSkin(FileInfo file)
        {
            var isSkin = false;
            var skinAssembly = Assembly.LoadFrom(file.FullName);
            AssemblySkinNameAttribute[] skinNames = null;
            AssemblySkinDescriptionAttribute[] skinDescriptions = null;

            try
            {
                skinNames =
                    (AssemblySkinNameAttribute[])
                    skinAssembly.GetCustomAttributes(typeof(AssemblySkinNameAttribute), true);
                skinDescriptions =
                    (AssemblySkinDescriptionAttribute[])
                    skinAssembly.GetCustomAttributes(typeof(AssemblySkinDescriptionAttribute), true);
            }
            catch (Exception ex)
            {
                // log it
            }

            if (skinNames.Length == 1 && skinDescriptions.Length == 1)
            {
                _skinFriendlyName = skinNames[0].AssemblySkinName;
                _skinDescription = skinDescriptions[0].AssemblySkinDescription;
                isSkin = true;
            }

            return isSkin;
        }

        #endregion
    }
}