#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.MusicSearch
// File Name    : MusicSearchObjectConverter.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.MusicSearch
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using MusicBrainz;

    /// <summary>
    /// The music search <c>object</c> converter
    /// </summary>
    internal class MusicSearchObjectConverter
    {
        /// <summary>Converts the specified artist list.</summary>
        /// <param name="artistList">The artist list.</param>
        /// <returns>An observable collection of bindable artists</returns>
        public ObservableCollection<BindableArtist> Convert(List<Artist> artistList)
        {
            var bindableArtists = new ObservableCollection<BindableArtist>();
            foreach (var artist in artistList)
            {
                var bindableArtist = new BindableArtist { Name = artist.GetName(), Id = artist.Id };
                bindableArtists.Add(bindableArtist);
            }

            return bindableArtists;
        }

        /// <summary>Converts the specified release list.</summary>
        /// <param name="releaseList">The release list.</param>
        /// <returns>An observable collection of bindable releases</returns>
        public ObservableCollection<BindableRelease> Convert(List<Release> releaseList)
        {
            var bindableReleases = new ObservableCollection<BindableRelease>();
            foreach (var release in releaseList)
            {
                var bindableRelease = new BindableRelease { Title = release.ToString() };
                bindableReleases.Add(bindableRelease);
            }

            return bindableReleases;
        }
    }
}