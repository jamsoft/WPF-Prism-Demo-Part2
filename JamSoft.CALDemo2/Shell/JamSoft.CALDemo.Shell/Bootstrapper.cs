#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Shell
// File Name    : Bootstrapper.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo
{
    using System.Windows;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.UnityExtensions;
    using Microsoft.Practices.Prism.UnityExtensions.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The application bootstrapper
    /// </summary>
    internal class JamSoftBootstrapper : UnityBootstrapper
    {
        /// <summary>Gets the module enumerator.</summary>
        /// <returns>The module enumerator</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = "Modules" };
        }

        /// <summary>Configures the container.</summary>
        protected override void ConfigureContainer()
        {
            // Container.RegisterType<IShellView, Shell>();
            var eventAggregator = new JamSoftEventAggregator();
            Container.RegisterInstance(typeof(IEventAggregator), eventAggregator, new ContainerControlledLifetimeManager());
            base.ConfigureContainer();

            var ea = Container.Resolve<IEventAggregator>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>Creates the shell.</summary>
        /// <returns>The main application shell</returns>
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }
    }

    public class JamSoftEventAggregator : EventAggregator
    {
        public JamSoftEventAggregator()
        {
            
        }
    }
}



        //protected override DependencyObject CreateShell()
        //{
        //    Shell shell = Container.Resolve<Shell>();
        //    Application.Current.MainWindow = shell;
        //    Application.Current.MainWindow.Show();
        //    return shell;
        //}