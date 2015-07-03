// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MusicSearchView.xaml.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : MusicSearchView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    /// <summary>
    /// Interaction logic for MusicSearchView.xaml
    /// </summary>
    public partial class MusicSearchView : IMusicSearchView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicSearchView" /> class.
        /// </summary>
        public MusicSearchView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public IMusicSearchPresenterModel Model
        {
            set
            {
                DataContext = value;
            }
        }
    }
}