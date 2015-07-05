#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : MusicSearchPresenterModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

    using JamSoft.CALDemo.Modules.StatusBar.Core;
    using JamSoft.CALDemo.Modules.ToolBar.Core;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.PubSubEvents;

    using MusicBrainz;

    /// <summary>
    /// The music search presenter model
    /// </summary>
    public class MusicSearchPresenterModel : IMusicSearchPresenterModel, INotifyPropertyChanged
    {
        #region ToolBar Bits

        /// <summary>The _clear stuff</summary>
        private Button _clearStuff;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicSearchPresenterModel" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="toolbarPresentationModel">The toolbar presentation model.</param>
        public MusicSearchPresenterModel(
            IEventAggregator eventAggregator, 
            IToolBarPresentationModel toolbarPresentationModel)
        {
            _eventAggregator = eventAggregator;
            _toolbarPresentationModel = toolbarPresentationModel;

            _searchForArtistCommand = new DelegateCommand<object>(SearchForArtistCommandExecuted);
            _searchForArtistReleasesCommand = new DelegateCommand<object>(SearchForArtistReleasesCommandExecuted, SearchForArtistReleasesCommandCanExecute);
            _clearArtistInfoCommand = new DelegateCommand<object>(ClearArtistInfoCommandExecuted, ClearArtistInfoCommandCanExecute);
        }

        #region Activate Model

        /// <summary>Activates the model.</summary>
        public void ActivateModel()
        {
            RegisterClearArtistsInfoButton();
        }

        #endregion

        #region De-Activate Model

        /// <summary>Deactives the model.</summary>
        public void DeactiveModel()
        {
            DeRegisterClearArtistsInfoButton();
        }

        #endregion

        #region Data

        /// <summary>The _event aggregator</summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// The _toolbar presentation model
        /// </summary>
        private readonly IToolBarPresentationModel _toolbarPresentationModel;

        /// <summary>The _artist search term</summary>
        private string _artistSearchTerm;

        /// <summary>Gets or sets the artist search term.</summary>
        /// <value>The artist search term.</value>
        public string ArtistSearchTerm
        {
            get
            {
                return _artistSearchTerm;
            }

            set
            {
                _artistSearchTerm = value;
            }
        }

        /// <summary>The _selected artist</summary>
        private BindableArtist _selectedArtist;

        /// <summary>Gets or sets the selected artist.</summary>
        /// <value>The selected artist.</value>
        public BindableArtist SelectedArtist
        {
            get
            {
                return _selectedArtist;
            }

            set
            {
                _selectedArtist = value;
                _canSearchForArtistReleases = true;
                _searchForArtistReleasesCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// The _search for artist command
        /// </summary>
        private readonly DelegateCommand<object> _searchForArtistCommand;

        /// <summary>Gets the search for artist command.</summary>
        /// <value>The search for artist command.</value>
        public DelegateCommand<object> SearchForArtistCommand
        {
            get
            {
                return _searchForArtistCommand;
            }
        }

        /// <summary>
        /// The _can clear artist information
        /// </summary>
        private bool _canClearArtistInfo = false;

        /// <summary>
        /// The _clear artist information command
        /// </summary>
        private readonly DelegateCommand<object> _clearArtistInfoCommand;

        /// <summary>Gets the clear artist information command.</summary>
        /// <value>The clear artist information command.</value>
        public DelegateCommand<object> ClearArtistInfoCommand
        {
            get
            {
                return _clearArtistInfoCommand;
            }
        }

        /// <summary>
        /// The _can search for artist releases
        /// </summary>
        private bool _canSearchForArtistReleases = false;

        /// <summary>
        /// The _search for artist releases command
        /// </summary>
        private readonly DelegateCommand<object> _searchForArtistReleasesCommand;

        /// <summary>Gets the search for artist releases command.</summary>
        /// <value>The search for artist releases command.</value>
        public DelegateCommand<object> SearchForArtistReleasesCommand
        {
            get
            {
                return _searchForArtistReleasesCommand;
            }
        }

        /// <summary>The _artists</summary>
        private ObservableCollection<BindableArtist> _artists;

        /// <summary>Gets the artists.</summary>
        /// <value>The artists.</value>
        public ObservableCollection<BindableArtist> Artists
        {
            get
            {
                return _artists;
            }

            private set
            {
                _artists = value;
                NotifyPropertyChanged("Artists");
            }
        }

        /// <summary>The _releases</summary>
        private ObservableCollection<BindableRelease> _releases;

        /// <summary>Gets or sets the releases.</summary>
        /// <value>The releases.</value>
        public ObservableCollection<BindableRelease> Releases
        {
            get
            {
                return _releases;
            }

            set
            {
                _releases = value;
                NotifyPropertyChanged("Releases");
            }
        }

        #endregion

        #region Artist Search

        /// <summary>Searches for artist command executed.</summary>
        /// <param name="obj">The object.</param>
        private void SearchForArtistCommandExecuted(object obj)
        {
            PerformArtistQueryAsync(ArtistSearchCallback, new object());
        }

        /// <summary><c>Artists</c> the search callback.</summary>
        /// <param name="sender">The <paramref name="sender"/>.</param>
        /// <param name="args">The <see cref="ArtistSearchCompletedEventArgs"/> instance containing the event data.</param>
        private void ArtistSearchCallback(object sender, ArtistSearchCompletedEventArgs args)
        {
            if (args.Error == null)
            {
                var objConverter = new MusicSearchObjectConverter();
                Artists = objConverter.Convert(args.ArtistsSearchResults);
            }

            _canClearArtistInfo = true;
            _searchForArtistCommand.RaiseCanExecuteChanged();
            _clearArtistInfoCommand.RaiseCanExecuteChanged();

            _eventAggregator.GetEvent<AppStatusMessageEvent>().Publish("Ready...");
        }

        /// <summary>Performs the artist query asynchronous.</summary>
        /// <param name="callback">The <paramref name="callback"/>.</param>
        /// <param name="userState">State of the user.</param>
        public void PerformArtistQueryAsync(Action<object, ArtistSearchCompletedEventArgs> callback, object userState)
        {
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(
                    (obj) =>
                        {
                            try
                            {
                                _eventAggregator.GetEvent<AppStatusMessageEvent>()
                                    .Publish("Getting Artists: " + _artistSearchTerm);

                                var results = Artist.Query(_artistSearchTerm);

                                callback(this, new ArtistSearchCompletedEventArgs(new List<Artist>(results), userState));
                            }
                            catch (Exception ex)
                            {
                                callback(this, new ArtistSearchCompletedEventArgs(ex, false, userState));
                            }
                        }));
        }

        #endregion

        #region Releases Search

        /// <summary>Searches for artist releases command executed.</summary>
        /// <param name="obj">The object.</param>
        private void SearchForArtistReleasesCommandExecuted(object obj)
        {
            _canSearchForArtistReleases = false;
            _searchForArtistReleasesCommand.RaiseCanExecuteChanged();

            PerformArtistReleaseQueryAsync(ArtistReleasesSearchCallback, new object());
        }

        /// <summary>Searches for artist releases command can execute.</summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private bool SearchForArtistReleasesCommandCanExecute(object obj)
        {
            return _canSearchForArtistReleases;
        }

        /// <summary>Artists the releases search callback.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ArtistReleasesSearchCompletedEventArgs"/> instance containing the event data.</param>
        public void ArtistReleasesSearchCallback(object sender, ArtistReleasesSearchCompletedEventArgs args)
        {
            if (args.Error == null)
            {
                var objConverter = new MusicSearchObjectConverter();
                Releases = objConverter.Convert(args.ArtistsReleasesSearchResults);
            }

            _eventAggregator.GetEvent<AppStatusMessageEvent>().Publish("Ready...");
        }

        /// <summary>Performs the artist release query asynchronous.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="userState">State of the user.</param>
        public void PerformArtistReleaseQueryAsync(
            Action<object, ArtistReleasesSearchCompletedEventArgs> callback, 
            object userState)
        {
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(
                    (obj) =>
                        {
                            try
                            {
                                _eventAggregator.GetEvent<AppStatusMessageEvent>()
                                    .Publish("Getting Releases For: " + _artistSearchTerm);

                                var results = Release.Query(_selectedArtist.Name);

                                callback(
                                    this, 
                                    new ArtistReleasesSearchCompletedEventArgs(new List<Release>(results), userState));
                            }
                            catch (Exception ex)
                            {
                                callback(this, new ArtistReleasesSearchCompletedEventArgs(ex, false, userState));
                            }
                        }));
        }

        #endregion

        #region Button Management

        /// <summary>Registers the clear artists information button.</summary>
        private void RegisterClearArtistsInfoButton()
        {
            // this would be a specific toolbar user control provided by a module
            // to the toolbar module
            _clearStuff = new Button
                              {
                                  Style = (Style)Application.Current.FindResource("JamSoftButtonStyle"),
                                  Height = 25,
                                  Width = 50,
                                  Padding = new Thickness(0, 5, 0, 0),
                                  Margin = new Thickness(0, 0, 5, 0),
                                  Content = "Clear",
                                  Command = _clearArtistInfoCommand
                              };
            _toolbarPresentationModel.AddToolBarItem(_clearStuff);
        }

        /// <summary>Des the register clear artists information button.</summary>
        private void DeRegisterClearArtistsInfoButton()
        {
            _toolbarPresentationModel.RemoveToolBarItem(_clearStuff);
        }

        #endregion

        #region Clear Artist Info

        /// <summary>Clears the artist information command executed.</summary>
        /// <param name="obj">The object.</param>
        private void ClearArtistInfoCommandExecuted(object obj)
        {
            if (_artists != null)
            {
                _artists.Clear();
            }

            if (_releases != null)
            {
                _releases.Clear();
            }

            _canClearArtistInfo = false;
            _canSearchForArtistReleases = false;

            _searchForArtistCommand.RaiseCanExecuteChanged();
            _clearArtistInfoCommand.RaiseCanExecuteChanged();
            _searchForArtistReleasesCommand.RaiseCanExecuteChanged();
        }

        /// <summary>Clears the artist information command can execute.</summary>
        /// <param name="obj">The <see langword="object"/>.</param>
        /// <returns>returns true if command can be executed</returns>
        private bool ClearArtistInfoCommandCanExecute(object obj)
        {
            return _canClearArtistInfo;
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Notifies the property changed.</summary>
        /// <param name="info">The information.</param>
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}