#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleA
// File Name    : ModuleAPresenterModel.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleA
{
    using JamSoft.CALDemo.Modules.ModuleA.Core;
    using JamSoft.CALDemo.Modules.PageManager.Core;

    /// <summary>
    /// The moduleA presenter model
    /// </summary>
    public class ModuleAPresenterModel : IModuleAPresenterModel, IPage
    {
        /// <summary>The _view</summary>
        private readonly IModuleAView _view;

        /// <summary>The _is active page</summary>
        private bool _isActivePage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleAPresenterModel"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="pageManager">The page manager.</param>
        public ModuleAPresenterModel(
            IModuleAView view, 
            IPageManager pageManager)
        {
            _view = view;
            _view.Model = this;

            pageManager.Pages.Add(this);
        }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public string ID
        {
            get
            {
                return "Module A";
            }
        }

        /// <summary>Gets the position.</summary>
        /// <value>The position.</value>
        public float Position
        {
            get
            {
                return 10F;
            }
        }

        /// <summary>Gets the view.</summary>
        /// <value>The view.</value>
        public object View
        {
            get
            {
                return _view;
            }
        }

        /// <summary>Sets a value indicating whether this instance is active page.</summary>
        /// <value>
        /// <c>true</c> if this instance is active page; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivePage
        {
            set
            {
                _isActivePage = value;
            }
        }
    }
}