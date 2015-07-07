#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleB
// File Name    : ModuleBView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleB
{
    using JamSoft.CALDemo.Modules.ModuleB.Core;

    /// <summary>
    ///     Interaction logic for ModuleBView.xaml
    /// </summary>
    public partial class ModuleBView : IModuleBView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBView"/> class.
        /// </summary>
        public ModuleBView()
        {
            InitializeComponent();
        }

        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        public IModuleBPresenterModel Model
        {
            set
            {
                DataContext = value;
            }
        }
    }
}