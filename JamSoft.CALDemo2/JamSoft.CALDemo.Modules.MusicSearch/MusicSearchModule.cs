#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : MusicSearchModule.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    using JamSoft.CALDemo.Modules.MusicSearch.Core;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// </summary>
    [Module(ModuleName = "MusicSearchModule")]
    [ModuleDependency("ToolBarModule")]
    public class MusicSearchModule : IModule
    {
        /// <summary>The _container</summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicSearchModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public MusicSearchModule(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            RegisterViewsAndServices();

            _container.Resolve<IMusicSearchPresenter>();
        }

        /// <summary>Registers the views and services.</summary>
        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IMusicSearchPresenterModel, MusicSearchPresenterModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IMusicSearchPresenter, MusicSearchPresenter>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IMusicSearchView, MusicSearchView>(new ContainerControlledLifetimeManager());
        }
    }
}