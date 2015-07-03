#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ToolBar
// File Name    : ToolBarModule.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ToolBar
{
    using JamSoft.CALDemo.Modules.ToolBar.Core;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The toolbar module initializer
    /// </summary>
    [Module(ModuleName = "ToolBarModule")]
    [ModuleDependency("SettingsManagerModule")]
    public class ToolBarModule : IModule
    {
        /// <summary>The _container</summary>
        private readonly IUnityContainer _container;

        /// <summary>The _region manager</summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBarModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            RegisterViewsAndServices();

            IToolBarPresentationModel model = _container.Resolve<IToolBarPresentationModel>();

            IRegion toolbarRegion = _regionManager.Regions["ToolBarRegion"];
            toolbarRegion.Add(model.View);
            toolbarRegion.Activate(model.View);
        }

        /// <summary>Registers the views and services.</summary>
        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IToolBarView, ToolBarView>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IToolBarPresentationModel, ToolBarPresentationModel>(
                new ContainerControlledLifetimeManager());
        }
    }
}