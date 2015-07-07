#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.StatusBar
// File Name    : StatusBarPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.StatusBar
{
    using System.ComponentModel;

    using JamSoft.CALDemo.Modules.StatusBar.Core;

    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>
    /// The status bar presentation model
    /// </summary>
    public class StatusBarPresentationModel : IStatusBarPresentationModel, INotifyPropertyChanged
    {
        /// <summary>The _view</summary>
        private readonly IStatusBarView _view;

        /// <summary>The _app status message</summary>
        private string _appStatusMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarPresentationModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public StatusBarPresentationModel(
            IEventAggregator eventAggregator, 
            IStatusBarView view)
        {
            _view = view;
            _view.Model = this;
            eventAggregator.GetEvent<AppStatusMessageEvent>().Subscribe(OnAppStatusChanged, ThreadOption.UIThread, true);
            AppStatusMessage = "Ready...";
        }

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Gets or sets the application status message.</summary>
        /// <value>The application status message.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        public string AppStatusMessage
        {
            get
            {
                return _appStatusMessage;
            }

            set
            {
                _appStatusMessage = value;
                NotifyPropertyChanged("AppStatusMessage");
            }
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public IStatusBarView View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>
        /// Called when [application status changed].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnAppStatusChanged(string message)
        {
            AppStatusMessage = message;
        }

        /// <summary>Notifies the property changed.</summary>
        /// <param name="info">The information.</param>
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}