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
    /// </summary>
    public static class Animator
    {
        /// <summary>Fades the specified source opacity.</summary>
        /// <param name="control">The control.</param>
        /// <param name="sourceOpacity">The source opacity.</param>
        /// <param name="targetOpactity">The target opactity.</param>
        /// <param name="milliseconds">The milliseconds.</param>
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