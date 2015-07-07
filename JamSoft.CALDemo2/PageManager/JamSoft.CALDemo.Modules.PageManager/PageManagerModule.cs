#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.PageManager
// File Name    : PageManagerModule.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.PageManager
{
    using JamSoft.CALDemo.Modules.PageManager.Core;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The page manager module initializer
    /// </summary>
    [Module(ModuleName = "PageManagerModule", OnDemand = false)]
    public class PageManagerModule : IModule
    {
        /// <summary>The _container</summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageManagerModule"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public PageManagerModule(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            RegisterViewsAndServices();
        }

        /// <summary>Registers the views and services.</summary>
        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IPageManager, PageManager>(new ContainerControlledLifetimeManager());
            _container.Resolve<MainRegionController>();
        }
    }
}