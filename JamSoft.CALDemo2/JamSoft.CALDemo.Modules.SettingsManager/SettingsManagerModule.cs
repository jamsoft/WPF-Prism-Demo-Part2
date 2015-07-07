#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager
// File Name    : SettingsManagerModule.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager
{
    using JamSoft.CALDemo.Modules.SettingsManager.Core;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The settings manager initialization class
    /// </summary>
    [Module(ModuleName = "SettingsManagerModule", OnDemand = false)]
    [ModuleDependency("PageManagerModule")]
    [ModuleDependency("SkinManagerModule")]
    public class SettingsManagerModule : IModule
    {
        /// <summary>The _container</summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsManagerModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public SettingsManagerModule(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            RegisterViewsAndServices();

            _container.Resolve<ISettingsManagerPresentationModel>();
        }

        /// <summary>Registers the views and services.</summary>
        private void RegisterViewsAndServices()
        {
            _container.RegisterType<ISettingsView, SettingsView>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISettingsManagerPresentationModel, SettingsManagerPresentationModel>(new ContainerControlledLifetimeManager());
        }
    }
}