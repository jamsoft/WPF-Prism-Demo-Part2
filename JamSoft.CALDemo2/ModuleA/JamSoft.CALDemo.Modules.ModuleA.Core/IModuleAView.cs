#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleA.Core
// File Name    : IModuleAView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleA.Core
{
    /// <summary>
    /// The ModuleA view <see langword="interface"/>
    /// </summary>
    public interface IModuleAView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        IModuleAPresenterModel Model { set; }
    }
}