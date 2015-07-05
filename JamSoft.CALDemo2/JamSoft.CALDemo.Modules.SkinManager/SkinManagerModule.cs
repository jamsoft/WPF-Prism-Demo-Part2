#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager
// File Name    : SkinManagerModule.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager
{
    using JamSoft.CALDemo.Modules.SkinManager.Core;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// </summary>
    [Module(ModuleName = "SkinManagerModule", OnDemand = false)]
    public class SkinManagerModule : IModule
    {
        /// <summary>The _container</summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinManagerModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public SkinManagerModule(IUnityContainer container)
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
        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<ISkinManager, SkinManager>(new ContainerControlledLifetimeManager());
        }
    }
}