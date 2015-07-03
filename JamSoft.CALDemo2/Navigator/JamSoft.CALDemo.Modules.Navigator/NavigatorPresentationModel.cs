#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.Navigator
// File Name    : NavigatorPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.Navigator
{
    using System;
    using System.Collections.ObjectModel;

    using JamSoft.CALDemo.Modules.PageManager.Core;

    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// </summary>
    public class NavigatorPresentationModel : INavigatorPresentationModel
    {
        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>The _page manger</summary>
        private readonly IPageManager _pageManger;

        /// <summary>The _view</summary>
        private readonly INavigatorView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigatorPresentationModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="pageManger">The page manger.</param>
        /// <param name="view">The view.</param>
        public NavigatorPresentationModel(
            IEventAggregator eventAggregator, 
            IPageManager pageManger, 
            INavigatorView view)
        {
            _eventAggregator = eventAggregator;
            _pageManger = pageManger;

            _view = view;
            _view.ItemChangeRequest += new EventHandler<PageEventArgs>(view_ItemChangeRequest);
            _view.Model = this;

            _eventAggregator.GetEvent<PageSelectedEvent>().Subscribe(OnPageSelected, ThreadOption.UIThread);
        }

        #region Page Selection Bits

        /// <summary>
        /// Called when [page selected].
        /// </summary>
        /// <param name="page">The page.</param>
        private void OnPageSelected(IPage page)
        {
            _view.SelectedItem = page;
        }

        /// <summary>Handles the ItemChangeRequest event of the view control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PageEventArgs"/> instance containing the event data.</param>
        private void view_ItemChangeRequest(object sender, PageEventArgs e)
        {
            OnItemChangeRequest(e.Page);
        }

        /// <summary>
        /// Called when [item change request].
        /// </summary>
        /// <param name="page">The page.</param>
        private void OnItemChangeRequest(IPage page)
        {
            _eventAggregator.GetEvent<PageRequestEvent>().Publish(page);
        }

        /// <summary>
        /// </summary>
        public INavigatorView View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<IPage> Pages
        {
            get
            {
                return _pageManger.Pages;
            }
        }

        #endregion
    }
}