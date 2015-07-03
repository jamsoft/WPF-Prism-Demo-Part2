#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.PageManager
// File Name    : PagePositionComparer.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.PageManager
{
    using System.Collections.Generic;

    using JamSoft.CALDemo.Modules.PageManager.Core;

    /// <summary>
    /// 
    /// </summary>
    internal class PagePositionComparer : Comparer<IPage>
    {
        /// <summary>
        /// When overridden in a derived class, performs a comparison of two objects of the same type and returns a value indicating whether one object is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />.Zero <paramref name="x" /> equals <paramref name="y" />.Greater than zero <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public override int Compare(IPage x, IPage y)
        {
            if (object.Equals(x, y))
            {
                return 0;
            }
            else
            {
                return x.Position.CompareTo(y.Position);
            }
        }
    }
}