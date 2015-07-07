#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.Navigator
// File Name    : NavigatorView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.Navigator
{
    using System;
    using System.Windows.Controls;

    using JamSoft.CALDemo.Modules.PageManager.Core;

    /// <summary>Interaction logic for NavigatorView.xaml</summary>
    public partial class NavigatorView : INavigatorView
    {
        /// <summary>The _model</summary>
        private INavigatorPresentationModel _model;

        /// <summary>The _selected page</summary>
        private IPage _selectedPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigatorView"/> class.
        /// </summary>
        public NavigatorView()
        {
            InitializeComponent();
        }

        /// <summary>Occurs when [item change request].</summary>
        public event EventHandler<PageEventArgs> ItemChangeRequest;

        /// <summary>Sets or sets the model.</summary>
        /// <value>The model.</value>
        public INavigatorPresentationModel Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
                DataContext = value;
            }
        }

        /// <summary>Gets or sets the selected item.</summary>
        /// <value>The selected item.</value>
        public IPage SelectedItem
        {
            get
            {
                return theListView.SelectedItem as IPage;
            }

            set
            {
                _selectedPage = value;
                SetListViewItemWithoutEvent(_selectedPage);
            }
        }

        /// <summary>
        /// Called when [item change request].
        /// </summary>
        /// <param name="page">The <paramref name="page"/>.</param>
        private void OnItemChangeRequest(IPage page)
        {
            if (ItemChangeRequest != null)
            {
                ItemChangeRequest(this, new PageEventArgs(page));
            }
        }

        /// <summary>Sets the ListView item without event.</summary>
        /// <param name="page">The <paramref name="page"/>.</param>
        private void SetListViewItemWithoutEvent(IPage page)
        {
            theListView.SelectedItem = page;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the theListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void TheListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IPage listBoxSelectedPage = theListView.SelectedItem as IPage;

            if (listBoxSelectedPage != _selectedPage)
            {
                SetListViewItemWithoutEvent(_selectedPage);
            }

            OnItemChangeRequest(listBoxSelectedPage);
        }
    }
}