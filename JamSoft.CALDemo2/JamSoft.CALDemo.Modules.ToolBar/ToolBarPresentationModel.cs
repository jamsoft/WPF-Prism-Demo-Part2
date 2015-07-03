#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ToolBar
// File Name    : ToolBarPresentationModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ToolBar
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using JamSoft.CALDemo.Modules.SettingsManager.Core;
    using JamSoft.CALDemo.Modules.ToolBar.Core;

    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// The toolbar presentation model
    /// </summary>
    public class ToolBarPresentationModel : IToolBarPresentationModel, INotifyPropertyChanged
    {
        /// <summary>
        /// The _close application command
        /// </summary>
        private readonly DelegateCommand<object> _closeApplicationCommand;

        /// <summary>
        /// The _registered tool controls
        /// </summary>
        private readonly ObservableCollection<Control> _registeredToolControls = new ObservableCollection<Control>();

        /// <summary>The _settings manager</summary>
        private readonly ISettingsManagerPresentationModel _settingsManager;

        /// <summary>The _view</summary>
        private readonly IToolBarView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBarPresentationModel"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="settingsManager">The settings manager.</param>
        public ToolBarPresentationModel(
            IToolBarView view, 
            ISettingsManagerPresentationModel settingsManager)
        {
            _view = view;
            _view.Model = this;
            _settingsManager = settingsManager;

            _closeApplicationCommand = new DelegateCommand<object>(
                OnCloseApplicationCommandExecuted, 
                OnCloseApplicationCommandCanExecute);
        }

        /// <summary>Gets the registered tool controls.</summary>
        /// <value>The registered tool controls.</value>
        public ObservableCollection<Control> RegisteredToolControls
        {
            get
            {
                return _registeredToolControls;
            }
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public IToolBarView View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>Gets the close application command.</summary>
        /// <value>The close application command.</value>
        public DelegateCommand<object> CloseApplicationCommand
        {
            get
            {
                return _closeApplicationCommand;
            }
        }

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [close application command executed].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCloseApplicationCommandExecuted(object obj)
        {
            _settingsManager.SaveSettings();
            Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Called when [close application command can execute].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private bool OnCloseApplicationCommandCanExecute(object obj)
        {
            // Basically NEVER tell the user they can't shut the app!  Urgh!
            // Well ... unless are going to totally kill something as a result ! :)
            return true;
        }

        /// <summary>Adds the tool bar item.</summary>
        /// <param name="control">The control.</param>
        public void AddToolBarItem(Control control)
        {
            if (!_view.DynamicToolPanel.Children.Contains(control))
            {
                _registeredToolControls.Add(control);
                _view.DynamicToolPanel.Children.Insert(0, control);
                NotifyPropertyChanged("RegisteredToolControls");
            }
        }

        /// <summary>Removes the tool bar item.</summary>
        /// <param name="control">The control.</param>
        public void RemoveToolBarItem(Control control)
        {
            if (_view.DynamicToolPanel.Children.Contains(control))
            {
                _registeredToolControls.Remove(control);
                _view.DynamicToolPanel.Children.Remove(control);
                NotifyPropertyChanged("RegisteredToolControls");
            }
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