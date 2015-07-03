#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Shell
// File Name    : Shell.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    ///     Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IShellView
    {
        /// <summary>Initializes a new instance of the <see cref="Shell"/> class.</summary>
        public Shell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public void ShowView()
        {
            Show();
        }

        /// <summary>Handles the MouseLeftButtonDown event of the Window control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}