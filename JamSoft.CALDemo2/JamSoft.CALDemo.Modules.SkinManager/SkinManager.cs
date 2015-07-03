#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : SkinManager.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    using JamSoft.CALDemo.Modules.SkinManager.Core;

    /// <summary>
    /// </summary>
    public class SkinManager : DependencyObject, ISkinManager
    {
        /// <summary>
        /// The current skin property
        /// </summary>
        public static readonly DependencyProperty CurrentSkinProperty = DependencyProperty.Register(
            "CurrentSkin", 
            typeof(Skin), 
            typeof(SkinManager), 
            new UIPropertyMetadata(Skin.Null, OnCurrentSkinChanged, OnCoerceSkinValue));

        /// <summary>The _skin finder</summary>
        private readonly SkinsFinder _skinFinder = new SkinsFinder();

        /// <summary>The _skins</summary>
        private List<Skin> _skins = new List<Skin>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinManager"/> class.
        /// </summary>
        public SkinManager()
        {
            Init();
        }

        /// <summary>Gets the skins.</summary>
        /// <value>The skins.</value>
        public ObservableCollection<Skin> Skins
        {
            get
            {
                return new ObservableCollection<Skin>(_skins);
            }
        }

        /// <summary>Gets or sets the current skin.</summary>
        /// <value>The current skin.</value>
        public Skin CurrentSkin
        {
            get
            {
                return (Skin)GetValue(CurrentSkinProperty);
            }

            set
            {
                SetValue(CurrentSkinProperty, value);
            }
        }

        /// <summary>
        /// Called when [coerce skin value].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="baseValue">The base value.</param>
        /// <returns></returns>
        private static object OnCoerceSkinValue(DependencyObject d, object baseValue)
        {
            if (baseValue == null)
            {
                return Skin.Null;
            }

            return baseValue;
        }

        /// <summary>
        /// Called when [current skin changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentSkinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Skin oldSkin = e.OldValue as Skin;
                oldSkin.Unload();
                Skin newSkin = e.NewValue as Skin;
                newSkin.Load();
            }
            catch (SkinException ex)
            {
                // log it 
            }
        }

        /// <summary>Initializes this instance.</summary>
        private void Init()
        {
            _skinFinder.Init();
            _skins = _skinFinder.SkinsList;
        }

        /// <summary>Loads the skin.</summary>
        /// <param name="skinName">Name of the skin.</param>
        public void LoadSkin(string skinName)
        {
            Skin skin = _skins.FirstOrDefault(x => x.Name.Equals(skinName));
            if (skin != null)
            {
                CurrentSkin = skin;
            }
        }
    }
}