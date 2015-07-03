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
    using Microsoft.Practices.Prism.UnityExtensions;
    using Microsoft.Practices.Unity;

    /// <summary>
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
            Container.RegisterType<IShellView, Shell>();
            base.ConfigureContainer();
        }

        /// <summary>Creates the shell.</summary>
        /// <returns>The main application shell</returns>
        protected override DependencyObject CreateShell()
        {
            Shell shell = Container.Resolve<Shell>();
            Application.Current.MainWindow = shell;
            Application.Current.MainWindow.Show();
            return shell;
        }
    }
}