#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.PageManager
// File Name    : PageManager.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.PageManager
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using JamSoft.CALDemo.Modules.PageManager.Core;

    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// </summary>
    public class PageManager : IPageManager
    {
        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>The _pages</summary>
        private readonly ObservableCollection<IPage> _pages = new ObservableCollection<IPage>();

        /// <summary>The _current page</summary>
        private IPage _currentPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageManager"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public PageManager(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PageRequestEvent>().Subscribe(OnPageSelected, ThreadOption.UIThread);
        }

        /// <summary>Gets the pages.</summary>
        /// <value>The pages.</value>
        public ObservableCollection<IPage> Pages
        {
            get
            {
                SortPages();
                return _pages;
            }
        }

        /// <summary>Gets the current page.</summary>
        /// <value>The current page.</value>
        public IPage CurrentPage
        {
            get
            {
                return _currentPage;
            }
        }

        /// <summary>
        /// Called when [page selected].
        /// </summary>
        /// <param name="page">The page.</param>
        private void OnPageSelected(IPage page)
        {
            if (_currentPage != page)
            {
                _currentPage = page;
                _eventAggregator.GetEvent<PageSelectedEvent>().Publish(page);
            }
        }

        /// <summary>Sorts the pages.</summary>
        private void SortPages()
        {
            List<IPage> p = _pages.ToList<IPage>();
            p.Sort(new PagePositionComparer());
            _pages.Clear();
            foreach (IPage page in p)
            {
                _pages.Add(page);
            }
        }

        /// <summary>Gets the page.</summary>
        /// <param name="pageId">The page identifier.</param>
        /// <returns></returns>
        public IPage GetPage(string pageId)
        {
            IPage selPage = null;
            for (var i = 0; i < Pages.Count(); i++)
            {
                IPage p = Pages[i];
                if (p.ID == pageId)
                {
                    selPage = p;
                }
            }

            return selPage;
        }
    }
}