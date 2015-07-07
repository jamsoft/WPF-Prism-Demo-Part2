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

    /// <summary>
    /// The music search presenter
    /// </summary>
    public class MusicSearchPresenter : IPage, IMusicSearchPresenter
    {
        /// <summary>The _model</summary>
        private readonly IMusicSearchPresenterModel _model;

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
            _model = model;

            pageManager.Pages.Add(this);

            _view = view;
            _view.Model = _model;

            eventAggregator.GetEvent<PageSelectedEvent>().Subscribe(OnPageSelected, ThreadOption.UIThread);
        }

        /// <summary>Gets the Page ID</summary>
        /// <value>The identifier.</value>
        public string ID
        {
            get
            {
                return "Music Brainz";
            }
        }

        /// <summary>Gets the position.</summary>
        /// <value>The position.</value>
        public float Position
        {
            get
            {
                return 100F;
            }
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public object View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>Sets a value indicating whether <c>this</c> instance is active page.</summary>
        /// <value>
        /// <c>true</c> if <c>this</c> instance is active page; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }

        /// <summary>
        /// Called when <paramref name="page"/> is selected.
        /// </summary>
        /// <param name="page">The <paramref name="page"/>.</param>
        private void OnPageSelected(IPage page)
        {
            if (page == this)
            {
                _model.ActivateModel();
            }
            else
            {
                _model.DeactivateModel();
            }
        }
    }
}