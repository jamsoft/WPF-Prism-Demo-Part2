#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.ModuleB.Core
// File Name    : IModuleBView.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.ModuleB.Core
{
    /// <summary>
    /// The IModuleBView <see langword="interface"/>
    /// </summary>
    public interface IModuleBView
    {
        /// <summary>Sets the model.</summary>
        /// <value>The model.</value>
        IModuleBPresenterModel Model { set; }
    }
}