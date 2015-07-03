#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleB
// File Name    : ModuleBPresenterModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleB
{
    using JamSoft.CALDemo.Modules.ModuleB.Core;
    using JamSoft.CALDemo.Modules.PageManager.Core;
    using JamSoft.CALDemo.Modules.StatusBar.Core;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// </summary>
    public class ModuleBPresenterModel : IModuleBPresenterModel, IPage
    {
        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>The _page manager</summary>
        private readonly IPageManager _pageManager;

        /// <summary>
        /// The _send message command
        /// </summary>
        private readonly DelegateCommand<object> _sendMessageCommand;

        /// <summary>The _view</summary>
        private readonly IModuleBView _view;

        /// <summary>The _is active page</summary>
        private bool _isActivePage;

        /// <summary>The _message to send</summary>
        private string _messageToSend;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBPresenterModel" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        /// <param name="pageManger">The page manger.</param>
        public ModuleBPresenterModel(
            IEventAggregator eventAggregator, 
            IModuleBView view, 
            IPageManager pageManger)
        {
            _eventAggregator = eventAggregator;

            _view = view;
            _view.Model = this;

            _pageManager = pageManger;
            _pageManager.Pages.Add(this);

            _sendMessageCommand = new DelegateCommand<object>(OnSendMessageCommandExecuted);
        }

        /// <summary>Gets the send message command.</summary>
        /// <value>The send message command.</value>
        public DelegateCommand<object> SendMessageCommand
        {
            get
            {
                return _sendMessageCommand;
            }
        }

        /// <summary>Gets or sets the message to send.</summary>
        /// <value>The message to send.</value>
        public string MessageToSend
        {
            get
            {
                return _messageToSend;
            }

            set
            {
                _messageToSend = value;
            }
        }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public string ID
        {
            get
            {
                return "Module B";
            }
        }

        /// <summary>Gets the position.</summary>
        /// <value>The position.</value>
        public float Position
        {
            get
            {
                return 20F;
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

        /// <summary>Sets a value indicating whether this instance is active page.</summary>
        /// <value>
        /// <c>true</c> if this instance is active page; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }

        /// <summary>
        /// Called when [send message command executed].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSendMessageCommandExecuted(object obj)
        {
            _eventAggregator.GetEvent<AppStatusMessageEvent>().Publish(_messageToSend);
        }
    }
}