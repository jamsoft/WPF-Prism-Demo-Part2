#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.StatusBar
// File Name    : StatusBarView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.StatusBar
{
    using System.Windows.Controls;

    /// <summary>
    ///     Interaction logic for ssStatusBar.xaml
    /// </summary>
    public sealed partial class StatusBarView : UserControl, IStatusBarView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarView"/> class.
        /// </summary>
        public StatusBarView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public IStatusBarPresentationModel Model
        {
            set
            {
                DataContext = value;
            }
        }
    }
}