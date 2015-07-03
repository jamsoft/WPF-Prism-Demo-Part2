#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : ArtistReleasesSearchCompletedEventArgs.cs
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
    /// </summary>
    public class ArtistReleasesSearchCompletedEventArgs : AsyncCompletedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistReleasesSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsReleasesSearchResults">The artists releases search results.</param>
        public ArtistReleasesSearchCompletedEventArgs(List<Release> artistsReleasesSearchResults)
            : this(artistsReleasesSearchResults, null, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistReleasesSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsReleasesSearchResults">The artists releases search results.</param>
        /// <param name="userState">State of the user.</param>
        public ArtistReleasesSearchCompletedEventArgs(List<Release> artistsReleasesSearchResults, object userState)
            : this(artistsReleasesSearchResults, null, false, userState)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistReleasesSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        /// <param name="userState">State of the user.</param>
        public ArtistReleasesSearchCompletedEventArgs(Exception ex, bool cancelled, object userState)
            : this(null, ex, cancelled, userState)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistReleasesSearchCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="artistsReleasesSearchResults">The artists releases search results.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        /// <param name="userState">State of the user.</param>
        public ArtistReleasesSearchCompletedEventArgs(
            List<Release> artistsReleasesSearchResults, 
            Exception ex, 
            bool cancelled, 
            object userState)
            : base(ex, cancelled, userState)
        {
            ArtistsReleasesSearchResults = artistsReleasesSearchResults;
        }

        /// <summary>Gets the artists releases search results.</summary>
        /// <value>The artists releases search results.</value>
        public List<Release> ArtistsReleasesSearchResults { get; private set; }
    }
}