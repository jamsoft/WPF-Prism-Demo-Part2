#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : ArtistSearchCompletedEventArgs.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using MusicBrainz;

    /// <summary>
    /// 
    /// </summary>
    public class ArtistSearchCompletedEventArgs : AsyncCompletedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsSearchResults">The artists search results.</param>
        public ArtistSearchCompletedEventArgs(List<Artist> artistsSearchResults)
            : this(artistsSearchResults, null, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsSearchResults">The artists search results.</param>
        /// <param name="userState">State of the user.</param>
        public ArtistSearchCompletedEventArgs(List<Artist> artistsSearchResults, object userState)
            : this(artistsSearchResults, null, false, userState)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        /// <param name="userState">State of the user.</param>
        public ArtistSearchCompletedEventArgs(Exception ex, bool cancelled, object userState)
            : this(null, ex, cancelled, userState)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsSearchResults">The artists search results.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        /// <param name="userState">State of the user.</param>
        public ArtistSearchCompletedEventArgs(
            List<Artist> artistsSearchResults, 
            Exception ex, 
            bool cancelled, 
            object userState)
            : base(ex, cancelled, userState)
        {
            ArtistsSearchResults = artistsSearchResults;
        }

        /// <summary>Gets the artists search results.</summary>
        /// <value>The artists search results.</value>
        public List<Artist> ArtistsSearchResults { get; private set; }
    }
}