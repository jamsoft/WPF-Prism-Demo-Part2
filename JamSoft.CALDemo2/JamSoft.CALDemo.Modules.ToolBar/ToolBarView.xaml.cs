#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ToolBar
// File Name    : ToolBarView.xaml.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ToolBar
{
    using System.Windows.Controls;

    using JamSoft.CALDemo.Modules.ToolBar.Core;

    /// <summary>
    ///     Interaction logic for ToolBarView.xaml
    /// </summary>
    public partial class ToolBarView : UserControl, IToolBarView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBarView"/> class.
        /// </summary>
        public ToolBarView()
        {
            InitializeComponent();
        }

        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        public IToolBarPresentationModel Model
        {
            set
            {
                DataContext = value;
            }
        }

        /// <summary>Gets the dynamic tool panel.</summary>
        /// <value>The dynamic tool panel.</value>
        public StackPanel DynamicToolPanel
        {
            get
            {
                return DynamicToolsPanel;
            }
        }
    }
}