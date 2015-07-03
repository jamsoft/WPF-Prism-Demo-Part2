#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : MusicSearchPresenter.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    using JamSoft.CALDemo.Modules.MusicSearch.Core;
    using JamSoft.CALDemo.Modules.PageManager.Core;

    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The music search presenter
    /// </summary>
    public class MusicSearchPresenter : IPage, IMusicSearchPresenter
    {
        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>The _model</summary>
        private readonly IMusicSearchPresenterModel _model;

        /// <summary>The _page manager</summary>
        private readonly IPageManager _pageManager;

        /// <summary>The _view</summary>
        private readonly IMusicSearchView _view;

        /// <summary>The _is active page</summary>
        private bool _isActivePage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicSearchPresenter"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="model">The model.</param>
        /// <param name="view">The view.</param>
        /// <param name="pageManager">The page manager.</param>
        public MusicSearchPresenter(
            IEventAggregator eventAggregator, 
            IMusicSearchPresenterModel model, 
            IMusicSearchView view, 
            IPageManager pageManager)
        {
            _eventAggregator = eventAggregator;

            _model = model;

            _pageManager = pageManager;
            _pageManager.Pages.Add(this);

            _view = view;
            _view.Model = _model;

            _eventAggregator.GetEvent<PageSelectedEvent>().Subscribe(OnPageSelected, ThreadOption.UIThread);
        }

        /// <summary>
        /// </summary>
        public string ID
        {
            get
            {
                return "Music Brainz";
            }
        }

        /// <summary>
        /// </summary>
        public float Position
        {
            get
            {
                return 100F;
            }
        }

        /// <summary>
        /// </summary>
        public object View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>
        /// </summary>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="page">
        /// </param>
        private void OnPageSelected(IPage page)
        {
            if (page == this)
            {
                _model.ActivateModel();
            }
            else
            {
                _model.DeactiveModel();
            }
        }
    }
}