#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleA
// File Name    : ModuleAView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleA
{
    using JamSoft.CALDemo.Modules.ModuleA.Core;

    /// <summary>
    ///     Interaction logic for ModuleAView.xaml
    /// </summary>
    public partial class ModuleAView : IModuleAView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleAView"/> class.
        /// </summary>
        public ModuleAView()
        {
            InitializeComponent();
        }

        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        public IModuleAPresenterModel Model
        {
            set
            {
                DataContext = value;
            }
        }
    }
}