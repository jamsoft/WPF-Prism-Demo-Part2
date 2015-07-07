#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.WpfThemes.Utils
// File Name    : Animator.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.WpfThemes.Utils
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Provides basic animation methods
    /// </summary>
    public static class Animator
    {
        /// <summary>Fades the specified source opacity.</summary>
        /// <param name="control">The <c>control</c>.</param>
        /// <param name="sourceOpacity">The source opacity.</param>
        /// <param name="targetOpactity">The target <c>opactity</c>.</param>
        /// <param name="milliseconds">The <c>milliseconds</c>.</param>
        /// <exception cref="OverflowException"><paramref>
        ///         <name>value</name>
        ///     </paramref>
        /// is less than <see cref="F:System.TimeSpan.MinValue" /> or greater than <see cref="F:System.TimeSpan.MaxValue" />.-or-<paramref>
        ///         <name>value</name>
        ///     </paramref>
        /// is <see cref="F:System.Double.PositiveInfinity" />.-or-<paramref>
        ///         <name>value</name>
        ///     </paramref>
        /// is <see cref="F:System.Double.NegativeInfinity" />. </exception>
        public static void Fade(this UIElement control, double sourceOpacity, double targetOpactity, int milliseconds)
        {
            control.BeginAnimation(
                UIElement.OpacityProperty, 
                new DoubleAnimation(
                    sourceOpacity, 
                    targetOpactity, 
                    new Duration(TimeSpan.FromMilliseconds(milliseconds))));
        }
    }
}